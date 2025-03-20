from socket import *
import os
import sys
import struct
import time
import select


ICMP_ECHO_REPLY = 0
ICMP_ECHO_REQUEST = 8
ICMP_TIME_EXCEEDED = 11

MAX_HOPS = 30


def checksum(string):
    csum = 0
    countTo = (len(string) // 2) * 2
    count = 0

    while count < countTo:
        thisVal = string[count + 1] * 256 + string[count]
        csum = csum + thisVal
        csum = csum & 0xffffffff
        count = count + 2

    if countTo < len(string):
        csum = csum + string[len(string) - 1]
        csum = csum & 0xffffffff

    csum = (csum >> 16) + (csum & 0xffff)
    csum = csum + (csum >> 16)
    answer = ~csum
    answer = answer & 0xffff
    answer = answer >> 8 | (answer << 8 & 0xff00)
    return answer


def make_packet():
    my_checksum = 0
    my_id = os.getpid() & 0xFFFF

    header = struct.pack("BBHHH", ICMP_ECHO_REQUEST, 0, my_checksum, my_id, 1)
    data = struct.pack("d", time.time())

    my_checksum = checksum(header + data)

    if sys.platform == 'darwin':
        my_checksum = htons(my_checksum) & 0xffff
    else:
        my_checksum = htons(my_checksum)

    header = struct.pack("bbHHh", ICMP_ECHO_REQUEST, 0, my_checksum, my_id, 1)
    packet = header + data
    return packet



def get_addr_name(addr):
    try:
        return gethostbyaddr(addr)[0]
    except herror:
        return addr


def single_traceroute(dest, ttl, timeout, time_left):
    icmp = getprotobyname("icmp")
    raw_socket = socket(AF_INET, SOCK_RAW, icmp)
    raw_socket.setsockopt(IPPROTO_IP, IP_TTL, struct.pack('I', ttl))
    raw_socket.settimeout(timeout)
    try:
        packet = make_packet()
        raw_socket.sendto(packet, (dest, 0))
        time_sent = time.time()

        started_select = time.time()
        what_ready = select.select([raw_socket], [], [], time_left)
        time_in_select = time.time() - started_select
        if not what_ready[0]:
            print("%d   Timeout: Socket not ready" % ttl)
            return time_left - (time.time() - started_select)
        time_left = time_left - time_in_select
        if time_left <= 0:
            print("%d   Timeout: No time left" % ttl)
            return time_left

        time_received = time.time()
        rec_packet, addr = raw_socket.recvfrom(1024)
        icmp_header = rec_packet[20:28]
        icmp_type, code, checksum, packetID, sequence = struct.unpack(
            "bbHHh", icmp_header)
        addr_name = ""
        if icmp_type == ICMP_TIME_EXCEEDED:
            addr_name = get_addr_name(addr[0])
            print("%d   %s (%s)  %.2f ms" % (ttl, addr_name, addr[0],
                                             (time_received - time_sent)
                                             * 1000))
            return time_left
        elif icmp_type == ICMP_ECHO_REPLY:
            byte = struct.calcsize("d")
            time_sent = struct.unpack("d", rec_packet[28:28 + byte])[0]
            addr_name = get_addr_name(addr[0])
            print("%d   %s (%s)  %.2f ms" % (ttl, addr_name, addr[0],
                                             (time_received - time_sent)
                                             * 1000))
            return -1
        else:
            print("%d   icmp_type: %s   %s (%s)  %.2f ms" % (
                ttl, icmp_type, addr_name, addr[0],
                 (time_received - time_sent) * 1000))
            return time_left
    finally:
        raw_socket.close()


def traceroute(host, timeout=1):
    time_left = timeout
    dest = gethostbyname(host)
    print("Traceroute to " + host + " (%s), %d hops max:"
          % (dest, MAX_HOPS))

    for ttl in range(1, MAX_HOPS):
        time_left = single_traceroute(dest, ttl, timeout, time_left)
        if time_left <= 0:
            break

    if ttl == MAX_HOPS:
        print("Timeout: Exceeded %d hops" % MAX_HOPS)
    return


if __name__ == '__main__':
    host = sys.argv[1]
    #target = 'google.com'
    traceroute(host, timeout=30)

import socket
import struct
import time

'''
ICMP
Тип: 8 (эхо-запрос). Неизменяемое поле.
Код: 0. Неизменяемое поле.
Контрольная сумма. Вычисляемое поле.
Идентификатор. Номер, который можно грубо назвать «сессией» пингов.
Номер в последовательности. Порядковый номер в рамках «сессии».
Данные.
'''

def checksum(source_string):
    """Вычисляет контрольную сумму ICMP-запроса"""
    sum = 0
    count_to = (len(source_string) // 2) * 2
    for count in range(0, count_to, 2):
        this_val = source_string[count] + (source_string[count + 1] << 8)
        sum = sum + this_val
        sum = sum & 0xffffffff

    if count_to < len(source_string):
        sum = sum + source_string[-1]
        sum = sum & 0xffffffff

    sum = (sum >> 16) + (sum & 0xffff)
    sum = sum + (sum >> 16)
    return ~sum & 0xffff


def create_icmp_packet(seq_number):# создаем icmp echo request
    icmp_code = 0
    icmp_checksum = 0
    icmp_type = 0
    icmp_id = 1234
    header = struct.pack("!BBHHH", icmp_type, icmp_code, icmp_checksum, icmp_id, seq_number)
    data = b'hello'
    icmp_checksum = checksum(header + data)
    header = struct.pack("!BBHHH", icmp_type, icmp_code, socket.htons(icmp_checksum), icmp_id, seq_number)
    return header + data

def tracert(dest_name, max_hops = 30):
    dest_addr = socket.gethostbyname(dest_name)
    print(f"Трассировка маршрута к {dest_name} [{dest_addr}] с максимальным числом прыжков {max_hops}:")

    for ttl in range(1, max_hops + 1):
        recv_socket = socket.socket(socket.AF_INET, socket.SOCK_RAW, socket.IPPROTO_ICMP)
        send_socket = socket.socket(socket.AF_INET, socket.SOCK_RAW, socket.IPPROTO_ICMP)
        send_socket.setsockopt(socket.IPPROTO_IP, socket.IP_TTL, ttl)

        recv_socket.bind(("0.0.0.0", 0))
        recv_socket.settimeout(1)

        packet = create_icmp_packet(ttl)
        send_socket.sendto(packet, (dest_addr, 0))
        start_time = time.time()
        try:
            _, addr = recv_socket.recvfrom(4096)
            end_time = time.time()
            elapsed_time = (end_time - start_time) * 1000
            print(f"{ttl}. {addr[0]}  {elapsed_time:.2f} ms")
            if addr[0] == dest_addr:
                break
        except socket.timeout:
            print(f"{ttl}.  * * * Request timed out.")
        finally:
            send_socket.close()
            recv_socket.close()

#отправить пакет на сервер
#дождаться ответа
#измерить задержку



if __name__ == '__main__':
    target_host = input("Введите домен, который хотите проверить\n")
    tracert(target_host)



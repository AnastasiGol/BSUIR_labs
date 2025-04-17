import socket
import threading
import time

UDP_PORT = 9999
TCP_PORT = 10000

name = input("Введите имя узла: ")
known_peers = set()
tcp_connections = []

# ====== UDP-БРОАДКАСТ ======
def send_broadcast():
    udp = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    udp.setsockopt(socket.SOL_SOCKET, socket.SO_BROADCAST, 1)
    message = f"HELLO:{name}"
    udp.sendto(message.encode(), ('255.255.255.255', UDP_PORT))
    udp.close()

def listen_broadcast():
    udp = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    udp.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    udp.bind(('', UDP_PORT))

    while True:
        data, addr = udp.recvfrom(1024)
        if addr[0] == socket.gethostbyname(socket.gethostname()):
            continue  # Игнорировать себя
        msg = data.decode()
        if msg.startswith("HELLO:") and addr[0] not in known_peers:
            print(f"[UDP] Новый участник {addr[0]} — подключаемся")
            known_peers.add(addr[0])
            connect_to_peer(addr[0])

# ====== TCP-СОЕДИНЕНИЕ ======
def connect_to_peer(ip):
    try:
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        sock.connect((ip, TCP_PORT))
        sock.send(name.encode())
        tcp_connections.append(sock)

        threading.Thread(target=handle_peer, args=(sock,)).start()
    except Exception as e:
        print(f"[TCP] Ошибка подключения к {ip}: {e}")

def handle_peer(conn):
    while True:
        try:
            data = conn.recv(1024)
            if not data:
                break
            print(data.decode())
        except:
            break
    conn.close()

def tcp_server():
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server.bind(('', TCP_PORT))
    server.listen()

    while True:
        conn, addr = server.accept()
        name_remote = conn.recv(1024).decode()
        print(f"[TCP] Установлено соединение с {name_remote} ({addr[0]})")
        tcp_connections.append(conn)
        threading.Thread(target=handle_peer, args=(conn,)).start()

# ====== ВВОД СООБЩЕНИЙ ======
def send_messages():
    while True:
        msg = input()
        full_msg = f"[{name}]: {msg}"
        for conn in tcp_connections:
            try:
                conn.send(full_msg.encode())
            except:
                tcp_connections.remove(conn)

# ====== ЗАПУСК ======
threading.Thread(target=listen_broadcast, daemon=True).start()
threading.Thread(target=tcp_server, daemon=True).start()

time.sleep(1)
send_broadcast()

send_messages()

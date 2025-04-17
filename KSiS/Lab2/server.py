import socket

sock = socket.socket()   #создаем сокет
sock.bind(('', 9090))# первый элемент  — хост, а второй — порт
sock.listen(1) #длина очереди
conn, addr = sock.accept()

print( 'connected:', addr)

while True:
    data = conn.recv(1024)
    if not data:
        break
    conn.send(data.upper())

conn.close()
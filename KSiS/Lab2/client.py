import socket

client = socket.socket()
# подключаемся по адресу www.python.org и порту 80
client.connect(("www.python.org", 80))
# данные для отправки - стандартные заголовки протокола http
message = "GET / HTTP/1.1\r\nHost: www.python.org\r\nConnection: close\r\n\r\n"
print("Connecting...")
client.send(message.encode())  # отправляем данные серверу
data = client.recv(1024)  # получаем данные с сервера
print("Server sent: ", data.decode())  # выводим данные на консоль
client.close()


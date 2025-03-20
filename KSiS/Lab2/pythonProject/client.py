import socket

#нужно создать сокет, подключиться к серверу послать ему данные,
# принять данные и закрыть соединение
client = socket.socket()
port = 5050
hostname = socket.gethostname()
client.connect((hostname, port))

data = client.recv(1024) #читаем 1024 байт данных
client.close()

print(data.decode())
client.close()


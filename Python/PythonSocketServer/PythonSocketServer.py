import time
import struct
import socket
import select
import errno

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((socket.gethostname(), 48510))
s.listen()

host = socket.gethostname();
print(host)
print("IP address: " + socket.gethostbyname(host))
pingspeed = time.time() + 5

while True:
    clientsocket, address = s.accept()

    print(f"Connection from {address} has been established")
    clientsocket.send(bytes("Welcome to the server\n","utf-8"))

    
    while True:
        try:
            data = clientsocket.recv(1024)
            print(data.decode("utf-8"))
        except:
            clientsocket.close;
            print("Failed to recive messange, client disconected!")
            break;

s.close();


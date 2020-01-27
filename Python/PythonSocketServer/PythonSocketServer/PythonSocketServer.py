import serial
import time
import struct
import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((socket.gethostname(), 40005))
s.listen(5)
print(socket.gethostname())
connected = True

while True:
    connected = True
    clientsocket, address = s.accept()
    print(f"Connection from {address} has been established")
    clientsocket.send(bytes("Welcome to the server\n","utf-8"))

    
    while connected:
        try:
            clientsocket.send(bytes("Twoja stara","utf-8"))
        except :
            print("Lost connection")
            connected = False
        #line = conn.readline()
        #line = line.decode("utf-8")
        #print(line)
        time.sleep(5)
    time.sleep(10)
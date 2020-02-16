import socket
import time

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(('192.168.43.30', 40005))

timer = time.time()

while True:
    msg = s.recv(1024)
    print(msg.decode("utf-8"))

    if timer < time.time():
        s.send(bytes("Hello there", "utf-8"))
        timer += 10;
    
    

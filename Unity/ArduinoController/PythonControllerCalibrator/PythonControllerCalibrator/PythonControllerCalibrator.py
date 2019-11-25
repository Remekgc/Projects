import pygame
from pygame.locals import QUIT
import serial
import time
import struct
import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM) # Creatring 'Server' socket to communicate with c# client
s.bind((socket.gethostname(), 1234)) # [Hostname] = this machinee name, [port] = 1234
s.listen(1) # listen for input every 1 sec
print(socket.gethostname())

conn = serial.Serial('COM8', 9600)

#pygame.init()
#surface = pygame.display.set_mode((400,400))

#print(surface.get_at((0,0)))
y = 0.0

while True:
    t0 = time.time()
    #pygame.display.update()
    clientsocket, address = s.accept()
    print(f"Connection from {address} has been established")
    #clientsocket.send(bytes("Welcome to the server\n","utf-8"))
    #for event in pygame.event.get():
        #if event.type == QUIT:
        #    going = False

    while True:
        line = conn.readline()
        print(line)
        line = line.decode("utf-8")
        print(line)
        print(line)
        line = str(line)
        line = line[:-2]
        print(line)
        print(line)
        #line = line.encode("utf-8")
        clientsocket.send(bytes(line, "utf-8"))
        #y = float(line)
        #pygame.draw.aaline(surface, (0, 0, 255), (0, 200-y), (400, 200+y))
        #print(line)
        #print(y)
        time.sleep(1)

s.close()
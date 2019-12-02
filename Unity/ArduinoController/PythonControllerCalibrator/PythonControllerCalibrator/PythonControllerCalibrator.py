import pygame
import serial
from pygame.locals import *
import time
import struct
import socket
import threading

global y1
global y2

y1 = 0.0
y2 = 0.0

screenWidth = 800
screenHeight = 600

pygame.init()
surface = pygame.display.set_mode((screenWidth,screenHeight))

pygame.display.set_caption("Remek&Adrian Flying Simulator")

font = pygame.font.Font('freesansbold.ttf', 20)

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)  # Creatring 'Server' socket to communicate with c# client
s.bind((socket.gethostname(), 1234))  # [Hostname] = this machinee name, [port] = 1234
s.listen(1)  # listen for input every 1 sec
print(socket.gethostname())

def socketListener():
    global clientSocket
    while True:
        clientSocket, address = s.accept()

def connecting():
    while True:
        for event in pygame.event.get():
            if event.type == QUIT:
                going = False
        global y1
        global y2
        try:
            conn = serial.Serial('COM13', 9600)
        except:
            pass
        try:
            line = conn.readline()

            line = line.decode("utf-8")

            line = str(line)
            line = line[:-2]
            print("twoja stara 2")
        except:
            line = "0.0,0.0,"
        try:
            clientSocket.send(bytes(line, "utf-8"))
        except:
            print("Client not connected")
        splittedline = line.split(",")
        del splittedline[-1]
        try:
            y2 = float(splittedline[0])
        except:
            print("can't read y2")
            y2 = 0.0
        try:
            y1 = float(splittedline[1])
        except:
            print("can't read y1")
            y1 = 0.0
        print(y1)
        print(y2)


x = threading.Thread(target = connecting)

x.start()

socketThread = threading.Thread(target = socketListener)

socketThread.start()

while True:
    pygame.display.update()
    for event in pygame.event.get():
        if event.type == QUIT:
            going = False

    while True:
        for event in pygame.event.get():
            if event.type == QUIT:
                going = False
        surface.fill((0, 0, 0))

        textToRender = ("PITCH: " + str(y2))
        textToRender2 = ("ROLL: " + str(y1))
        text = font.render(textToRender, True, (0, 0, 255), (0, 0, 0))
        text2 = font.render(textToRender2, True, (0, 0, 255), (0, 0, 0))

        textRect = text.get_rect()
        textRect2 = text.get_rect()

        textRect.center = (75, 25)
        textRect2.center = (75, 50)

        surface.blit(text, textRect)
        surface.blit(text2, textRect2)

        pygame.draw.aaline(surface, (0, 0, 255), (screenWidth/2, 0),(screenWidth/2, screenHeight))
        pygame.draw.aaline(surface, (0, 0, 255), (0, (screenHeight/2)-int(y1*2.2)), (screenWidth, (screenHeight/2)+int(y1*2.2)))
        pygame.draw.circle(surface, (255, 0, 0), (int(screenWidth/2), int(screenHeight/2)-int(y2*5)), 5)
        pygame.display.update()
        pygame.display.flip()
        #time.sleep(1)

#s.close()

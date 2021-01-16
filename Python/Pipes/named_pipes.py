import pywpipe as wpipe
import time
from datetime import datetime
import random

pserver = wpipe.Server('mypipe', wpipe.Mode.Writer)

while True:
    input()
    x = random.uniform(0.0, 100.0)
    y = random.uniform(0.0, 100.0)
    
    for client in pserver:
        client.write(bytes("{X:" + str(x) + ",Y:" + str(y) + "}", "utf-8"))
        print(datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')[:-2])

pserver.shutdown()

# pserver = wpipe.Server('mypipe', wpipe.Mode.Slave)

# while True:
#     for client in pserver:
#         while client.canread():
#             rawmsg = client.read()
#             print(rawmsg)
#             client.write(b'{X:0.4355, Y:0.4355}')
#     pserver.waitfordata()


# pserver.shutdown()

# cam: {X:0.4355, Y:0.4355} - {X:3, T:0.4, D:"Current time"}
# game: {"Fix"}
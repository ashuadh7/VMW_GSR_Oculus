import click
from bleak import BleakScanner, BleakClient
import asyncio
import socket
from datetime import datetime

host, port = "127.0.0.1", 25000

GATT_MM_SERVICE_UUID = "dd499b70-e4cd-4988-a923-a7aab7283f8e"

GATT_STREAM_CHAR_UUID = "a0956420-9bd2-11e4-bd06-0800200c9a66"
GATT_RAW_DATA_CHAR_UUID = "f1b41cde-dbf5-4acf-8679-ecb8b4dca6ff"

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

global firstTime
firstTime = True

# Scan for Moodmetric rings
def scan():
    print("Scanning...")
    def callback(device, advertising_data):
        print(device)

    async def run():
        # loop = asyncio.get_event_loop()

        try:
            scanner = BleakScanner(callback, service_uuids=[GATT_MM_SERVICE_UUID])
            await scanner.start()
            # await loop.create_future()
        finally:
            await scanner.stop()

    asyncio.run(run())


def stream(device, outfile):
    # try:
    #     sock.connect((host, port))
    async def run():
        evt = asyncio.Event()

        def disconnected_cb(client):
            print("Disconnected!")
            evt.set()

        with open(outfile, 'w') as out:
            collector = Collector(out)
            loop = asyncio.get_event_loop()

            try:
                client = BleakClient(device, disconnected_callback=disconnected_cb)
                print("Connecting...")
                await client.connect()

                print("Subscribing...")
                await asyncio.gather(
                    client.start_notify(GATT_RAW_DATA_CHAR_UUID, collector.raw_data_callback),
                    client.start_notify(GATT_STREAM_CHAR_UUID, collector.stream_callback),
                )

                print("Subscribed")
                await evt.wait()
            finally:
                if client.is_connected:
                    print("Disconnecting...")
                    await client.disconnect()

    asyncio.run(run())
    # finally:
    #     sock.close()

def write_tabular(f, obj):
    f.write("\t".join(map(lambda k: "{}:{}".format(k[0], k[1]), obj.items())) + "\n")
    f.flush()

class Collector:
    stream = []
    raw = []

    def __init__(self, f):
        self.f = f

    def raw_data_callback(self, sender: int, data: bytearray):
        raw = int.from_bytes(data[0:2], 'big')
        print("raw: ", raw)

    def stream_callback(self, sender: int, data: bytearray):
        global  firstTime
        print(firstTime)
        if firstTime:
            sock.connect((host, port))
            firstTime = False
        status = data[0]
        mm = data[1]
        instant = int.from_bytes(data[2:4], 'big')
        print("mm: ", mm)
        write_tabular(self.f, {
            "type": "stream",
            "mm": mm,
            "instant": instant,
            "status": status,
        })
        mmStr = str(mm)
        sock.sendall(mmStr.encode("utf-8"))

if __name__ == "__main__":
    date = datetime.now().strftime("%Y_%m_%d_%I_%M_%S_%p")
    date = str(date)
    # date = "myfile"
    date += ".csv"
    stream("E0:17:72:BD:C6:9D", date)
    # stream("E2:5E:AB:D7:48:D9")
    # scan()
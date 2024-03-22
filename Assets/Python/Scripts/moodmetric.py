from bleak import BleakScanner, BleakClient
import asyncio
import socket
from datetime import datetime

# Constants
HOST, PORT = "127.0.0.1", 25000
GATT_MM_SERVICE_UUID = "dd499b70-e4cd-4988-a923-a7aab7283f8e"
GATT_STREAM_CHAR_UUID = "a0956420-9bd2-11e4-bd06-0800200c9a66"
GATT_RAW_DATA_CHAR_UUID = "f1b41cde-dbf5-4acf-8679-ecb8b4dca6ff"

# Global Variables
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
first_time = True


class Collector:
    def __init__(self):
        self.stream = []
        self.raw = []

    async def raw_data_callback(self, sender: int, data: bytearray):
        raw = int.from_bytes(data[0:2], 'big')
        print("raw:", raw)

    async def stream_callback(self, sender: int, data: bytearray):
        global first_time
        if first_time:
            sock.connect((HOST, PORT))
            first_time = False
        status, mm = data[0], data[1]
        instant = int.from_bytes(data[2:4], 'big')
        print("mm:", mm)
        sock.sendall(str(mm).encode("utf-8"))


async def scan():
    print("Scanning...")
    scanner = BleakScanner(service_uuids=[GATT_MM_SERVICE_UUID])
    await scanner.start()
    await asyncio.sleep(5)  # Scan for 5 seconds
    await scanner.stop()


async def stream(device_address):
    async def run():
        collector = Collector()
        client = BleakClient(device_address)

        try:
            print("Connecting...")
            await client.connect()
            print("Subscribing...")
            await asyncio.gather(
                client.start_notify(GATT_RAW_DATA_CHAR_UUID, collector.raw_data_callback),
                client.start_notify(GATT_STREAM_CHAR_UUID, collector.stream_callback)
            )
            print("Subscribed. Press Ctrl+C to exit.")
            await asyncio.Future()  # Run indefinitely
        finally:
            if client.is_connected:
                print("Disconnecting...")
                await client.disconnect()

    await run()


if __name__ == "__main__":
    device_address = "E0:17:72:BD:C6:9D"
    asyncio.run(stream(device_address))

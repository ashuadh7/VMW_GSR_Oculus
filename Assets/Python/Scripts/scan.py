import asyncio
import socket
from bleak import BleakScanner, BleakClient


class BLECommunication:
    GATT_MM_SERVICE_UUID = "dd499b70-e4cd-4988-a923-a7aab7283f8e"
    GATT_STREAM_CHAR_UUID = "a0956420-9bd2-11e4-bd06-0800200c9a66"
    GATT_RAW_DATA_CHAR_UUID = "f1b41cde-dbf5-4acf-8679-ecb8b4dca6ff"

    def __init__(self, host="127.0.0.1", port=25000):
        self.sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.host = host
        self.port = port

    async def scan_and_connect(self):
        devices = await self.scan()
        for device in devices:
            await self.stream(device)

    async def scan(self):
        print("Scanning...")
        devices = []

        def callback(device, advertising_data):
            if self.GATT_MM_SERVICE_UUID in advertising_data.service_uuids:
                print(device)
                devices.append(device)

        scanner = BleakScanner(callback)
        await scanner.start()
        await asyncio.sleep(5.0)  # Scan for 5 seconds
        await scanner.stop()
        return devices

    async def stream(self, device):
        try:
            self.sock.connect((self.host, self.port))
            await self._stream_data(device)
        finally:
            self.sock.close()

    async def _stream_data(self, device):
        async with BleakClient(device) as client:
            print("Connecting...")
            collector = DataCollector(self.sock)
            await asyncio.gather(
                client.start_notify(self.GATT_RAW_DATA_CHAR_UUID, collector.raw_data_callback),
                client.start_notify(self.GATT_STREAM_CHAR_UUID, collector.stream_callback),
            )
            await asyncio.sleep(30)  # Keep the connection open for 30 seconds


class DataCollector:
    def __init__(self, sock):
        self.sock = sock

    def raw_data_callback(self, sender, data):
        raw = int.from_bytes(data[0:2], 'big')
        print("raw: ", raw)

    def stream_callback(self, sender, data):
        mm = data[1]
        print("mm: ", mm)
        self.sock.sendall(str(mm).encode("utf-8"))


async def main():
    ble_comms = BLECommunication()
    await ble_comms.scan_and_connect()


if __name__ == "__main__":
    asyncio.run(main())

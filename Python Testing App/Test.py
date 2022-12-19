import requests
import uuid
import time
import threading
# defining the api-endpoint 
API_ENDPOINT = "https://localhost:7119/api/Bets/create"
a = time.perf_counter()
def send_requests():
  for i in range(25):
    myuuid = uuid.uuid4()
    # data to be sent to api
    data = {
      "betsId": str(myuuid),
      "name": "string",
      "ammount": 0,
      "win": 0,
      "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "gameId": 0
    }
    # sending post request and saving response as response object
    r = requests.post(url = API_ENDPOINT, json = data, verify=False)
    # extracting response text 
    pastebin_url = r.text
t1 = threading.Thread(target=send_requests())
t2 = threading.Thread(target=send_requests())
t3 = threading.Thread(target=send_requests())
t4 = threading.Thread(target=send_requests())

t1.start()
t2.start()
t3.start()
t4.start()

t1.join()
t2.join()
t3.join()
t4.join()
print(time.perf_counter() - a)
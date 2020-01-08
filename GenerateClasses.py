import pandas as pd
import requests
import csv
import json

access_token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InZpczI5ODIzMjMwMSIsIm5iZiI6MTU3ODQxOTU2MiwiZXhwIjoxNTc5MDI0MzYyLCJpYXQiOjE1Nzg0MTk1NjJ9.ndUKXSlojbJpJeI4L3TBKmcY8y4IYuOBQooXeJluJfM'

url = 'https://localhost:6001/api/State'



def send(data):
    result = requests.post(url,data= data,
        headers={'Content-Type':'application/json',
                'Authorization': 'Bearer {}'.format(access_token)},verify=False)



csvfile = open('./data/State.csv', 'r')

reader = csv.DictReader(csvfile)
for row in reader:
    jsonData = json.dumps(row)
    send(jsonData)
    
    




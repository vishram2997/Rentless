import pandas as pd
import requests
import csv
import json

access_token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InZpc2hyYW0yOTk3IiwibmJmIjoxNTc5NjQzNTIzLCJleHAiOjE1ODAyNDgzMjMsImlhdCI6MTU3OTY0MzUyM30.MdnLaKHS2wKAHbUwMD3_emsQL9OMLV_YUn9-AybMw5Y'

BaseUrl = 'https://localhost:6001/api/'



def send(data, url):
    print(data)
    result = requests.post(url,data= data,
        headers={'Content-Type':'application/json',
                'Authorization': 'Bearer {}'.format(access_token)},verify=False)
    print(result.content)



csvfile = open('./data/USStateTimeLongLat.csv', 'r')
def importCity():
    reader = csv.DictReader(csvfile)
    for row in reader:
        cityJson =  '{"Code":"%s","Name":"%s","StateCode":"%s","CountryId":"%s"}'  %(row['City'].replace(" ", ""),row['City'],row['State'],'USA')
        jsonData = json.dumps(cityJson)
        print(jsonData)
        send(jsonData, BaseUrl+'city')
    
    

def importCurrency():
    csvfile = open('./data/Currency.csv', 'r')
    reader = csv.DictReader(csvfile)
    for row in reader:
        jsonData = json.dumps(row)
        send(jsonData, BaseUrl+'currency')
     

def importCountry():
    csvfile = open('./data/Country.csv', 'r')
    reader = csv.DictReader(csvfile)
    for row in reader:
        jsonData = json.dumps(row)
        send(jsonData, BaseUrl+'country')
   


def importState():
    csvfile = open('./data/State.csv', 'r')
    reader = csv.DictReader(csvfile)
    for row in reader:
        jsonData = json.dumps(row)
        send(jsonData, BaseUrl+'state')
   
   

def importCustListing():
    csvfile = open('./data/CustProduct.txt', 'r')
    f1 = csvfile.readlines()
    for row in f1:
        jsonData =  json.loads(str(row))
       # jsonData = jsonData.replace("\'","")
       # print(jsonData)
        send(jsonData, BaseUrl+'CustListing')
   


def importDocuType():
    csvfile = open('./data/CustProduct.txt', 'r')
    f1 = csvfile.readlines()
    for row in f1:
        jsonData =  json.loads(str(row))
       # jsonData = jsonData.replace("\'","")
       # print(jsonData)
        send(jsonData, BaseUrl+'CustListing')
   

# Python 3 program for the 
# haversine formula 
import math 

# Python 3 program for the 
# haversine formula 
def haversine(lat1, lon1, lat2, lon2): 
	
	# distance between latitudes 
	# and longitudes 
	dLat = (lat2 - lat1) * math.pi / 180.0
	dLon = (lon2 - lon1) * math.pi / 180.0

	# convert to radians 
	lat1 = (lat1) * math.pi / 180.0
	lat2 = (lat2) * math.pi / 180.0

	# apply formulae 
	a = (pow(math.sin(dLat / 2), 2) +
		pow(math.sin(dLon / 2), 2) *
			math.cos(lat1) * math.cos(lat2)); 
	rad = 6371
	c = 2 * math.asin(math.sqrt(a)) 
	return rad * c*0.621371 
    


#importCurrency()
#importCountry()
#importState()
#importCity
importCustListing()
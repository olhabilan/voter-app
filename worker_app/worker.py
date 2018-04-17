import pymongo
from pymongo import MongoClient
import psycopg2

client = MongoClient(port=27017)
db=client.result
collection=db.scoreCollection
dict={}
for i in collection.find({"isProcessed":False}):
    if ( i['supermarketName'] not in dict.keys()):
        dict.setdefault(i['supermarketName'], [])
        dict[i['supermarketName']].append(i['serviceScore'])
        dict[i['supermarketName']].append(i['overallScore'])
        dict[i['supermarketName']].append(i['priceScore'])
        dict[i['supermarketName']].append(1)
    else:
        dict[i['supermarketName']][0]+=(i['serviceScore'])
        dict[i['supermarketName']][1]+=(i['overallScore'])
        dict[i['supermarketName']][2]+=(i['priceScore'])
        dict[i['supermarketName']][3]+=1
    collection.update_one({ "supermarketName" : i['supermarketName'] }, {"$set": { "isProcessed": True } }
)

#for key, value in dict.iteritems():
#    print (key + ', ' + str(value[0]/value[3]) + ', ' + str(value[1]/value[3]) + ', ' + str(value[2]/value[3]) + ', ' + str(value[3]))

'''
sql = "INSERT INTO result(supermarket_name, avg_service_score, avg_overall_score, avg_price_score) VALUES(%s)"
conn = psycopg2.connect(host='localhost', db='poll_result')
cur = conn.cursor()
for key, value in dict.iteritems():
    cur.execute(sql,key + ', ' + str(value[0]/value[3]) + ', ' + str(value[1]/value[3]) + ', ' + str(value[2]/value[3]) + ', ' + str(value[3]))
conn.commit()
cur.close()
'''
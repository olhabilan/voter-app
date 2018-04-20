import pymongo
from pymongo import MongoClient
import psycopg2, sys
import os
import time

postgres_host=os.environ['POSTGRES_HOST']
mongo_host=os.environ['MONGO_HOST']
postgres_password=os.environ['POSTGRES_PASSWORD']

def getMongo():
    client = MongoClient(host=mongo_host, port=27017)
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
        collection.update_one({ "_id" : i['_id'] }, {"$set": { "isProcessed": True } })
    print("Data to insert: "+ str(dict))
    return dict

def insertPostgres( dict ):
    update_sql = "UPDATE result SET avg_service_score = (avg_service_score*count + %s)/(count + %s), avg_overall_score = (avg_overall_score*count + %s)/(count + %s) , avg_price_score = (avg_price_score*count + %s)/(count + %s) , count = count + %s where supermarket_name=%s"
    sql = 'INSERT INTO result(supermarket_name, avg_service_score, avg_overall_score, avg_price_score, count) VALUES(%s)'
    conn = psycopg2.connect(host=postgres_host, dbname='poll_result', user="postgres", password=postgres_password)
    #, user='postgres'
    cur = conn.cursor()
    for key, value in dict.iteritems():
        try:
            cur.execute(sql % ("'" + str(key) + "', " + str(value[0]/value[3]) + ', ' + str(value[1]/value[3]) + ', ' + str(value[2]/value[3]) + ', ' + str(value[3])))
        except:
            conn.rollback()
            cur.execute(update_sql,(str(value[0]),str(value[3]),str(value[1]),str(value[3]),str(value[2]),str(value[3]),str(value[3]),key))
    conn.commit()
    cur.close()
    print("Data was inserted into Postgres")

while True:
    tempDict = getMongo()
    insertPostgres(tempDict)
    tempDict={}
    print("Processed")
    time.sleep(60)

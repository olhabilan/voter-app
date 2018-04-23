use result;
db.createCollection("scoreCollection");
db.scoreCollection.createIndex({isProcessed: 1, dateScore: -1})
db.scoreCollection.insert({ supermarketName: "Green Land",
    codeName: "D870FTfU",
    serviceScore: 2,
    overallScore: 4,
    priceScore: 5,
    scoreDate: new Date(),
    isProcessed: false } )
db.scoreCollection.explain().find()
db.scoreCollection.getIndexes()




db.scoreCollection.insert({ supermarketName: "Green Land23",
    codeName: "D870FTfU",
    serviceScore: 2,
    overallScore: 4,
    priceScore: 5,
    scoreDate: new Date(),
    isProcessed: false } )
db.scoreCollection.insert({ supermarketName: "Green Land14",
    codeName: "D870FTfU",
    serviceScore: 2,
    overallScore: 4,
    priceScore: 5,
    scoreDate: new Date(),
    isProcessed: false } )
db.scoreCollection.insert({ supermarketName: "Green Land",
    codeName: "D870FTfU",
    serviceScore: 2,
    overallScore: 5,
    priceScore: 5,
    scoreDate: new Date(),
    isProcessed: false } )
db.scoreCollection.insert({ supermarketName: "Green Land14",
    codeName: "D870FTfU",
    serviceScore: 2,
    overallScore: 2,
    priceScore: 5,
    scoreDate: new Date(),
    isProcessed: false } )
const express = require('express');
const db = require('pg');
const app = new express();
const config = require('./appconfig.json');
const connectionString = process.env.DATABASE_URL || config.ConnectionString;
app.get('/', (req, res) => {

  res.sendFile(__dirname + '/web/index.html');
});

app.get('/result', async (req, res, next) => {
  try {
    let client = new db.Client(connectionString);
    await client.connect();
    const query = await client.query('select * from result;');
    let shops = query.rows.map((val, index) => {
      return {
        name: val.supermarket_name.trim(), 
        price: val.avg_price_score, 
        service: val.avg_service_score,
        overall: val.avg_overall_score,
        count: val.count
      };
    });
    await client.end();

    res.setHeader('Content-Type', 'application/json');
    res.send(JSON.stringify({shops: shops}));
  }
  catch(e) {
    next(e);
  }
});

app.use(express.static(__dirname + '/web'));
app.listen(8080);
console.log('listening on port 8080');
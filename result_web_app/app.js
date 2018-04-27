const express = require('express');
const app = new express();

app.get('/', (req, res) => {

  res.sendFile(__dirname + '/web/index.html');
});

app.get('/result', (req, res) => {
  res.setHeader('Content-Type', 'application/json');
  res.send(JSON.stringify({shops: [
    {name: "Silpo", price: 12, service: 13, overall: 10},
    {name: "Atb", price: 12, service: 13, overall: 10},
  ]}));
});

app.use(express.static(__dirname + '/web'));
app.listen(8080);
console.log('listening on port 8080');
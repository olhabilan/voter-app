const express = require('express');
const app = new express();
var path = require('path')
app.use(express.static(path.join(__dirname, 'public')));
app.get('/*', function(request, response){
    response.render(__dirname + "/index.html");
});
app.engine('html', require('ejs').renderFile);
app.listen(8000);
console.log('listening on port 8000');


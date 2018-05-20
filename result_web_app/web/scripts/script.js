const headerRowId = "row-header";

document.addEventListener("DOMContentLoaded", async e => { 
  let data = await getData();

  if(data == null)
    return;

  let headerRow = document.getElementById(headerRowId);
  for(let i = 0; i < data.shops.length; i++)
  {
  headerRow.insertAdjacentHTML('afterend', `<div class="row">
                                              <div class="cell" data-title="Shop Name">`+
                                                data.shops[i].name + `
                                              </div>
                                              <div class="cell" data-title="Price">` +
                                                data.shops[i].price + `
                                              </div>
                                              <div class="cell" data-title="Service"> `+
                                                data.shops[i].service + `
                                              </div>
                                              <div class="cell" data-title="Overall"> `+
                                                data.shops[i].overall + `
                                              </div>
                                              <div class="cell" data-title="Count"> `+
                                                data.shops[i].count + `
                                              </div>
                                            </div>`);
  }

  retnderPie(data.shops);
  console.log(data);
});

async function getData(params) {
  let response = await fetch('result');

  if(response.status == 200)
  {
    return await response.json();
  }
  else
  {
    console.error("Error loading result data");
    return null;
  }
}

function retnderPie(shops) {
  const colors = ["#2484c1", "#0c6197", "#4daa4b", "#90c469", 
  "#daca61", "#e98125", "#cb2121", "#923e99", "#ae83d5", 
  "#bf273e", "#ce2aeb", "#bca44a", "#618d1b", "#1ee67b","#b0ec44",
  "#a4a0c9","#322849","#86f71a","#d1c87f","#7d9058","#44b9b0","#7c37c0", 
  "#cc9fb1","#e65414","#8b6834","#248838"];

  let content = shops.map((val, i, arr) => {
    let index = i;
    if(i > colors.length - 1)
    {
      index = Math.random(0, colors.length);
    }

    return {
      "label": val.name,
      "value": val.count,
      "color": colors[index]
    }
  });

	let pie = new d3pie("pieChart", {
    "header": {
      "title": {
        "text": "Shop popularity",
        "fontSize": 24,
        "font": "Poppins-Regular sans-serif",
        "color": "#fff"
      },
    },
    "size": {
      "canvasWidth": 590,
      "pieOuterRadius": "90%"
    },
    "data": {
      "sortOrder": "value-desc",
      "smallSegmentGrouping": {
        "enabled": true
      },
      "content": content
    },
    "labels": {
      "outer": {
        "pieDistance": 32
      },
      "inner": {
        "hideWhenLessThanPercentage": 3
      },
      "mainLabel": {
        "fontSize": 11
      },
      "percentage": {
        "color": "#ffffff",
        "decimalPlaces": 0
      },
      "value": {
        "color": "#adadad",
        "fontSize": 11
      },
      "lines": {
        "enabled": true
      },
      "truncation": {
        "enabled": true
      }
    },
    "effects": {
      "pullOutSegmentOnClick": {
        "effect": "linear",
        "speed": 400,
        "size": 8
      }
    },
    "misc": {
      "gradient": {
        "enabled": true,
        "percentage": 100
      }
    }
  });
}
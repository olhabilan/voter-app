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
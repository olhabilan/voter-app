console.log("hello");

document.addEventListener("DOMContentLoaded", async e => { 
  let res = await getData();
  console.log(res);
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
document.addEventListener("DOMContentLoaded", e => {

  // initialize
  let codeTextboxId = "code";
  let submitButtonId = "submit-code";
  let shopNameHeaderId = "shop-name";
  let shopInfoSectionId = "shop-info";
  let errorDivId = "error";
  document.getElementById(submitButtonId).addEventListener("click", submitCode);

  function submitCode(e)
  {
    let code = document.getElementById(codeTextboxId).value;

    if(!code)
    {
      showError("Please enter the code");
      return;
    }
      
    // make ajax
    let result = {
      success: true,
      shop: "Silpo"
    };

    if(!result.success)
      return;

    document.getElementById(shopNameHeaderId).innerText = result.shop;
    document.getElementById(shopInfoSectionId).style.display = "block";
  }

  function showError(text)
  {
    document.getElementById(errorDivId).innerText = text;
    document.getElementById(errorDivId).style.display = "block";
  }

});
document.addEventListener("DOMContentLoaded", e => {

  // initialize
  let codeTextboxId = "code";
  let checkCodeButtonId = "submit-code";
  let submitButtonId = "submit-info";
  let shopNameHeaderId = "shop-name";
  let shopInfoSectionId = "shop-info";
  let errorDivId = "error";
  let priceRadioGroupName = "group-1";
  let serviceRadioGroupName = "group-2";
  let overallRadioGroupName = "group-3";
  document.getElementById(checkCodeButtonId).addEventListener("click", checkCode);
  document.getElementById(submitButtonId).addEventListener("click", submitCode);

  function checkCode(e)
  {
    showError("");
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

    document.getElementById(checkCodeButtonId).style.display = "none";
    document.getElementById(shopNameHeaderId).innerText = result.shop;
    document.getElementById(shopInfoSectionId).style.display = "block";
    document.getElementById(codeTextboxId).setAttribute("readonly", true);
  }

  function submitCode()
  {
    let price = getRadioValue(priceRadioGroupName);
    let service = getRadioValue(serviceRadioGroupName);
    let overall = getRadioValue(overallRadioGroupName);

    if(price == 0 || service == 0 || overall == 0)
    {
      showError("Please estimate all parameters");
      return;
    }

    // make post 
    //here
    let code = document.getElementById(codeTextboxId).value;
    let shop = document.getElementById(shopNameHeaderId).innerText;
    let shopInformation = {
      code: code,
      shop: shop,
      mark: {
        price: price,
        service: service,
        overall: overall
      }
    }

    document.getElementById(codeTextboxId).value = "";
    document.getElementById(shopInfoSectionId).style.display = "none";
    document.getElementById(codeTextboxId).removeAttribute("readonly");
    showError("");
    clearRadioValues();
    document.getElementById(checkCodeButtonId).style.display = "inline-block";
  }

  function getRadioValue(radioGroupName)
  {
    let finalValue = 0;
    document.getElementsByName(radioGroupName).forEach((radio, index, list) => {
      if(radio.checked)
      {
        finalValue = +radio.value;
      }
    });

    return finalValue;
  }

  function clearRadioValues()
  {
    clearRadioValuesInternal(priceRadioGroupName);
    clearRadioValuesInternal(serviceRadioGroupName);
    clearRadioValuesInternal(overallRadioGroupName);
  }

  function clearRadioValuesInternal(name)
  {
    document.getElementsByName(name).forEach((radio, index, list) => {
      radio.checked = false;
    });
  }

  function showError(text)
  {
    document.getElementById(errorDivId).innerText = text;
    document.getElementById(errorDivId).style.display = "block";
  }

});
function solve() {
  let startNum = $('#firstNumber').val();
  let endNum = $('#secondNumber').val();

  let firstWord = $('#firstString').val();
  let secondWord = $('#secondString').val();
  let thirdWord = $('#thirdString').val();

  let divResult = $('#result');

  for (let i = startNum; i <= endNum; i++) {
    checkCurrentNumber(i);
  }

  function checkCurrentNumber(i) {
    if (i % 3 === 0 && i % 5 === 0) {
      $('<p>').html(`${i} ${firstWord}-${secondWord}-${thirdWord}`);
      divResult.append(p);
    } else if (i % 3 === 0) {
      $('<p>').html(`${i} ${secondWord}`);
      divResult.append(p);
    } else if (i % 5 === 0) {      
      $('<p>').html(`${i} ${thirdWord}`);
      divResult.append(p);
    } else {
      $('<p>').html(i);
      divResult.append(p);
    }
  }
}
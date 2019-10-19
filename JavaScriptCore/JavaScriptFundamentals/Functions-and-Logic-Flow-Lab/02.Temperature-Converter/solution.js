function solve() {
  let degree = $('#num1').val();
  let type = $('#type').val().toLowerCase();

  let convertedTemperature = 0;
  let correctType = false;

  if (type === 'celsius') {
    correctType = true;
    convertedTemperature = ((degree * 9) / 5) + 32;
  } else if (type === 'fahrenheit') {
    correctType = true;
    convertedTemperature = (((degree - 32) * 5) / 9);
  }

  $('#result').html(() => {
    if (correctType) {
      return Math.round(convertedTemperature);
    } else {
      return "Error!";
    }
  });  
}
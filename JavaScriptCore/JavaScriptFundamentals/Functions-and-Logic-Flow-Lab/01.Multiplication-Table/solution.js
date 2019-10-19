function solve() {
  let numberToBeMultiplied = Number($('#num1').val());
  let multiplier = Number($('#num2').val());
  let divResult = $('#result');

  divResult.html(() => {
    if (numberToBeMultiplied > multiplier) {
      return "Try with other numbers.";
    }
  });

  for (let i = numberToBeMultiplied; i <= multiplier; i++) {
    let result = multiplier * i;

    divResult.append($('<p>').html(`${i} * ${multiplier} = ${result}`));
  }
}
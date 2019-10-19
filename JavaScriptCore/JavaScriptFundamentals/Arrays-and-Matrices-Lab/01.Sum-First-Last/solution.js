function solve() {
  let inputText = $('#arr').val();
  let inputArr = JSON.parse(inputText);

  for (let i = 0; i < inputArr.length; i++) {
    let product = inputArr[i] * inputArr.length;
    let p = $('<p>').html(`${i} -> ${product}`);
    
    $('#result').append(p);
  }
}
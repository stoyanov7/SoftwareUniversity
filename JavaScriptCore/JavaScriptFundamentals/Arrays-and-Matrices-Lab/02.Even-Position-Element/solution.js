function solve() {
  let inputArr = $('#arr').val();
  let arr = JSON.parse(inputArr);
  let result = [];

  arr.forEach((element, index) => {
    if (index % 2 == 0) {
      result.push(element);
    }
  });

  $('#result').text(result.join(' x '));
}
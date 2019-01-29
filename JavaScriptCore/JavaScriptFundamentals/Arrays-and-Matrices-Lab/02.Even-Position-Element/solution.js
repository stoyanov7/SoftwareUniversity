function solve() {
  let inputArr = document.getElementById('arr').value;
  let arr = JSON.parse(inputArr);
  let result = [];

  arr.forEach((element, index) => {
    if (index % 2 == 0) {
      result.push(element);
    }
  });

  document.getElementById('result').textContent = result.join(' x ');
}
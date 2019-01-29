function solve() {
  let inputText = document.getElementById('arr').value;
  let inputArr = JSON.parse(inputText);

  inputArr.forEach((word, index, arr) => {
    arr[index] = word.split("").reverse().join("");
  });

  let result = inputArr.map(word => word[0].toUpperCase() + word.slice(1));
  
  document.getElementById('result').textContent = result.join(' ');
}
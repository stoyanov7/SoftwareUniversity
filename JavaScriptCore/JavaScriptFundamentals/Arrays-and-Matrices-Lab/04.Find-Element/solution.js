function solve() {
  let needle = parseInt(document.getElementById('num').value);
  let inputArray = document.getElementById('arr').value;
  let haystack = JSON.parse(inputArray);
  let result = [];

  haystack.forEach(element => {
    let hasValue = element.includes(needle);
    let index = element.indexOf(needle);

    result.push(`${hasValue} -> ${index}`);
  });

  document.getElementById('result').textContent = result.join(',')
}
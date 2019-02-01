function solve() {
  let input = document.getElementById('str1').value;
  let currentCase = document.getElementById('str2').value;
  let result = document.getElementById('result');

  let resultText = input
    .toLowerCase()
    .split(' ')
    .filter(x => x)
    .map(e => e.charAt(0).toUpperCase() + e.slice(1))
    .join('');

  if (currentCase != 'Camel Case' && currentCase != 'Pascal Case') {
    resultText = 'Error!';
  } else if (currentCase == 'Camel Case') {
    resultText = resultText.charAt(0).toLowerCase() + resultText.slice(1);
  }

  result.textContent = resultText;
}
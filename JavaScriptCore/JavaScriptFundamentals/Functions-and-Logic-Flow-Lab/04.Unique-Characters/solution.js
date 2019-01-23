function solve() {
  let uniquesChars = '';
  let string = document.getElementById('string').value;

  findUniqueChars(string)
  document.getElementById('result').innerHTML = uniquesChars;

  function isCharWhitespace(i) {
    if (string[i] === " ") {
      uniquesChars += string[i];
    }
  }

  function isCurrentCharUnique(i) {
    if (uniquesChars.indexOf(string[i]) === -1) {
      uniquesChars += string[i];
    }
  }

  function findUniqueChars(string) {
    for (let i = 0; i < string.length; i++) {
      isCharWhitespace(i);
      isCurrentCharUnique(i);
    }
  }
}
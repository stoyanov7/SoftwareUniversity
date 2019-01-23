function solve() {
  let sentence = document.getElementById('string').value.split('');
  let searchedCharacter = document.getElementById('character').value;
  let count = 0;

  findCharacter(sentence, searchedCharacter);
  document.getElementById('result').innerHTML = print(searchedCharacter);

  function findCharacter(string, char) {
    for (let i = 0; i < string.length; i++) {
      if (string[i] === char) {
          count++;
      }
    }
  }

  function print(char) {
    if (count % 2 === 0) {
      return `Count of ${char} is even.`;
    }
    else {
      return `Count of ${char} is odd.`
    }
  }
}
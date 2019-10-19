function solve() {
  let sentence = $('#string').val().split('');
  let searchedCharacter = $('#character').val();
  let count = 0;

  for (let i = 0; i < sentence.length; i++) {
    if (sentence[i] === searchedCharacter) {
      count++;
    }
  }

  $('#result').html(() => {
    if (count % 2 === 0) {
      return `Count of ${searchedCharacter} is even.`;
    } else {
      return `Count of ${searchedCharacter} is odd.`;
    }
  });
}
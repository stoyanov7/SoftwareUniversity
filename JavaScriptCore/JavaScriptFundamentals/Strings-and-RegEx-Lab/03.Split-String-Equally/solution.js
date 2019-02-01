function solve() {
  let input = document.getElementById('str').value;
  let n = +document.getElementById('num').value;

  splitStringEqually(input, n);

  function splitStringEqually(input, n) {
    let arr = [];
    let indexCounter = 0;

    if (input.length % n !== 0) {
      let len = input.length;
      let symbolsCount = 0;

      while (len % n !== 0) {
        len %= n;
        len++;
        symbolsCount++;
      }

      for (let i = 0; i < symbolsCount; i++) {
        input += input[indexCounter];
        indexCounter++;
      }
    }

    for (let i = 0; i < input.length; i += n) {
      arr.push(input.substr(i, n));
    }

    document.getElementById('result').innerHTML = arr.join(' ');
  }
}
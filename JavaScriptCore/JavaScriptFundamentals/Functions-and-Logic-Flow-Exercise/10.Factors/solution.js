function solve() {
   let number = +document.getElementById('num').value;

   document.getElementById('result').textContent = `${calculate(number).join(' ')}`;

   function calculate(num) {
      let result = [];

      for (let i = 0; i <= num; i++) {
         if (num % i === 0) {
            result.push(i);
         }
      }

      return result;
  }
}
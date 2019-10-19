function solve() {
   let number = Number($('#num').val());
   
   $('#result').text(`${calculate(number).join(' ')}`);

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
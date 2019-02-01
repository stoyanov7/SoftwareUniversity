function letterOccurences(string, letter) {
     let count = 0;
 
     for (let i = 0; i < string.length; i++) {
         if (string[i] == letter) {
             count++;
         }
     }
 
     console.log(count);
 }
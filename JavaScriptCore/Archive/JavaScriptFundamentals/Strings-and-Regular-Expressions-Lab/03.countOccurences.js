function countOccurences(targetString, text) {
     let count = 0;
     let index = text.indexOf(targetString);
 
     while (index !== -1) {
         index++;
         count++;
         index = text.indexOf(targetString, index);
     }
 
     return count;
 }
function matchAllWords(arr) {
     let regex = new RegExp(/\w+/g);
     let result = [];
     let match;
 
     while (match = regex.exec(arr)) {
         result.push(match);
     }
 
     console.log(result.join('|'));
 }
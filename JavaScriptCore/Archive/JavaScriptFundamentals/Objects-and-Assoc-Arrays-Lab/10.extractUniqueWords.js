function getUniqueWords(input) {
     let set = new Set();
     
      for (let i = 0; i < input.length; i++) {
         let currentWords = input[i]
             .toLowerCase()
             .split(/\W+/)
             .filter(x => x !== '');
  
         currentWords.forEach(x => set.add(x));
      }
  
      console.log(Array.from(set).join(", "));
  }
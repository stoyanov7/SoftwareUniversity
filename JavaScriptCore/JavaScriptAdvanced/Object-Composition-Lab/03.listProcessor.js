function solve(input) {
     let arr = [];

     let service = {
          add: (element) => arr.push(element),
          remove: (element) => arr = arr.filter(x => x !== element),
          print: () => console.log(arr.join(','))
     };

     for (let currentLine of input) {
          let tokens = currentLine.split(' ');
          service[tokens[0]](tokens[1]);
     }
}
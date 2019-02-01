function solve(input) {
     let arr = [];
     let biggest;

     input.forEach(function (e) {
          if (biggest != undefined) {
               if (e >= biggest) {
                    arr.push(e);
                    biggest = e;
               }
          }
          else {
               biggest = e;
               arr.push(e);
          }
     });

     arr.forEach(e => console.log(e));
}
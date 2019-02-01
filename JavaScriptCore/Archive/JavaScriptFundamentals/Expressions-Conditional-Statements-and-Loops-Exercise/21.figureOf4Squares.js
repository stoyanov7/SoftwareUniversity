function printFigure(num) {
     n = Number(num);
 
     let horizontal = n * 2 - 1;
     let vertical = (n % 2 === 0) ? n - 1 : n;
     let output = "";
 
     if (n <= 2) {
         for (let i = 0; i < 3; i++) {
             console.log("+".repeat(3));
         }
     }
     else {
         for (let row = 1; row <= vertical; row++) {
             for (let col = 1; col <= horizontal; col++) {
                 let printCol = col === 1 || col === n || col === horizontal;
 
                 if (row === 1 || row === Math.ceil(vertical / 2) || row === vertical) {
                     output += printCol ? "+" : "-";
                 }
                 else {
                     output += printCol ? "|" : " ";
                 }
             }
 
             output += "\n";
         }
     }
 
     console.log(output);
 }
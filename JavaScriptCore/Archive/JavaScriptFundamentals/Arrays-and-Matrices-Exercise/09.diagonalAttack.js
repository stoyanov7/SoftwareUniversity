function diagonalAttack(inputArr) {
     let matrix = [];

     for (let row = 0; row < inputArr.length; row++) {
          matrix[row] = inputArr[row].split(' ').map(Number);
     }

     let sumMainDiagonal = 0;
     let sumSecondaryDiagonal = 0;
     
     for (let row = 0; row < matrix.length; row++) {
          for (var col = 0; col < matrix.length; col++) {
               if (col == row) {
                    sumMainDiagonal += matrix[row][col];
               }

               if (row + col == matrix.length - 1) {
                    sumSecondaryDiagonal += matrix[row][col];
               }
          }
     }

     if (sumSecondaryDiagonal == sumMainDiagonal) {
          for (let row = 0; row < matrix.length; row++) {
               for (let col = 0; col < matrix.length; col++) {
                    if (col != row && row + col != matrix.length - 1) {
                         matrix[row][col] = sumMainDiagonal;
                    }
               }
          }
     }

     for (let row = 0; row < matrix.length; row++) {
          console.log(matrix[row].join(' '));
     }
}

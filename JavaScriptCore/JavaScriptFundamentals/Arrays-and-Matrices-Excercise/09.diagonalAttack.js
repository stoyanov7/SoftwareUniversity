function solve(array) {
    let matrix = fillMatrix(array);
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {
        firstDiagonal += matrix[row][row];
        secondDiagonal += matrix[row][matrix.length - 1 - row];
    }

    if (firstDiagonal === secondDiagonal) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (row !== col && col !== matrix.length - 1 - row) {
                    matrix[row][col] = firstDiagonal;
                }                
            }            
        }
    }

    for (let row of matrix) {
        console.log(row.join(' '));
    }

    function fillMatrix(array) {
        let matrix = [];
        for (let item of array) {
            let row = item.split(' ').map(x => Number(x));
            matrix.push(row);
        }

        return matrix;
    }
}
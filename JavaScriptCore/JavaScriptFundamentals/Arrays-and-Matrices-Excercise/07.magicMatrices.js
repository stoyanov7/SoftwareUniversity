function solve(matrix) {
    let rowSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        let currentRowSum = 0;

        for (let col = 0; col < matrix[row].length; col++) {
            currentRowSum += matrix[row][col];
        }

        if (row === 0) {
            rowSum = currentRowSum;
        } else if (rowSum !== currentRowSum) {
            return false;
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let colSum = 0;

        for (let row = 0; row < matrix.length; row++) {
            colSum += matrix[row][col];
        }

        if (colSum !== rowSum) {
            return false;
        }
    }

    return true;
}
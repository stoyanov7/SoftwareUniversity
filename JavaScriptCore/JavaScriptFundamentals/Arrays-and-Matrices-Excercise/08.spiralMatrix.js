function solve(rows, cols) {
    let matrix = fillMatrix(rows);

    let number = 1;
    let startRow = 0;
    let endRow = rows - 1;
    let startCol = 0;
    let endCol = cols - 1;

    while (startRow <= endRow || startCol <= endCol) {
        for (let i = startRow; i <= endRow; i++) {
            matrix[startRow][i] = number;
            number++;
        }

        for (let i = startRow + 1; i <= endRow; i++) {
            matrix[i][endCol] = number;
            number++;
        }

        for (let i = endCol - 1; i >= startCol; i--) {
            matrix[endRow][i] = number;
            number++;
        }

        for (let i = endRow - 1; i > startRow; i--) {
            matrix[i][startCol] = number;
            number++;
        }

        startRow++;
        endRow--;
        startCol++;
        endCol--;
    }

    for (let row of matrix) {
        console.log(row.join(' '));
    }

    function fillMatrix(rows) {
        let matrix = [];
        for (let row = 0; row < rows; row++) {
            matrix.push([]);
        }

        return matrix;
    }
}
function solve(input) {
    let rows = input[0], cols = input[1], x = input[2], y = input[3];
    let matrix = fillMatrix(rows);

    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - x), Math.abs(col - y)) + 1;
        }
    }
    
    printMatrix(matrix);

    function fillMatrix(rows) {
        let matrix = [];
        for (let row = 0; row < rows; row++) {
            matrix.push([]);
        }
        return matrix;
    }

    function printMatrix(matrix) {
        for (let line of matrix) {
            console.log(line.join(" "));
        }
    }
}
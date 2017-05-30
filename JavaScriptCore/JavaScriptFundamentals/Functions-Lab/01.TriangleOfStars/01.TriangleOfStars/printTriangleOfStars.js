function printTriangleOfStars(n) {
    n = Number(n);

    let topSide = function () {
        for (let row = 1; row <= n; row++) {
            let currentLine = '';

            for (let col = 1; col <= row; col++) {
                currentLine += '*';
            }

            console.log(currentLine);
        }
    }

    let bottomSide = function () {
        for (let row = n - 1; row >= 1; row--) {
            let currentLine = '';

            for (let col = row; col >= 1; col--) {
                currentLine += '*';
            }

            console.log(currentLine);
        }
    }

    topSide();
    bottomSide();
}
function printSquareOfStars(n) {
    n = Number(n);

    for (let row = 1; row <= n; row++) {
        let currentLine = '';

        for (let col = 1; col <= n; col++) {
            currentLine += '* ';
        }

        console.log(currentLine);
    }
}
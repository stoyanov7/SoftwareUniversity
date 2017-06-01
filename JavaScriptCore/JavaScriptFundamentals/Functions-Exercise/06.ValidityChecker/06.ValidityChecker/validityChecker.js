function validityChecker([x1, y1, x2, y2]) {
    let points = { x1: Number(x1), y1: Number(y1), x2: Number(x2), y2: Number(y2) };

    isValidPonts(points.x1, points.y1, 0, 0);
    isValidPonts(points.x2, points.y2, 0, 0);
    isValidPonts(points.x1, points.y1, points.x2, points.y2);

    function isValidPonts(x1, y1, x2, y2) {
        let sqrt = Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

        if (sqrt % 1 > 0) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
        }
        else {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
        }
    }
}
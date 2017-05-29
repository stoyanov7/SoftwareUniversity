function piointInRectangle(arr) {
    let [x, y, xMin, xMax, yMin, yMax] = arr.map(Number);

    console.log((x >= xMin && x <= xMax && y >= yMin && y <= yMax) ? 'inside' : 'outside');
}
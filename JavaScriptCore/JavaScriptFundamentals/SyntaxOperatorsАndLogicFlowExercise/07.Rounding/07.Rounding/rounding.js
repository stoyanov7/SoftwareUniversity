function rounding(arr) {
    let number = Number(arr[0]);
    let precision = Number(arr[1]);

    if (precision > 15) {
        precision = 15;
    }

    let result = number.toFixed(precision);
    result = parseFloat(result);
    console.log(result);
}
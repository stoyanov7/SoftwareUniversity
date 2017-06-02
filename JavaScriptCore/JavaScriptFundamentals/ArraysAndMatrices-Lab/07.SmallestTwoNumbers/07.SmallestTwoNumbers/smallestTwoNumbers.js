function smallestTwoNumbers(arr) {
    let result = arr.map(Number).sort((a, b) => a - b);
    return result[0] + ' ' + result[1];
}
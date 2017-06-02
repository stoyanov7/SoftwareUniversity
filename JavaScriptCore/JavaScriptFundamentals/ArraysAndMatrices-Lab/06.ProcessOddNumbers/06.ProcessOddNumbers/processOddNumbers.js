function processOddNumbers(arr) {
    arr = arr.map(Number);
    let oddArray = [];

    for (let i = 0; i < arr.length; i++) {
        if (i % 2 !== 0) {
            oddArray.push(arr[i] + arr[i]);
        }
    }

    oddArray.reverse();
    console.log(oddArray);
}
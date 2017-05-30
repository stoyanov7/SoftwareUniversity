function aggregateElements(arr) {
    arr = arr.map(Number);
    let sum = 0;
    let inverseSum = 0;
    let concatNumber = '';

    for (let i = 0; i < arr.length; i++) {
        sum += arr[i];
        inverseSum += 1 / arr[i];
        concatNumber += arr[i];
    }

    console.log(`${sum}\n${inverseSum}\n${concatNumber}`);
}
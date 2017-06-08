function printArray(arr) {
    let delimiter = arr[arr.length - 1];
    arr.pop();

    let result = ''; 

    for (let i = 0; i < arr.length; i++) {
        result += i === 0 ? arr[i] : delimiter + arr[i];
    }

    console.log(result);
}
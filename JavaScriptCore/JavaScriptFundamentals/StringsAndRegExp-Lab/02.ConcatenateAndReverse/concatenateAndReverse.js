function concatenateAndReverse(arr) {
    let concatArray = [];

    for (let i = 0; i < arr.length; i++) {
        concatArray += arr[i];
    }

    console.log(concatArray.split("")
        .reverse()
        .join(""));
}
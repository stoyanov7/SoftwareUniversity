function binaryLogarithm(arr) {
    for (let i = 0; i < arr.length; i++) {
        arr[i] = Number(arr[i]);
    }

    for (let j = 0; j < arr.length; j++) {
        let logarithm = Math.log2(arr[j]);
        console.log(logarithm);
    }
}
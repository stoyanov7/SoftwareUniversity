function lastKNumbersSequence(n, k) {
    let arr = [1];

    for (let i = 1; i < n; i++) {
        let sum = 0;

        for (let j = i - k; j <= i - 1; j++) {
            if (j >= 0) {
                sum += arr[j];
            }

            arr[i] = sum; 
        }
    }

    console.log(arr.join(" "));
}
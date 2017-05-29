function assignProperties(arr) {
    let firstElement = arr[0];
    let secondElement = arr[2];
    let thirdElement = arr[4];

    console.log({
        [firstElement]: arr[1],
        [secondElement]: arr[3],
        [thirdElement]: arr[5]
    });
}
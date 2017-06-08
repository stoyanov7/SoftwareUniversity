function rotateArray(arr) {
    let rotateCount = Number(arr.pop());
    rotateCount %= arr.length;

    for (let i = 0; i < rotateCount; i++) {
        let currentElement = arr.pop();
        arr.unshift(currentElement);
    }

    console.log(arr.join(' '));
}
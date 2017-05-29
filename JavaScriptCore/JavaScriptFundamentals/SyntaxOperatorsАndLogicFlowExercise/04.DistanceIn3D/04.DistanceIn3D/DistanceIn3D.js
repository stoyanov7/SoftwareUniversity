function calculateDistanceIn3D(arr) {
    for (let i = 0; i < arr.length; i++) {
        arr[i] = Number(arr[i]);
    }

    let firstPoint = { x1: arr[0], y1: arr[1], z1: arr[2] };
    let secondPoint = { x2: arr[3], y2: arr[4], z2: arr[5] };

    let result = Math.sqrt(
        (secondPoint.x2 - firstPoint.x1) * (secondPoint.x2 - firstPoint.x1) +
        (secondPoint.y2 - firstPoint.y1) * (secondPoint.y2 - firstPoint.y1) +
        (secondPoint.z2 - firstPoint.z1) * (secondPoint.z2 - firstPoint.z1)
    );

    console.log(result);
}
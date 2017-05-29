function calcDistance([firstSpeed, secondSpeed, time]) {
    firstSpeed = Number(firstSpeed);
    secondSpeed = Number(secondSpeed);
    time = Number(time);

    firstSpeed *= (1000 / 1) * (1 / 60) * (1 / 60);
    secondSpeed *= (1000 / 1) * (1 / 60) * (1 / 60);
    let firstDistance = firstSpeed * time;
    let secondDistance = secondSpeed * time;
    let distance = Math.abs(firstDistance - secondDistance);

    console.log(distance);
}
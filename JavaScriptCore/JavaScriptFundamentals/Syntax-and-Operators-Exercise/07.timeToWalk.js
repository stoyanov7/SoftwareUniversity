function solve(steps, footLength, speed) {
    let distance = steps * footLength;
    let distanceKm = distance / 1000;
    let relaxInMins = Math.floor(distance / 500);
    let timeInSeconds = Math.ceil((distanceKm / speed) * 60 * 60) + (relaxInMins * 60);

    let hours = Math.floor(timeInSeconds / 3600);
    let mins = Math.floor(timeInSeconds / 60);
    timeInSeconds -= mins * 60;

    var totalTime = ('0' + hours).slice(-2) + ':' + ('0' + mins).slice(-2) + ':' + ('0' + timeInSeconds).slice(-2);

    console.log(totalTime);
}
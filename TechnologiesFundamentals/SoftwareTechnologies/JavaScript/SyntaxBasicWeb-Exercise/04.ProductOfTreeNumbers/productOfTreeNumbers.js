function solve(args) {
    let firstNum = Number(args[0]);
    let secondNum = Number(args[1]);
    let thirdNum = Number(args[2]);
    let numbers = [firstNum, secondNum, thirdNum];

    let negativeCount = 0;

    numbers.forEach(function (element) {
        if (element < 0) {
            negativeCount++;
        }
        if (element == 0) {
            console.log("Positive");
        }
    });

    if (negativeCount % 2 == 0) {
        console.log("Positive");
    } else {
        console.log("Negative");
    }
}
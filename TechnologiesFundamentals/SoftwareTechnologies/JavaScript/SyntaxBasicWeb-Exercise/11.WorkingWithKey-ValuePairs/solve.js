function solve(args) {
    let numbers = [];

    for (let i = 0; i < args.length - 1; i++) {
        let pair = args[i].split(' ');
        let command = pair[0];
        numbers[command] = pair[1];
    }

    let key = args[args.length - 1];

    if (numbers[key] === undefined) {
        console.log("None");
    }
    else {
        console.log(numbers[key]);
    }
}
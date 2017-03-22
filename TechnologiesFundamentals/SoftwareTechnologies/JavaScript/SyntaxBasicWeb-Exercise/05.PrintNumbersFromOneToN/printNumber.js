function solve(args) {
    let n = Number(args[0]);

    for (let i = 1; i <= n; i++) {
        let isPrime = true;

        for (let divisor = 2; divisor < i; divisor++) {
            if (i % divisor === 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime) {
            console.log(i + ' ');
        }
    }
}
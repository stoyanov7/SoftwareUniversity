function solve(args) {
    let n = Number(args[0]);
    let x = Number(args[1]);

    if (x >= n) {
        return n * x;
    }

    if (n > x) {
        return n / x;
    }
}
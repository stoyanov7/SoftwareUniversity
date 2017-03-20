function solve(args) {
    args = args[0].split(' ').map(Number);

    function checkForSum(first, second, sum) {
        if (first + second !== sum) {
            return false;
        }
        if (first > second) {
            [first, second] = [second, first];
        }

        return `${first} + ${second} = ${sum}`;
    }

    console.log(
        checkForSum(args[0], args[1], args[2]) ||
        checkForSum(args[1], args[2], args[0]) ||
        checkForSum(args[0], args[2], args[1]) ||
        "No"
    );
}
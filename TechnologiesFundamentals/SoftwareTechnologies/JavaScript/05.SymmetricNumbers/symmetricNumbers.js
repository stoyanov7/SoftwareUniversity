function solve(args) {
    let n = Number(args[0]);
    let result = '';

    for (let i = 1; i < n; i++) {
        if (isSymmetric(i)) {
            result += i + ' ';
        }
    }

    console.log(result);
    
    function isSymmetric(number) {
        number = number.toString();
        let length = number.length;

        for (let i = 0; i < Math.floor(length / 2); i++) {
            if (number[i] !== number[length - i - 1]) {
                return false;
            }
        }

        return true;
    }
}
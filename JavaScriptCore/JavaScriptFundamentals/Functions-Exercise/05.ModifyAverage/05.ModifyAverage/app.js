function modifyAverages(number) {
    while (sumNubers(number) / number.length <= 5) {
        number += '9';
    }

    function sumNubers(n) {
        let sum = 0; 

        for (let i = 0; i < n.length; i++) {
            sum += Number(n[i]);
        }

        return sum;
    }

    console.log(number);
}
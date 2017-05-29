function calculateSumAndVAT(input) {
    let sum = 0;

    for (let i = 0; i < input.length; i++) {
        sum += Number(input[i]);
    }

    let vat = sum * 0.2;
    let total = sum + vat;

    console.log("sum = " + sum);
    console.log("vat = " + vat);
    console.log("total = " + total);
}
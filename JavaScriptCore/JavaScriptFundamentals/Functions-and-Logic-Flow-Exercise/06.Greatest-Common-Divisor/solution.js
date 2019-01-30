function greatestCD() {
    let number1 = +document.getElementById('num1').value;
    let number2 = +document.getElementById('num2').value;

    document.getElementById('result').innerHTML = gcd(number1, number2);

    function gcd(a, b) {
        if (!b) {
            return a;
        }
    
        return gcd(b, a % b);
    };
}
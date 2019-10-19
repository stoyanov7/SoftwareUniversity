function greatestCD() {
    let number1 = Number($('#num1').val());
    let number2 = Number($('#num2').val());

    $('#result').html(gcd(number1, number2));

    function gcd(a, b) {
        if (!b) {
            return a;
        }
    
        return gcd(b, a % b);
    };
}
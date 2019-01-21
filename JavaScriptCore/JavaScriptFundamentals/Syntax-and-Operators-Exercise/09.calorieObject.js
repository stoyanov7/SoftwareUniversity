function solve(arr) {
    let output = '{';
    
    arr.forEach(function (value, index) {
        if (index % 2 == 0) {
            output += ' ' + value + ': ';
        } 
        else {
            if (index == arr.length - 1) {
                output += value;
            }
            else {
                output += value + ',';
            }
        }
    });

    output += ' }'
    console.log(output);
}
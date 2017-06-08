function addAndRemoveElements(arr) {
    let number = 1;
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        if (arr[i]=== 'add'){
            result.push(number);
        }
        else {
            result.pop();
        }

        number++;
    }

    if(result.length === 0){
        console.log('Empty');
        return;
    }

    console.log(result.join('\n'));
}
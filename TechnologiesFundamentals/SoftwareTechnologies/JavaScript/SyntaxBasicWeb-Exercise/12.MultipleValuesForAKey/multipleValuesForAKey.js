function solve(args){
    let input = [];
    let duplicateEntry = args[args.length-1];

    for (let i = 0; i < args.length - 1; i++) {
        let token = args[i].split(' ');
        let command = token[0];
        input[command] = token[1];

        if (duplicateEntry === command) {
            console.log(input[command]);
        }
    }

    if(duplicateEntry in input){

    }
    else{
        console.log("None")
    }
}
function solve(args) {
    for (let i = 0; i < args.length; i++)
    {
        let tokens = args[i].split(" -> ");
        let object = {
            name: tokens[0],
            age: tokens[1],
            grade: tokens[2]
        };

        console.log(`Name: ${object.name}`);
        console.log(`Age: ${object.age}`);
        console.log(`Grade: ${object.grade}`);
    }
}
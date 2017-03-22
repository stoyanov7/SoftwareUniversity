function solve(args) {
    let objects = args.map(JSON.parse);

    for(let object of objects)
    {
        console.log(`Name: ${object.name}`);
        console.log(`Age: ${object.age}`);
        console.log(`Date: ${object.date}`);
    }
}
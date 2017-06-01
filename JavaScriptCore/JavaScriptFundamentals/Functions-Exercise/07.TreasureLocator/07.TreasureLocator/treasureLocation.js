function treasureLocation(coordinates) {
    coordinates = coordinates.map(Number);
    let treasures = ``;

    for (let i = 0; i < coordinates.length; i += 2) {
        let x = coordinates[i];
        let y = coordinates[i + 1];

        if (x >= 1 && x <= 3 && y >= 1 && y <= 3) {
            treasures += `Tuvalu\n`;
        }
        else if (x >= 8 && x <= 9 && y >= 0 && y <= 1) {
            treasures += `Tokelau\n`;
        }
        else if (x >= 5 && x <= 7 && y >= 3 && y <= 6) {
            treasures += `Samoa\n`;
        }
        else if (x >= 0 && x <= 2 && y >= 6 && y <= 8) {
            treasures += `Tonga\n`;
        }
        else if (x >= 4 && x <= 9 && y >= 7 && y <= 8) {
            treasures += `Cook\n`;
        }
        else {
            treasures += `On the bottom of the ocean\n`;
        }
    }

    console.log(treasures);
}
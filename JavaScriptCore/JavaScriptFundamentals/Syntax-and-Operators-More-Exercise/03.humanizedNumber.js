function solve(text) {
    const regex = /[0-9]+/gm;
    let m;
    let suffix;

    while ((m = regex.exec(text)) !== null) {
        if (m.index === regex.lastIndex) {
            regex.lastIndex++;
        }

        m.forEach((match, groupIndex) => {
            let num = match > 20 ? match % 10 : Number(match);

            switch (num) {
                case 1:
                    suffix = 'st';
                    break;
                case 2:
                    suffix = 'nd';
                    break;
                case 3:
                    suffix = 'rd';
                    break;
                default:
                    suffix = 'th';
                    break;
            }
            
            console.log(`${match}${suffix}`)
        });
    }
}
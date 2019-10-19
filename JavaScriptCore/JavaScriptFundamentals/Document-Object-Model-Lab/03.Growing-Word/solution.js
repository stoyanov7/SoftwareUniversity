function solve() {
    let paragraph = document.querySelectorAll('p')[2];
    var clicks = 0;

    $('button').click(() => {
        clicks += 1;

        let paragraphColor = paragraph.style.color;
        paragraph.style.fontSize = clicks * 2 + 'px';

        switch (paragraphColor) {
            case 'blue':
                newColor = 'green';
                break;
            case 'green':
                newColor = 'red';
                break;
            default:
                newColor = 'blue';
                break;
        }

        paragraph.style.color = newColor;
    });
}
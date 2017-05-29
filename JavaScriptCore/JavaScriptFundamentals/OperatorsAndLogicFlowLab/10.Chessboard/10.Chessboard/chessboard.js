function chessboard(n) {
    console.log('<div class="chessboard">');

    for (let i = 0; i < n; i++) {
        console.log('   <div>');

        for (let j = 0; j < n; j++) {
            let blackOrWhite = (i + j) % 2 == 0 ? 'black' : 'white';
            console.log(`       <span class="${blackOrWhite}"></span>`);
        }
        console.log('   </div>');
    }

    console.log('</div>');
}
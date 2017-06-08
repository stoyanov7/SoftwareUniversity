function chessboard(n) {
    let html = '<div class="chessboard">';

    for (let row = 0; row < n; row++) {
        html+= '   <div>';

        for (let col = 0; col < n; col++) {
            let blackOrWhite = (row + col) % 2 == 0 ? 'black' : 'white';
            html+= `       <span class="${blackOrWhite}"></span>`;
        }

        html += '   </div>';
    }

    html += '</div>';

    return html;
}
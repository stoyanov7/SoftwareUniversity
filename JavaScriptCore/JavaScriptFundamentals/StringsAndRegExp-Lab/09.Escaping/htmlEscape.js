function htmlEscape(input) {
    let html = `<ul>\n`;

    for (let i = 0; i < input.length; i++) {
        html += `    <li>`;
        html += escapeHtml(input[i]);
        html += `</li>\n`;
    }
    html += `</ul>`;

    function escapeHtml(text) {
        return text
            .replace(/&/g, '&amp;')
            .replace(/>/g, '&gt;')
            .replace(/</g, '&lt;')
            .replace(/"/g, '&quot;');
    }

    document.write(html);
}
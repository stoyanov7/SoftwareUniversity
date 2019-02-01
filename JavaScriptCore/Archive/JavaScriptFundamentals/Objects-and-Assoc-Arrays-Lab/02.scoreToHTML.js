function scoreToHTML(arr) {
     let html = '<table>\n';
     html += '   <tr><th>name</th><th>score</th></tr>\n';
     let scores = JSON.parse(arr);
 
     for (let score of scores) {
         html += '   <tr>';
         html += `<td>${escapeHtml(score.name)}</td>`;
         html += `<td>${score.score}</td></tr>\n`;
     }
 
     html += '</table>';
 
     console.log(html);
 
     function escapeHtml(text) {
         return text
             .replace(/&/g, '&amp;')
             .replace(/>/g, '&gt;')
             .replace(/</g, '&lt;')
             .replace(/"/g, '&quot;')
             .replace(/'/g, '&#39;');
     }
 }
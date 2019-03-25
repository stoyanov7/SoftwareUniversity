function extractText() {
   let extractedText = $('#items li')
      .toArray()
      .map(x => x.textContent)
      .join(', ');

   $('#result')
      .text(extractedText);
}
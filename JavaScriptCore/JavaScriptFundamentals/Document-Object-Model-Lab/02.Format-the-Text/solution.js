function solve() {
  let inputText = $('#input').text().split('.');

  for (let i = 0; i < inputText.length; i+= 3) {
    let paragraph = document.createElement('p');
    paragraph.textContent = inputText[i];   

    if (inputText.length > i + 1) {
      paragraph.textContent += '. ' + inputText[i];
    }

    if (inputText.length > i + 2) {
      paragraph.textContent += '. ' + inputText[i + 2];
    }
    
    $('#output').append(paragraph);
  }  
}
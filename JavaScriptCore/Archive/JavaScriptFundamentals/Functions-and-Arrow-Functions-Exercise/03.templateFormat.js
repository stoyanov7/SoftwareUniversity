function templateFormat(arr) {
     let result = `<?xml version="1.0" encoding="UTF-8"?>\n`;
     result += `<quiz>\n`;
 
     for (let i = 0; i < arr.length; i+= 2) { 
         result += `\t<question>\n`;
         result += `\t\t${arr[i]}\n`;
         result += `\t</question>\n`;
         result += `\t<answer>\n`;
         result += `\t\t${arr[i + 1]}\n`;
         result += `\t</answer>\n`;
 
     }
 
     result += `</quiz>\n`;
 
     console.log(result);
 }
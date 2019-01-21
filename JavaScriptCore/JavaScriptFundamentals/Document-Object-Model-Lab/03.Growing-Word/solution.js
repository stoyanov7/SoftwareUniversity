function solve() {
   let button = document.querySelector('button');
   let paragraph = document.querySelectorAll('p')[2];

   var clicks = 0;

   button.addEventListener('click', change);

   function change() {
       clicks += 1;
       
       paragraphColor = paragraph.style.color;
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
   }
}
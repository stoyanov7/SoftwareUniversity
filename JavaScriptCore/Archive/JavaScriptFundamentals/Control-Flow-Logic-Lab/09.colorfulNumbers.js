function colorfulNumbers(n) {
     n = Number(n);
 
     console.log('<ul>');
    
     for (let i = 1; i <= n; i++) {
         let blueOrGreen = i % 2 == 0 ? 'blue' : 'green';
         console.log(`   <li><span style='color:${blueOrGreen}'>${i}</span></li>`);
     }
 
     console.log('</ul>');
 }
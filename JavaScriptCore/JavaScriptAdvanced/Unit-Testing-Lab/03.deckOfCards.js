function solve(cards) {
     function makeCard(face, suit) {
          let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

          let suits = {
               'S': '\u2660',
               'H': '\u2665',
               'D': '\u2666',
               'C': '\u2663'
          };

          if (!faces.includes(face)) {
               throw new Error(`${face}${suit}`);
          }

          if (!suits.hasOwnProperty(suit)) {
               throw new Error(`${face}${suit}`);
          }

          return `${face}${suits[suit]}`;
     }

     try {
          let result = cards.map(x => {
               let c = x.split('');
               let s = c.pop();

               return makeCard(c.join(''), s);
          });

          console.log(result.join(' '));
     } catch (error) {
          console.log(`Invalid card: ${error.message}`);
     }
}
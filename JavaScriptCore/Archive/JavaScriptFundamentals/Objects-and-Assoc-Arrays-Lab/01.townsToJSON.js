function townsToJSON(arr) {
     arr.shift();
     let towns = [];
 
     for (let row of arr) {
         let townTokens = row.split('|')
             .filter(e => e !== '')
             .map(e => e.trim());
 
         let town = {
             Town: townTokens[0],
             Latitude: Number(townTokens[1]),
             Longitude: Number(townTokens[2])
         };
 
         towns.push(town);
     }
 
     return JSON.stringify(towns);
 }
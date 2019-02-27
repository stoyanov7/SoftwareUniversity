function solve(person) {
     if (person.hasOwnProperty('handsShaking') && person['handsShaking']) {
          person['bloodAlcoholLevel'] += 0.1 * person['weight'] * person['experience'];
          person['handsShaking'] = false;
     }

     return person;
}
class Rat {
     constructor(name) {
          this.name = name;
          this.uniteRats = [];
     }

     /**
      * Add the object if it is an object of the class Rat.
      * @param {*} otherRat 
      */
     unite(otherRat) {
          if (otherRat.constructor === Rat) {
               this.uniteRats.push(otherRat);
          }
     }

     /**
      * Returns all the rats it has united to, in a list.
      */
     getRats() {
          return this.uniteRats;
     }

     /**
      * Returns a string representation of the object
      * and all of the objects its united with,
      * each on a new line. 
      */
     toString() {
          let result = this.name + '\n';

          for (let rat of this.uniteRats) {
               result += `##${rat.name}\n`;
          }

          return result;
     }
}
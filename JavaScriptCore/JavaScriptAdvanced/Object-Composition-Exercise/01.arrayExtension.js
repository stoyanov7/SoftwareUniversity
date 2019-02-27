(() => {
     /**
      * Returns the last element of the array.
      */
     Array.prototype.last = function() {
          return this[this.length - 1];
     };

     /**
      * Returns a new array which includes all original elements,
      * except the first n elements.
      */
     Array.prototype.skip = function(n) {
          let result = [];

          for (let i = n; i < this.length; i++) {
               result.push(this[i]);
          }

          return result;
     };

     /**
      * Returns a new array containing 
      * the first n elements from the original array.
      */
     Array.prototype.take = function(n) {
          let result = [];

          for (let i = 0; i < n; i++) {
               result.push(this[i]);
          }

          return result;
     };

     /**
      * Returns a sum of all array elements.
      */
     Array.prototype.sum = function() {
          let result = 0;

          for (let i = 0; i < this.length; i++) {
               result += this[i];
          }

          return result;
     };

     /**
      * Returns the average of all array elements.
      */
     Array.prototype.average = function() {
          return this.sum() / this.length;
     };
})();
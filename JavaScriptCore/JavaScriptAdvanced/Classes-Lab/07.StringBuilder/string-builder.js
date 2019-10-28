class StringBuilder {
     constructor(string) {
          if (string !== undefined) {
               StringBuilder._vrfyParam(string);
               this._stringArray = Array.from(string);
          } else {
               this._stringArray = [];
          }
     }

     /**
      * Converts the passed in string argument to an array and adds it to the end of the storage
      * @param {*} string 
      */
     append(string) {
          StringBuilder._vrfyParam(string);
          for (let i = 0; i < string.length; i++) {
               this._stringArray.push(string[i]);
          }
     }

     /**
      * Converts the passed in string argument to an array and adds it to the beginning of the storage
      * @param {*} string 
      */
     prepend(string) {
          StringBuilder._vrfyParam(string);
          for (let i = string.length - 1; i >= 0; i--) {
               this._stringArray.unshift(string[i]);
          }
     }

     /**
      * Converts the passed in string argument to an array and adds it at the given index 
      * @param {*} string 
      * @param {*} startIndex 
      */
     insertAt(string, startIndex) {
          StringBuilder._vrfyParam(string);
          this._stringArray.splice(startIndex, 0, ...string);
     }

     /**
      * Removes elements from the storage, starting at the given index (inclusive), length number of characters 
      * @param {*} startIndex 
      * @param {*} length 
      */
     remove(startIndex, length) {
          this._stringArray.splice(startIndex, length);
     }

     static _vrfyParam(param) {
          if (typeof param !== 'string') {
               throw new TypeError('Argument must be string');
          }
     }

     /**
      * Returns a string with all elements joined by an empty string
      */
     toString() {
          return this._stringArray.join('');
     }
}

module.exports = StringBuilder;
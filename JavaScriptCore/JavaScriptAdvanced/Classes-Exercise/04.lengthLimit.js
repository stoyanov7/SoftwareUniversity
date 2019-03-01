class Stringer {
     constructor(innerString, innerLength) {
          this._innerString = innerString;
          this._innerLength = innerLength;
     }

     increase(length) {
          this._innerLength += length;
     }

     decrease(length) {
          this._innerLength -= length;

          if (this._innerLength < 0) {
               this._innerLength = 0;
          }
     }

     /**
      * Returns the string, the object was initialized with.
      */
     toString() {
          if (this._innerLength < this._innerString.length) {
               return this._innerString.slice(0, this._innerLength) + '...';
          }

          return this._innerString.slice(0, this._innerLength);
     }
}
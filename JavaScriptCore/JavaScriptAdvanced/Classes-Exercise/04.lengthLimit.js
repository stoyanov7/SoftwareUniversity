class Stringer {
     constructor(innerString, innerLength) {
          this.innerString = innerString;
          this.innerLength = innerLength;
     }

     increase(length) {
          this.innerLength += length;
     }

     decrease(length) {
          this.innerLength -= length;

          if (this.innerLength < 0) {
               this.innerLength = 0;
          }
     }

     /**
      * Returns the string, the object was initialized with.
      */
     toString() {
          if (this.innerLength < this.innerString.length) {
               return this.innerString.slice(0, this.innerLength) + '...';
          }

          return this.innerString.slice(0, this.innerLength);
     }
}
/**
 * Collection, which keeps a list of numbers,
 * sorted in ascending order.
 */
class SortedList {
     constructor() {
          this._arr = [];
          this._size = 0;
     }

     /**
      * Adds a new element to the collection.
      * @param {*} element Element to add.
      */
     add(element) {
          this._arr.push(element);
          this._arr.sort((a, b) => a - b);
          this._size++;

          return this._arr;
     }

     /**
      * Removes the element at position index.
      * @param {*} index Index for removing.
      */
     remove(index) {
          if (index >= 0 && index < this._arr.length) {
               this._arr.splice(index, 1);
               this._arr.sort((a, b) => a - b);
               this._size--;

               return this._arr;
          }
     }

     /**
      * Returns the value of the element at position index.
      * @param {*} index Position index.
      */
     get(index) {
          if (index >= 0 && index < this._arr.length) {
               return this._arr[index];
          }
     }
}
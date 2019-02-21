/**
 * Collection, which keeps a list of numbers,
 * sorted in ascending order.
 */
class SortedList {
     constructor() {
          this.arr = [];
          this.size = 0;
     }

     /**
      * Adds a new element to the collection.
      * @param {*} element Element to add.
      */
     add(element) {
          this.arr.push(element);
          this.arr.sort((a, b) => a - b);
          this.size++;

          return this.arr;
     }

     /**
      * Removes the element at position index.
      * @param {*} index Index for removing.
      */
     remove(index) {
          if (index >= 0 && index < this.arr.length) {
               this.arr.splice(index, 1);
               this.arr.sort((a, b) => a - b);
               this.size--;

               return this.arr;
          }
     }

     /**
      * Returns the value of the element at position index.
      * @param {*} index Position index.
      */
     get(index) {
          if (index >= 0 && index < this.arr.length) {
               return this.arr[index];
          }
     }
}
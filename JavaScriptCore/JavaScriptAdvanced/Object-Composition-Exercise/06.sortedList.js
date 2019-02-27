(function () {
     let list = [];
     let sort = (() => list.sort((a, b) => a - b));

     return {
          /**
           * Adds a new element to the collection.
           * @param {*} element element to add.
           */
          add: (element) => {
               list.push(element);
               sort();
               this.size++;
          },
          /**
           * Removes the element at position index.
           * @param {*} index positon index.
           */
          remove: (index) => {
               if (index >= 0 && index < list.length) {
                    list.splice(index, 1);
                    sort();
                    this.size--;
               }
          },
          /**
           * Returns the value of the element at position index.
           * @param {*} index position index.
           */
          get: (index) => {
               if (index >= 0 && index < list.length) {
                    return list[index];
               }
          },
          size: 0
     };
})();
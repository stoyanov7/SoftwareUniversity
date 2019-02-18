const assert = require('chai').assert;
const sum = require('./solution');

describe('sum', () => {
     it('with valid array, should return correct result', () => {
          // Arrange
          let arr = [1, 2];

          // Act
          let result = sum(arr);

          // Assert
          assert.equal(result, 3);
     });

     it('array with one element, should return element', () => {
          // Arrange
          let arr = [1];

          // Act
          let result = sum(arr);

          // Assert
          assert.equal(result, 1);
     });

     it('with empty array, should return 0', () => {
          // Arrange
          let arr = [];

          // Act
          let result = sum(arr);

          // Assert
          assert.equal(result, 0);
     });
});
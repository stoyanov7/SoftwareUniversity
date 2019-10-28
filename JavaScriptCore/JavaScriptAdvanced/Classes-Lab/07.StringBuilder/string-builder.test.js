const StringBuilder = require('./string-builder');
const expect = require('chai').expect;

describe('String builder test', function () {
     let sb;

     beforeEach(function() {
          sb = new StringBuilder();
     });

     describe('constructor test', function() {
          it ('is initialized without params', function() {
               expect(sb._stringArray.join('')).to.be.equal('');
          });

          it ('is initialized with params', function() {
               // Arrange
               sb = new StringBuilder('Test');
               const expected = 'Test';

               // Assert
               expect(sb._stringArray.join('')).to.be.equal(expected);
          });
     });

     describe('prepend test', function () {
          it ('is initialized with wrong parameter type', function() {
               // Act
               const errorFunc = () => {
                    sb.prepend({ name: 'Pesho' });
               };

               // Assert
               expect(errorFunc).to.throw(TypeError);
          });

          it ('is initialized with valid data', function() {
               // Arrange
               const expected = 'Test123';

               // Act
               sb.prepend('Test123');

               expect(sb._stringArray.join('')).to.be.equal(expected);
          });
     });
});
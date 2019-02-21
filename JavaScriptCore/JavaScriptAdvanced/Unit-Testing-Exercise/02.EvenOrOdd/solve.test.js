let expect = require('chai').expect;
const isOddOrEven = require('../02.EvenOrOdd');

describe('isOddOrEven', () => {
     it('with number parameter, should return undefined', () => {
          expect(isOddOrEven(13)).to.equal(undefined, 'Function did not return the right result!');
     });

     it('with object parameter, should return undefined', () => {
          expect(isOddOrEven({ name: "Test" })).should.equal(undefined, 'Function did not return the right result!');
     });

     it('with odd parameter, should return odd', () => {
          expect(isOddOrEven("odd str")).to.equal("odd");
     });

     it('with even parameter, should return even', () => {
          expect(isOddOrEven("even str")).to.equal("even");
     });
});
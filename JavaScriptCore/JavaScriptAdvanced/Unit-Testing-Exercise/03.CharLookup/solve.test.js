let expect = require('chai').expect;
const lookupChar = require('../03.CharLookup');

describe('lookupChar', () => {
     it('with a non-string first parameter, should return undefined', () => {
          expect(lookupChar(13, 0)).to.equal(undefined, 'The function did not return the correct result!');
     });

     it('with a non-number second parameter, should return undefined', () => {
          expect(lookupChar("pesho", "gosho")).to.equal(undefined, 'The function did not return the correct result!');
     });

     it('with a floating-point second parameter, should return undefined', () => {
          expect(lookupChar("pesho", 17.7)).to.equal(undefined, 'The function did not return the correct result!');
     });

     it('with an incorect index value, should return incorect index', () => {
          expect(lookupChar('gosho', 13)).to.equal('Incorrect index', 'The function did not return the correct result!');
     });

     it('with a negative index value, should return incorect index', () => {
          expect(lookupChar('stamat', -1)).to.equal('Incorrect index', 'The function did not return the correct result!');
     });

     it ('with an idex value equal to string length, should return incorrect index', () => {
          expect(lookupChar('pesho', 5)).to.equal('Incorrect index', 'The function did not return the correct result!');
     });

     it('with correct parameters, should return correct value', () => {
          expect(lookupChar('pesho', 0)).to.equal('p', 'The function did not return the correct result!');
     });

     it('with correct parameters, should return correct value', () => {
          expect(lookupChar('stamat', 3)).to.equal('m', 'The function did not return the correct result!');
     });
});
let expect = require('chai').expect;
const mathEnforcer = require('../04.MathEnforcer');

describe('mathEnorcer', () => {
     describe('addFive', () => {
          it('with non-number parameter, should return correct result', () => {
               expect(mathEnforcer.addFive(10)).to.equal(15);
          });

          it('with negative number parameter, should return correct result', () => {
               expect(mathEnforcer.addFive(-10)).to.equal(-5);
          });

          it('with string parameter, should return undefined', () => {
               expect(mathEnforcer.addFive('5')).to.be.undefined;
          });
     });

     describe('subtractTen', () => {
          it('with a non-number parameter, should return correct result', () => {
               expect(mathEnforcer.subtractTen(20)).to.equal(10);
          });

          it('with negative number parameter, should return correct result', () => {
               expect(mathEnforcer.subtractTen(-20)).to.equal(-30);
          });

          it('with list parameter, should return undefined', () => {
               expect(mathEnforcer.subtractTen([])).to.be.undefined;
          });

          it('with string parameter, should return undefined', () => {
               expect(mathEnforcer.subtractTen('10')).to.be.undefined;
          });
     });

     describe('sum', () => {
          it('with a non-number parameter, should return correct result', () => {
               expect(mathEnforcer.sum(20, 20)).to.equal(40);
          });

          it('with floating-point number parameter, should return correct result', () => {
               expect(mathEnforcer.sum(1.5, 1.5)).to.equal(3);
          });

          it('with floating-point number parameter, should return correct result', () => {
               expect(mathEnforcer.sum(-1.5, 1.5)).to.equal(0);
          });

          it('with first parameter string, should return undefined', () => {
               expect(mathEnforcer.sum('10', 2)).to.be.undefined;
          });

          it('with second parameter string, should return undefined', () => {
               expect(mathEnforcer.sum(2, '10')).to.be.undefined;
          });

          it('with string parameters, should return', () => {
               expect(mathEnforcer.sum('10', '10')).to.be.undefined;
          });

          it('with object parameters, should return undefined', () => {
               expect(mathEnforcer.sum({}, {})).to.be.undefined;
          });
     });
});
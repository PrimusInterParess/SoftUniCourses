let {sum} = require('./sum-func');
const { expect } = require('chai');

describe('Sum checker', () => {
    it('works', () => {
        expect(sum([1, 2, 3]) ).to.equal(6,'fuck you');
    })

    it('works', () => {
        expect(sum([1, 2, 3]) ).not.to.equal(4,'fuck you');
    })
});

// it('works with symetric numeric array', () => {
//     expect(isSymmetric([1, 2, 2, 1])).to.be.true;
// })
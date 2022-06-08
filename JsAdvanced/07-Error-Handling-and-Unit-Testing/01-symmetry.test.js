const { expect } = require('chai');

const { isSymmetric } = require('./01-symetry');

describe('Symmetry checker', () => {
    it('works with symetric numeric array', () => {
        expect(isSymmetric([1, 2, 2, 1])).to.be.true;
    })

    it('returns false with non-symetric numeric array legth', () => {
        expect(isSymmetric([1, 2, 2])).to.be.false;
    })

    it('returns false with non-symetric numeric array values', () => {
        expect(isSymmetric([1, 2, 2, 2])).to.be.false;
    })

    it('returns falss with non-array', () => {
        expect(isSymmetric(5)).to.be.false;
    })
});
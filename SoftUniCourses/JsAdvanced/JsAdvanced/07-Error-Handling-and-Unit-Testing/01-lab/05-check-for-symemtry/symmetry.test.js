let { expect } = require('chai');

let { isSymmetric } = require('./symetryFunc');

describe('Symmetry checker', () => {
    it('does not work with non array input', () => {
        expect(isSymmetric('fuck you')).false;
    })

    it('does not work with non-symmetry array input', () => {
        expect(isSymmetric([1, 2, 3, 3])).false;
    })

    it('does not work with odd array length', () => {
        expect(isSymmetric([1, 2, 3])).false;
    })

    it('works with symemetric array data', () => {
        expect(isSymmetric([1, 2, 2, 1])).true;
    })

    it('works with symemetric array data', () => {
        expect(isSymmetric([1, 2, 1])).true;
    })

    
    it('works with symemetric array data', () => {
        expect(isSymmetric(['1','2', '2', '1'])).true;
    })

    it('does not work with not iniform array data', () => {
        expect(isSymmetric([1, 2, 'd', 1])).false;
    })

    it(' works with array with one element', () => {
        expect(isSymmetric([1])).true;
    })

    it(' works with non-array', () => {
        expect(isSymmetric(1)).false;
    })

})
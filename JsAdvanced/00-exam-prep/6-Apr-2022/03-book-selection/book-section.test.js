let { bookSelection } = require('./bookSelection.js');

let { expect } = require('chai');

console.log(bookSelection);

console.log(expect);

describe('Book section Test block', () => {
    it('Test 1.1 - Method "isGenreSuitable" not suitable books', () => {
        expect(bookSelection.isGenreSuitable('Horror', 11)).to.equals(`Books with Horror genre are not suitable for kids at 11 age`)
    })

    it('Test 1.2 - Method "isGenreSuitable" - suitable books', () => {
        expect(bookSelection.isGenreSuitable('Kids', 11)).to.equals(`Those books are suitable`);
    })

    it('Test 2.1 - Method "isItAffordable " - can affort to buy', () => {
        expect(bookSelection.isItAffordable(20, 40)).to.equals(`Book bought. You have 20$ left`);
    })

    it('Test 2.2 - Method "isItAffordable" - can not affort to buy', () => {
        expect(bookSelection.isItAffordable(40, 20)).to.equals(`You don't have enough money`);
    })

    it('Test 2.3 - Method "isItAffordable" - invalid price input', () => {
        expect(function () { bookSelection.isItAffordable('40', 20); }).throw('Invalid input');
    })

    it('Test 2.4 - Method "isItAffordable" - invalid budget input', () => {
        expect(function () { bookSelection.isItAffordable(40, '20'); }).throw('Invalid input');
    })

    it('Test 3.1 - Method "suitableTitles" - invalid array input', () => {
        expect(function () { bookSelection.suitableTitles(40, '20'); }).throw('Invalid input');
    })

    it('Test 3.2 - Method "suitableTitles" - add book', () => {
        expect(bookSelection.suitableTitles([{ title: "The Da Vinci Code", genre: "Thriller" }], 'Thriller').length).to.equals(1);
    })



})


function createCard(face, suit) {
    const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'A', 'Q', 'K'];

    if (faces.includes(face) == false) {
        throw new Error();
    }
    const suits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    }

    const result = {
        face,
        suit: suits[suit],
        toString() {
            return this.face + this.suit;
        }
    }

    return result;
}

console.log(createCard('A', 'S').toString());
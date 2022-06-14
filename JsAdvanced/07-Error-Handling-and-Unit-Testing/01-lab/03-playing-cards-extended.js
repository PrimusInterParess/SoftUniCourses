function deck(cards) {

    let result = [];

    for (const cardArg of cards) {
        const face = cardArg.slice(0, -1);
        const suit = cardArg.slice(-1);


        try {
            let card = createCard(face, suit);
            result.push(card);

        }
        catch (Error) {
            result = ['Invalid card: ' + cardArg];
        }

    }

    console.log(result.join(' '));

    function createCard(face, suit) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'A', 'Q', 'K'];
        const suits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663',
        }

        if (faces.includes(face) == false || suits[suit] == undefined) {
            throw new Error();
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
}
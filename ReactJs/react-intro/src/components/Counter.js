import { useState } from 'react';

const getTitle = (count) => {
    switch (count) {
        case 1:
            return 'First Blood';
        case 2: return 'Double Kill';
        case 3: return 'Tripple Kill';
        case 4:
        case 5:
        case 6: return 'Multi Kill'
        case 7:return 'God Like';
        default: return'Start Game';
    }
}

const Counter = (props) => {
    const [counter, setCounter] = useState(props.start);
    const [title, setTitle] = useState(counter);

    const onClickIncrement = (e) => {
        setCounter(state => state + 1)
        console.log(counter)
    };

    const onClickDecrement = (e) => {
        setCounter(state => state - 1)
    }

    return (
        <div>
            <h3>{getTitle(counter)} { counter}</h3>
            <button onClick={onClickIncrement}>
                +
            </button>
            <button onClick={onClickDecrement}>
                -
            </button>
        </div>
    );
}

export default Counter;
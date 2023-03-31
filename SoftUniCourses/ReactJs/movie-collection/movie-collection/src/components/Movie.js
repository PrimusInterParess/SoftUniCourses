import { useEffect, useState } from 'react'
import './Movie.css'

export default function Movie({
    id,
    title,
    year,
    plot,
    posterUrl,
    director,
    onMovieDelete,
    onMovieHighlight,
    selected
}) {
    const [highlighted, setHighlighted] = useState(false);

    const clickHandler = () => {
        setHighlighted(state => !state);
    };

    //executes only one time
    useEffect(() => {
        console.log('mounted')
    }, [])

    //executes everytime when updated
    // useEffect(() => {
    //     console.log('updated')
    // },)

     //executes everytime when change accures
     useEffect(() => {
        console.log('highlighted')
    },[highlighted])
     //executes when unmouted

    useEffect(() => {
       return ()=>{
        console.log('unmounted')
       }
    },[])

    let style = {};

    if (highlighted) {
        style.backgroundColor = "blue";
    }

    return (
        <article onClick={clickHandler} style={style} className="movie-article">
            {selected && <h4>Selected</h4>}
            <h3>
                {title}, {year}
            </h3>
            <main>
                <img src={posterUrl} alt={title} />
                <p>
                    {plot}
                </p>
            </main>
            <footer>
                {director}
                <button onClick={() => onMovieDelete(id)} className="btn-delete">Delete</button>
                <button onClick={() => onMovieHighlight(id)} className="btn-highlight">Highlight</button>
            </footer>
        </article>
    )
}
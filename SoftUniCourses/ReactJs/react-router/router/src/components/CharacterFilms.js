import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";

const baseUrl = "https://swapi.dev/api/films";

export default function CharacterFilms() {
    const { characterId } = useParams();

    const [films, setFilms] = useState([]);
    useEffect(()=>{
        fetch(baseUrl)
        .then(res=>res.json())
        .then(data=>{
            console.log(data)
            setFilms(data.results)
        }
            );
    },[characterId]);

    return (
        <>
         <h5>Films</h5>
        <ul>
            {films.map(m=><li key={m.title}>{m.title}</li>)}
        </ul>
        </>

    );
}
import { useEffect, useState } from "react";
import CharacterListItem from "./CharacterListItem";
import styles from './CharacterList.module.css'

const baseUrl = "https://swapi.dev/api/people";

export default function CharacterList() {
    const [characters, setCharacters] = useState([]);

    useEffect(() => {
        fetch(baseUrl)
            .then(res => res.json())
            .then(data => {
                console.log('useEffect : fetch characters')
                setCharacters(data.results)
            });
    }, [])

    return (
        <>
            <h1>Characters</h1>
            <ul className={styles["ul-characters-list"]}>
                {characters.map(c => <CharacterListItem key={c.url} name={c.name} url={c.url} />)}
            </ul>
        </>

    );
}
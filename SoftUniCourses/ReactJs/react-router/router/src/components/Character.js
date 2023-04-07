import { useEffect, useState } from "react";
import { useParams, useNavigate, Link, Routes, Route } from "react-router-dom";
import styles from "./Character.module.css"
import CharacterFilms from "./CharacterFilms";
import CharacterStarShips from "./CharacterStarShips";
import CharacterVehicles from "./CharacterVehicles";
const baseUrl = "https://swapi.dev/api/people/";

export default function Character({ id }) {
    const { characterId } = useParams();
    const [character, setCharacter] = useState({});
    const navigate = useNavigate();

    const onBackButtonClick = () => {
        navigate('/characters');
    };
    useEffect(() => {
        fetch(`${baseUrl}${characterId}`)
            .then(res => res.json())
            .then(data => {
                console.log(data);
                setCharacter(data);
            })
    }, [characterId]);
    return (
        <>
            <h1>Character name : {character.name}</h1>
            <nav className={styles["character-nav"]}>
                <ul>
                    <li><Link className={styles["character-nav-a"]} to="films">Films</Link></li>
                    <li> <Link className={styles["character-nav-a"]} to="starships">Starships</Link></li>
                    <li><Link className={styles["character-nav-a"]} to="vehicles">Vehicles</Link></li>
                </ul>
                
               
                
            </nav>
            <Routes>
                <Route path="/films" element={<CharacterFilms/>}/>
                <Route path="/starships" element={<CharacterStarShips/>}/>
                <Route path="/vehicles"  element={<CharacterVehicles/>}/>
            </Routes>
            <button onClick={onBackButtonClick}>Back</button>
        </>
    );
} 
import { useState ,useEffect} from 'react';

function Characters() {
    const [characters, setCharacters] = useState([]);

    useEffect(()=>{
        
        fetch(`https://swapi.dev/api/people`)
        .then(res => res.json())
        .then(characters => {
           setCharacters(characters.results)
        });
    },[]);

    return (
        <ul>
            {!characters.length && <li>Loading...</li>}
           {characters.map(c=>(
            <li key={c.name}>{c.name}</li>
           ))}
        </ul>
    );
}


export default Characters;
import { Link } from "react-router-dom";

export default function CharacterListItem({ name,url }) {
    const id = url.split('/').filter(x=>x).pop();
    return (
        <li>
            <Link to={`/characters/${id}`} >{name}</Link>
        </li>);
}
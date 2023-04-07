import styles from "./Navigation.module.css"
import { Link ,NavLink} from "react-router-dom";

export default function Navigation() {

    return (
    <nav>
        <ul className={styles["nav-ul"]}>
            <li ><NavLink to="/">Home</NavLink></li>
            <li ><NavLink to="/characters">Characters</NavLink></li>
        </ul>
    </nav>
    );
}
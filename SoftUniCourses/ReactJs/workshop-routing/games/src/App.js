import { Header } from "./components/Header/Header";
import { Home } from "./components/Home/Home";
import { Login } from "./components/Login/Login";
import { Register } from "./components/Register/Register";
import { Create } from "./components/Create/Create";
import { Catalog } from "./components/Catalog/Catalog";
import { Details } from "./components/Details/Details";

import * as gameService from './services/gameService';

import { useState, useEffect } from 'react';
import { Routes, Route, useNavigate } from 'react-router-dom'

function App() {

    const [games, setGames] = useState([]);
    const navigate = useNavigate();
    useEffect(() => {
        gameService.getAll()
            .then(res => {
                console.log(res);
                setGames(res)
            })
    }, []);

    const onCreateGameSubmit = async (data) => {
        const newGame = await gameService.create(data);
        setGames(state => [...state, newGame])
        navigate('/catalog');
    }
    return (
        <div className="App">
            <Header />
            <main id="main-content">
                <Routes>
                    <Route path='/' element={<Home />} />
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/catalog" element={<Catalog games={games} />} />
                    <Route path="/catalog/:gameId" element={<Details games={games} />} />
                    <Route path="/create" element={<Create onCreateSubmit={onCreateGameSubmit} />} />
                </Routes>
            </main>
        </div>
    );
}

export default App;

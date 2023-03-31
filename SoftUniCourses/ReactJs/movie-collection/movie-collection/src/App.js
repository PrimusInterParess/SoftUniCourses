import './App.css';
import { useState } from 'react';
import { movies as movieData, genres, movies } from './movies';
import MovieList from './components/MovieList';

function App() {

  const [movies, setMovies] = useState(movieData);

  const onMovieDelete = (id) => {
    setMovies(state => state.filter(m => m.id !== id));
  }

  const onMovieHighlight = (id) => {
    setMovies(state => state.map(m => ({ ...m, selected: m.id === id })));

  }

  return (
    <div className="App">
      <h1>Movie collection</h1>
      <MovieList
        movies={movies}
        onMovieDelete={onMovieDelete}
        onMovieHighlight={onMovieHighlight}
      />
    </div>
  );
}

export default App;

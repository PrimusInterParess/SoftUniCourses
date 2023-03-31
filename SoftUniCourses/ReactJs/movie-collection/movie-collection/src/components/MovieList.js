import './MovieList.css';
import Movie from "./Movie";
import { useEffect } from 'react';

export default function MovieList(
    {
        movies, 
        onMovieDelete,
        onMovieHighlight 
    })
    {
    return(
        <div  className="movie-article-wrapper">
        {movies.map(m=><Movie key={m.id} {...m} onMovieHighlight={onMovieHighlight} onMovieDelete={onMovieDelete}/>)}
        </div>
    );
};
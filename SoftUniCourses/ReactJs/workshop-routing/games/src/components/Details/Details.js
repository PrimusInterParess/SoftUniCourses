import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";

import * as gameService from '../../services/gameService';
import * as commentService from '../../services/commentService';

export const Details = () => {
    const { gameId } = useParams();
    const [game, setGame] = useState({});
    const [username, setUsername] = useState('');
    const [comment, setComment] = useState('');

    const onCommentSubmit = async (e) => {
        e.preventDefault();
      const response = await commentService.create({
            gameId,
            username,
            comment,
        });

        console.log(response);
        setComment('');
        setUsername('');
    };

    useEffect(() => {
        gameService.getOne(gameId)
            .then(res => {
                setGame(res);
            });
    }, [gameId]);

    const onUserNameChange = (e) => {
        setUsername(e.target.value);
    };

    const onCommentChange = (e) => {
        setComment(e.target.value);
    };

    return (<section id="game-details">
        <h1>Game Details</h1>
        <div className="info-section">

            <div className="game-header">
                <img className="game-img" src={game.imageUrl} />
                <h1>{game.title}</h1>
                <span className="levels">MaxLevel: {game.maxLevel}</span>
                <p className="type">{game.category}</p>
            </div>

            <p className="text">
                {game.summary}
            </p>

            {/* <!-- Bonus ( for Guests and Users ) --> */}
            <div className="details-comments">
                <h2>Comments:</h2>
                <ul>
                    {/* <!-- list all comments for current game (If any) --> */}
                    <li className="comment">
                        <p>Content: I rate this one quite highly.</p>
                    </li>
                    <li className="comment">
                        <p>Content: The best game.</p>
                    </li>
                </ul>
                {/* <!-- Display paragraph: If there are no games in the database --> */}
                <p className="no-comment">No comments.</p>
            </div>

            {/* <!-- Edit/Delete buttons ( Only for creator of this game )  --> */}
            <div className="buttons">
                <a href="#" className="button">Edit</a>
                <a href="#" className="button">Delete</a>
            </div>
        </div>

        {/* <!-- Bonus -->
    <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) --> */}
        <article className="create-comment">
            <label>Add new comment:</label>
            <form className="form" onSubmit={onCommentSubmit}>
                <input type="text" name="username" placeholder="pesho peshistia" value={username} onChange={onUserNameChange} />
                <textarea name="comment" placeholder="Comment......" value={comment} onChange={onCommentChange}></textarea>
                <input className="btn submit" type="submit" value="Add Comment" />
            </form>
        </article>

    </section>);
}
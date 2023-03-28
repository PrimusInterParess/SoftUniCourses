import { deleteGame, getGame } from "../api/games.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";
import { createComment, getAllComments } from "../api/comments.js";

const detailsTemp = (game, isOwner, onDelete, comments, userData, onSubmit) => html `
<section id="game-details">
<h1>Game Details</h1>
<div class="info-section">

    <div class="game-header">
        <img class="game-img" src=${game.imageUrl} />
        <h1>${game.title}</h1>
        <span class="levels">MaxLevel: ${game.maxLevel}</span>
        <p class="type">${game.category}</p>
    </div>

    <p class="text">
    ${game.summary}
    </p>

    <!-- Bonus ( for Guests and Users ) -->
    <div class="details-comments">
    <ul>
    
    ${ isOwner==false && comments.length==0 ? html ` <h2>Comments:</h2> 
    <p class="no-comment">No comments.</p>`: html`${comments.map(commentTemp)}`}
    </ul>
        <!-- Display paragraph: If there are no games in the database -->
       
    </div>

    <!-- Edit/Delete buttons ( Only for creator of this game )  -->
    ${isOwner? html `<div class="buttons">
    <a href="/edit/${game._id}" class="button">Edit</a>
    <a @click=${onDelete} class="button">Delete</a>
</div>`:''}
</div>

<!-- Bonus -->
<!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
${isOwner!=true&&userData!=null? html `<article class="create-comment">
<label>Add new comment:</label>
<form @submit=${onSubmit} class="form">
    <textarea name="comment" placeholder="Comment......"></textarea>
    <input class="btn submit" type="submit" value="Add Comment">
</form>
</article>`:''}

</section>`


const commentTemp = (c)=> html ` <li class="comment">
<p>Content: ${c.comment}</p>
</li>`

export async function detailsView(ctx) {

    //TODO : DonateBtn!
    const gameId = ctx.params.id;
    const game = await getGame(gameId);
    const userData = getUserData();
    const isOwner = userData?.id == game._ownerId;
    const comments = await getAllComments(gameId);

    

    ctx.render(detailsTemp(game, isOwner, onDelete, comments,userData,onSubmit));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this post?');

        if (choice) {
            await deleteGame(gameId);
            ctx.page.redirect('/');
        }
    }

    async function onSubmit(evnt) {
        evnt.preventDefault();

        const formData = new FormData(evnt.target);

        const commentData  = {
            comment: formData.get('comment'),
            gameId:gameId,
        }

        if (commentData.comment == '' ) {
            return alert('All fields are required!');
        }

        await createComment(commentData);
        evnt.target.reset();
        ctx.page.redirect('/games/'+gameId);
    }


}

/*
<section id="game-details">
            <h1>Game Details</h1>
            <div class="info-section">

                <div class="game-header">
                    <img class="game-img" src="images/MineCraft.png" />
                    <h1>Bright</h1>
                    <span class="levels">MaxLevel: 4</span>
                    <p class="type">Action, Crime, Fantasy</p>
                </div>

                <p class="text">
                    Set in a world where fantasy creatures live side by side with humans. A human cop is forced to work with an Orc to find a weapon everyone is prepared to kill for. Set in a world where fantasy creatures live side by side with humans. A human cop is forced
                    to work with an Orc to find a weapon everyone is prepared to kill for.
                </p>

                <!-- Bonus ( for Guests and Users ) -->
                <div class="details-comments">
                   
                   
                        <!-- list all comments for current game (If any) -->
                       
                        <li class="comment">
                            <p>Content: The best game.</p>
                        </li>
                   
                    <!-- Display paragraph: If there are no games in the database -->
                    <p class="no-comment">No comments.</p>
                </div>

                <!-- Edit/Delete buttons ( Only for creator of this game )  -->
                <div class="buttons">
                    <a href="#" class="button">Edit</a>
                    <a href="#" class="button">Delete</a>
                </div>
            </div>

            <!-- Bonus -->
            <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
            <article class="create-comment">
                <label>Add new comment:</label>
                <form class="form">
                    <textarea name="comment" placeholder="Comment......"></textarea>
                    <input class="btn submit" type="submit" value="Add Comment">
                </form>
            </article>

        </section>
*/
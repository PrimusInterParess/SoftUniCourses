import { html } from "../lib.js";
import { getGame, editGame } from "../api/games.js";


const editTemp = (onSubmit, game) => html `
<section id="edit-page" class="auth">
<form @submit=${onSubmit} id="edit">
    <div class="container">

        <h1>Edit Game</h1>
        <label for="leg-title">Legendary title:</label>
        <input type="text" id="title" name="title" .value=${game.title}>

        <label for="category">Category:</label>
        <input type="text" id="category" name="category" .value=${game.category}>

        <label for="levels">MaxLevel:</label>
        <input type="number" id="maxLevel" name="maxLevel" min="1" .value=${game.maxLevel}>

        <label for="game-img">Image:</label>
        <input type="text" id="imageUrl" name="imageUrl" .value=${game.imageUrl}>

        <label for="summary">Summary:</label>
        <textarea name="summary" id="summary">${game.summary}</textarea>
        <input class="btn submit" type="submit" value="Edit Game">

    </div>
</form>
</section>`;

export async function editView(ctx) {
    const gameId = ctx.params.id;

    const game = await getGame(gameId);

    ctx.render(editTemp(onSubmit, game));

    async function onSubmit(evnt) {
        evnt.preventDefault();

        const formData = new FormData(evnt.target);

        const game = {
            title: formData.get('title'),
            category: formData.get('category'),
            maxLevel: formData.get('maxLevel'),
            imageUrl: formData.get('imageUrl'),
            summary: formData.get('summary'),
        }

        if (game.title == '' ||
            game.category == '' ||
            game.maxLevel == '' ||
            game.imageUrl == '' ||
            game.summary == '') {
            return alert('All fields are required!');
        }

        await editGame(game, gameId);
        evnt.target.reset();

        ctx.page.redirect('/games/' + gameId);
    }
}
import { createGame } from "../api/games.js";
import { html } from "../lib.js";

const createTemp = (onSubmit) => html `<section id="create-page" class="auth">
<form @submit=${onSubmit} id="create">
    <div class="container">

        <h1>Create Game</h1>
        <label for="leg-title">Legendary title:</label>
        <input type="text" id="title" name="title" placeholder="Enter game title...">

        <label for="category">Category:</label>
        <input type="text" id="category" name="category" placeholder="Enter game category...">

        <label for="levels">MaxLevel:</label>
        <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1">

        <label for="game-img">Image:</label>
        <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo...">

        <label for="summary">Summary:</label>
        <textarea name="summary" id="summary"></textarea>
        <input class="btn submit" type="submit" value="Create Game">
    </div>
</form>
</section>

`;

export function createView(ctx) {
    ctx.render(createTemp(onSubmit));

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

        await createGame(game);
        evnt.target.reset();
        ctx.page.redirect('/');
    }
}
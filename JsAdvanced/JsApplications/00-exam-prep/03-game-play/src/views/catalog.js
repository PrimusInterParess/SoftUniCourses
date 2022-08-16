import { html } from '../lib.js'
import { getAllGames } from '../api/games.js';



const catalogTemp = (cards) => html `
<section id="catalog-page">
            <h1>All Games</h1>
           ${cards.length ==0 ? html `<h3 class="no-articles">No articles yet</h3>`: cards.map(cardTemp)}
            
        </section>`

const cardTemp = (card) => html `
<div class="allGames">
                <div class="allGames-info">
                    <img src=${card.imageUrl}>
                    <h6>${card.category}</h6>
                    <h2>${card.title}</h2>
                    <a href="/games/${card._id}" class="details-button">Details</a>
                </div>
           </div>`

/*

        */


export async function catalogView(ctx) {

    const cards = await getAllGames();

    ctx.render(catalogTemp(cards));
}
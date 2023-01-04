import { searchEngine } from "../api/shoes.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const searchTemp = (onClick, shoes, isLogged) => html`
<section id="search">
<h2>Search by Brand</h2>

<form class="search-wrapper cf">
    <input id="#search-input" type="text" name="search" placeholder="Search here..." required />
    <button type="submit" @click=${onClick}>Search</button>
</form>

<h3>Results:</h3>

<div id="search-container">
    <ul class="card-wrapper">
        <!-- Display a li with information about every post (if any)-->
        ${shoes.length == 0 ? html`<h2>There are no results found.</h2> ` : shoes.map(s=>shoeCardtemp(s,isLogged))}
        
    </ul>
</div>
</section>
`

const shoeCardtemp = (shoe, isLogged) => html`
<li class="card">
            <img src=${shoe.imageUrl} alt="travis" />
            <p>
                <strong>Brand: </strong><span class="brand">${shoe.brand}</span>
            </p>
            <p>
                <strong>Model: </strong
  ><span class="model">${shoe.model}</span>
</p>
<p><strong>Value:</strong><span class="value">${shoe.value}</span>$</p>
${isLogged ? html`<a class="details-btn" href="/shoes/${shoe._id}">Details</a>` : ''}
        </li>`

export async function searchView(ctx) {
    let userData = getUserData();

    async function onClick(e) {
        e.preventDefault();

        userData = getUserData();

        let isLogged = userData != null;
        let searchEl = document.getElementById(`#search-input`);

        let searchTerm = searchEl.value;

        const filteredShoes = await searchEngine(searchTerm);

        ctx.render(searchTemp(onClick, filteredShoes, isLogged))
    }

    ctx.render(searchTemp(onClick, [], userData));

}
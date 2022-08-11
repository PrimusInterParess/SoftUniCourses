import { html } from '../lib.js'
import { getAllPosts } from '../api/posts.js'

const dashboardTemp = (cards) => html`
<section id="dashboard-page">
<h1 class="title">All Posts</h1>
<div class="all-posts">
${cards.length == 0 ? html`<h1 class="title no-posts-title">No posts yet!</h1>` : cards.map(dashboardCard)}
  </div>
</section>`;

const dashboardCard = (card) => html`
<div class="post">
<h2 class="post-title">${card.title}</h2>
<img class="post-image" src=${card.imageUrl} alt="Kids clothes">
<div class="btn-wrapper">
    <a href="/data/posts/${card._id}" class="details-btn btn">Details</a>
</div>
</div>`

export async function dashboardView(ctx) {

    const cards = await getAllPosts();

    ctx.render(dashboardTemp(cards));
}
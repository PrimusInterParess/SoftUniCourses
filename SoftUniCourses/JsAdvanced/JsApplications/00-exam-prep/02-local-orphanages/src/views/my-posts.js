import { getPostsByUserId } from "../api/posts.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const myPostsTemp = (posts) => html`
<section id="my-posts-page">
<h1 class="title">My Posts</h1>
<div class="my-posts">
${posts.length == 0 ? html`<h1 class="title no-posts-title">You have no posts yet!</h1>` : posts.map(postCard)}
</div>

</section>`

const postCard = (post) => html`
<div class="post">
<h2 class="post-title">${post.title}</h2>
<img class="post-image" src="${post.imageUrl}" alt="Material Image">
<div class="btn-wrapper">
<a href="/posts/${post._id}" class="details-btn btn">Details</a>
</div>
</div>`

export async function myPostsView(ctx) {

    console.log(ctx.params);
    const userData = getUserData();
    console.log(userData);
    const posts = await getPostsByUserId(userData.id);
    ctx.render(myPostsTemp(posts))
}


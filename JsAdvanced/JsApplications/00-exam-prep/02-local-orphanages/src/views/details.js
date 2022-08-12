import { deletePost, Donated, editPost, getPostById, getTotalDonation, makeDonation } from "../api/posts.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemp = (post, isOwner, userData, onDelete, onDonate, getTotalDonations, canDonate) => html`
<section id="details-page">
<h1 class="title">Post Details</h1>

<div id="container">
    <div id="details">
        <div class="image-wrapper">
            <img src="${post.imageUrl}" alt="Material Image" class="post-image">
        </div>
        <div class="info">
            <h2 class="title post-title">${post.title}</h2>
            <p class="post-description">Description: ${post.description}</p>
            <p class="post-address">Address: ${post.address}</p>
            <p class="post-number">Phone number: ${post.phone}</p>
            <p class="donate-Item">Donate Materials: ${getTotalDonations}</p>
            <div class="btns">
               ${isOwner == true ? html`<a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
               <a @click=${onDelete} class="delete-btn btn">Delete</a>` : ''}
                ${canDonate ? html`<a @click=${onDonate} class="donate-btn btn">Donate</a>` : ''}
            </div >
        </div >
    </div >
</div >
</section > `


export async function detailsView(ctx) {

    //TODO : DonateBtn!
    const postId = ctx.params.id;
    const post = await getPostById(postId);
    const userData = getUserData();
    const isOwner = userData?.id == post._ownerId;
    const getTotalDonations = await getTotalDonation(postId);
    const donated = await hasDonated();

    const canDonate = userData != null && isOwner == false && donated == 0;


    ctx.render(detailsTemp(post, isOwner, userData, onDelete, onDonate, getTotalDonations, canDonate));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this post?');

        if (choice) {
            await deletePost(postId);
            ctx.page.redirect('/');
        }
    }

    async function onDonate(evnt) {
        evnt.preventDefault();
        evnt.target.style.display = 'none';
        const donation = {
            postId,
        }
        await makeDonation(donation);
        ctx.page.redirect(`/posts/${postId}`);
    }

    async function hasDonated() {

        const result = await Donated(postId, userData.id);

        return result;
    }
}
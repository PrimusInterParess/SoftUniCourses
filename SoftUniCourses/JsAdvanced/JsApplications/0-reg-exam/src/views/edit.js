import { editShoe, getShoe } from "../api/shoes.js";
import { html } from "../lib.js";



const editTemp = (onSubmit, shoe) => html `
<section id="edit">
<div class="form">
    <h2>Edit item</h2>
    <form @submit=${onSubmit} class="edit-form">
        <input type="text" name="brand" id="shoe-brand" placeholder="Brand" .value=${shoe.brand} />
        <input type="text" name="model" id="shoe-model" placeholder="Model" .value=${shoe.model}/>
        <input type="text" name="imageUrl" id="shoe-img" placeholder="Image url" .value=${shoe.imageUrl} />
        <input type="text" name="release" id="shoe-release" placeholder="Release date" .value=${shoe.release} />
        <input type="text" name="designer" id="shoe-designer" placeholder="Designer"  .value=${shoe.designer}/>
        <input type="text" name="value" id="shoe-value" placeholder="Value" .value=${shoe.value} />

        <button type="submit">post</button>
    </form>
</div>
</section>`;

export async function editView(ctx) {
    const shoeId = ctx.params.id;
    const shoe = await getShoe(shoeId);
    ctx.render(editTemp(onSubmit, shoe));

    async function onSubmit(evnt) {
        evnt.preventDefault();

        const formData = new FormData(evnt.target);

        const shoe = {
            brand: formData.get('brand'),
            model: formData.get('model'),
            imageUrl: formData.get('imageUrl'),
            release: formData.get('release'),
            designer: formData.get('designer'),
            value: formData.get('value'),

        }
        if (shoe.brand == '' ||
            shoe.model == '' ||
            shoe.imageUrl == '' ||
            shoe.release == '' ||
            shoe.designer == '' ||
            shoe.value == '') {
            return alert('All fields are required!');
        }

        await editShoe(shoe, shoeId);
        evnt.target.reset();

        ctx.page.redirect('/shoes/' + shoeId);
    }
}
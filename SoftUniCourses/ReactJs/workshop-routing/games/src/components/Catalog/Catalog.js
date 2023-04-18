import { CatalogItem } from "./CatalogItem/CatalogItem";

export const Catalog = ({ games }) => {
    return (<section id="catalog-page">
        <h1>All Games</h1>
        {/* <!-- Display div: with information about every game (if any) --> */}

        {games.map(g => <CatalogItem key={g._id} game={g} />)}

        {/* <!-- Display paragraph: If there is no games  --> */}
        {games.length === 0 && (<h3 className="no-articles">No articles yet</h3>)}

    </section>);
}
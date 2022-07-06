function getArticleGenerator(articles) {
    let contentElement = document.getElementById('content');
    return () => {

        if (articles.length != 0) {
            let articlElement = document.createElement('article');
            articlElement.textContent = articles.shift();
            contentElement.appendChild(articlElement);
        }

    }

}

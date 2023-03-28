async function loadRepos() {
    let inputField = document.getElementById('username');

    let repos = document.getElementById('repos');

    try {
        let response = await fetch(`https://api.github.com/users/${inputField.value}/repos`);

        if (response.ok == false) {
            throw new Error(`${response.status} "${'Not Found'}"`);
        }

        let data = await response.json();

        let extractedRepoInfo = data.map(({ full_name, html_url }) => ({ full_name, html_url }));

        for (const repo of extractedRepoInfo) {

            repos.innerHTML = '';
            let liEl = document.createElement('li');
            let aEl = document.createElement('a');
            aEl.href = repo.html_url;
            aEl.textContent = repo.full_name;
            liEl.appendChild(aEl);
            repos.appendChild(liEl);

        }
    } catch (err) {
        repos.textContent = err.message;
    }
}
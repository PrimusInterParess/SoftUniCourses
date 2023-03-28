async function loadCommits() {
    let usernameInputField = document.getElementById('username');

    let repoInputField = document.getElementById('repo');

    let ulElement = document.getElementById('commits');

    try {
        let response = await fetch(`https://api.github.com/repos/${usernameInputField.value}/${repoInputField.value}/commits`);

        if (response.ok == false) {
            throw new Error(`${response.status} (Not Found)`);
        }
        ulElement.innerHTML = '';

        let data = await response.json();

        for (const { commit }
            of data) {

            let liEl = document.createElement('li');
            liEl.textContent = `${commit.author.name}: ${commit.message}`
            ulElement.appendChild(liEl);
        }

        //let extractedCommitData = data.map(({ commit_author_name }) => ({ commit_author_name }))


        for (const iterator of object) {
            //"<commit.author.name>: <commit.message>" 
        }
    } catch (err) {

        let liEl = document.createElement('li');
        liEl.textContent = err.message;
        ulElement.appendChild(liEl);
    }
}
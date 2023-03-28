async function loadRepos() {

   let result = document.getElementById('res');

   let res = await fetch('https://api.github.com/users/testnakov/repos');

   let data = await res.json();

   result.textContent = JSON.stringify(data);

   console.log(data);
}
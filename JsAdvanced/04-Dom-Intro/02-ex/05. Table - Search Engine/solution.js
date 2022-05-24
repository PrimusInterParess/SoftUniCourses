      function solve() {
          document.querySelector('#searchBtn').addEventListener('click', onClick);

          function onClick() {
              let criteria = document.getElementById('searchField').value;
              let parent = document.querySelectorAll('tbody tr');

              for (const child of parent) {

                  let color = child.style.backgroundColor;

                  if (child.className == 'select') {
                      child.classList.remove('select')
                  }
              }

              for (const child of parent) {
                  let children = child.getElementsByTagName('td')

                  for (const elements of children) {
                      let currentEl = elements.textContent;

                      if (criteria !== ' ' && criteria !== '' && (currentEl === criteria ||
                              currentEl.includes(criteria))) {
                          child.classList.add('select')
                      }
                  }
              }
          }
      }
function toggle() {

    let lessMore = document.getElementsByClassName('button')[0].textContent;

    if (document.getElementsByClassName('button')[0].textContent == 'Less') {
        document.getElementsByClassName('button')[0].textContent = 'More';
        document.getElementById('extra').style.display = 'none';
    } else {
        document.getElementsByClassName('button')[0].textContent = 'Less';
        document.getElementById('extra').style.display = 'block';
    }
}
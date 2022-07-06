function attachGradientEvents() {
    let hoverElement = document.getElementById('gradient');

    hoverElement.addEventListener('mousemove', function(e) {
        let power = e.offsetX / (e.target.clientWidth - 1);
        power = Math.floor(power * 100);
        document.getElementById('result').textContent = power + "%";
    })

}
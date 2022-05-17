function getHeroesAsJson(array) {

    let heroesEntities = [];

    for (const entry of array) {
        let parts = entry.split('/');
       
        let hero = {
            name: parts[0],
            level: parts[1],
            items: parts[2].split(', ')
        };

        heroesEntities.push(JSON.stringify(hero));

    }

    return heroesEntities
}

console.log( getHeroesAsJson(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
 ))


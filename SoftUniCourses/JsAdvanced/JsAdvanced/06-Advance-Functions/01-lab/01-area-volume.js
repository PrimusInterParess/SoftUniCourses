function area() {
    return Math.abs(this.x * this.y);
};


function vol() {
    return Math.abs(this.x * this.y * this.z);
};


function solve(area, vol, input) {

    const objects = JSON.parse(input);

    let result = [];

    for (const obj of objects) {
        let areaObj = area.call(obj);
        let volObj = vol.call(obj);

        result.push({
            area: areaObj,
            volume: volObj
        })
    }

    return result;

}


let res = solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
);
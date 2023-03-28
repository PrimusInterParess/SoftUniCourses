function sortNames(array) {
    let n = 1;

    return array
        .sort((a, b) => a.localeCompare(b))
        .map(name => `${n++}.${name}`)
        .join('\n');
}

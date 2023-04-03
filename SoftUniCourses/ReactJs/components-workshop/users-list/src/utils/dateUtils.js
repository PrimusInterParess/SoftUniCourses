export const dateFormat = (input) => {
    const date = new Date(input);


    var result = date.toLocaleDateString('en-US', { month: 'long', day: 'numeric', year: 'numeric' });
    return result;
}
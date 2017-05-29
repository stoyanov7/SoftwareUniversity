function composeHTML(arr) {
    let elements = { location: arr[0], alternateText: arr[1] };

    console.log(`<img src="${elements.location}" alt="${elements.alternateText}">`);
}
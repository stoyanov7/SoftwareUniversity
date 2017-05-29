function calculateArea(w, h, W, H) {
    let area = (w * h) + (W * H);
    area -= Math.min(w, W) * Math.min(h, H);

    console.log(area);
}
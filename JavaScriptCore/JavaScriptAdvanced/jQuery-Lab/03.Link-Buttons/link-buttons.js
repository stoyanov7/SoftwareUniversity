function attachEvents() {
    $(".button").on("click", (event) => {
        let currentButton = $(event.target);
        
        $(".button").removeClass("selected");
        currentButton.addClass("selected");
    });
}
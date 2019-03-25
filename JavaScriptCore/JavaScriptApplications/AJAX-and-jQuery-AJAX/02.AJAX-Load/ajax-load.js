function loadTitle() {
     $.get("text.html", (res) => {
          $("#text").html(res);
     });
}   
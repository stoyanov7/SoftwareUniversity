function solve() {
  var links = document.querySelectorAll('a'), result;

  for (var i = 0; i < links.length; i++) {
    result = links[i];
    result["timesClicked"] = Number(result.nextElementSibling.textContent.match(/\d+/)[0]);

    result.addEventListener('click', function () {
      this.timesClicked += 1;
      this.nextElementSibling.textContent = `Visited: ${this.timesClicked} times`;
    });
  }
}
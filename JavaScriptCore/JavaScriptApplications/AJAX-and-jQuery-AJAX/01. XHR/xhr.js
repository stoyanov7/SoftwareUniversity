function loadRepos() {
     let req = new XMLHttpRequest();
     let url = "https://api.github.com/users/testnakov/repos";

     req.onreadystatechange = function() {
          if (this.readyState == 4 && this.status == 200) {
               document.getElementById('res').textContent = this.responseText;
          }
     };

     req.open('GET', url, true);
     req.send();
}
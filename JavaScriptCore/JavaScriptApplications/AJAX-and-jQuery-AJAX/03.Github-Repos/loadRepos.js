function loadRepos() {
     let reposUl = $("#repos");
     reposUl.html("");

     let username = $("#username").val();

     $.ajax({
          method: "GET",
          url: `https://api.github.com/users/${username}/repos`,
          dataType: "json",
          error: () => {
               reposUl.append("<li>Error</li>");
          },
          success: (repos) => {
               $(repos).each((index, element) => {
                    reposUl.append("<li><a href='" + element.html_url + "'>" + element.full_name + "</a></li>");
               });
          }
     });
}
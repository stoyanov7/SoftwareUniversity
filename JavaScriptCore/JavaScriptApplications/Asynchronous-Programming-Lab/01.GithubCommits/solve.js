const selectors = {
     usernameInput: '#username',
     repoInput: '#repo',
     loadBtn: '#loadCommits',
     commitsList: '#commits'
}

class GitHubCommits { 
     init() {
          this.render();
          this.registerEventHandler();
     }

     registerEventHandler = () => {
          this.handlerUsernameInput();
          this.handleRepoInput();
          this.handleLoadBtnClick();
     }

     handlerUsernameInput = () => {
          const { usernameInput } = selectors;

          $(usernameInput).on('change', (event) => {
               this.username = event.target.value;
          })
     }

     handleRepoInput = () => {
          const { repoInput } = selectors;

          $(repoInput).on('change', (event) => {
               this.repo = event.target.value;
          })
     }

     handleLoadBtnClick = () => {
          const { loadBtn } = selectors;

          $(loadBtn).on('click', () => {
              this.loadCommits();
          })
     }

     loadCommits = () => {
          const url = `https://api.github.com/repos/${this.username}/${this.repo}/commits`;
          
          $.get(url)
               .then((commits) => {
                    $(selectors.commitsList).empty();
                    return commits;
               })
               .then(commits => this.renderCommits(commits))
               .catch(error => console.log(error))

          this.renderLoadingIndicatior(selectors.commitsList);
     }

     renderCommits = (commits) => {
          const { commitsList } = selectors;
          const $commitsList = $(commitsList);

          commits.forEach(commit => {
               $commitsList.append(`<li>${commit.commit.message}</li>`)
          });
     }

     renderLoadingIndicatior = (selector) => {
          $(selector).html('<li>Loading commits...</li>')
     }

     render = () => {
          $('body').append(`
               <div>
                    GitHub username:
                    <input type="text" id="username" value="" /> <br>
                    Repo: <input type="text" id="repo" value="" />
                    <button id="loadCommits">Load Commits</button>
                    <ul id="commits"></ul>
               </div>
          `)
     }
}

window.GitHubCommits = GitHubCommits;
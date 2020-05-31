const selectors = {
     btnLoadPosts: '#btnLoadPosts',
     posts: '#posts',
     btnViewPost: "#btnViewPost",
     postTitle: "#post-title",
     postBody: "#post-body",
     postComments: "#post-comments"
};

const kinveyTokens = {
     kinveyAppId: 'kid_B15S6I9Zl',
     kinveyUsername: 'peter',
     kinveyPassword: 'p'
};

const baseUrl = 'https://baas.kinvey.com/appdata/' + kinveyTokens.kinveyAppId;

const authHeaders = {
     'Authorization': 'Basic ' + btoa(kinveyTokens.kinveyUsername + ':' + kinveyTokens.kinveyPassword)
};

class Blog {
     init() {
          this.render();
          this.registerEventHandlers();
     }

     registerEventHandlers = () => {
          this.handleLoadPosts();
          this.handleViewPost();
     }

     handleLoadPosts = () => {
          const { btnLoadPosts } = selectors;

          $(btnLoadPosts).on('click', () => {
               $.ajax({
                    url: baseUrl + '/posts',
                    method: 'GET',
                    headers: authHeaders,
                    success: (data) => {
                         const { posts } = selectors;

                         data.forEach(p => {
                              $(posts).append(`<option value="${p._id}">${p.title}</option>`)
                         });
                    },
                    error: (error) => {
                         console.log(error)
                    }
               })
          })
     }

     handleViewPost = () => {
          const { btnViewPost } = selectors;

          $(btnViewPost).on('click', () => {
               const { posts } = selectors;
               const postId = $(posts).find(":selected").val();
     
               $.ajax({
                    url: baseUrl + '/posts/' + postId,
                    method: 'GET',
                    headers: authHeaders,
                    success: (data) => {
                         const { postTitle, postBody, postComments } = selectors;

                         $(postTitle).append(data.title);
                         $(postBody).append(data.body);
                    },
                    error: (error) => {
                         console.log(error)
                    }
               })
          })
     }

     render = () => {
          $('body').append(`
               <div>
                    <h1>All Posts</h1>
                    <button id="btnLoadPosts">Load Posts</button>
                    <select id="posts"></select>
                    <button id="btnViewPost">View</button>
                    <h1 id="post-title"></h1>
                    <ul id="post-body"></ul>
                    <h2>Comments</h2>
                    <ul id="post-comments"></ul>
               </div>
          `)
     }
}

window.Blog = Blog;
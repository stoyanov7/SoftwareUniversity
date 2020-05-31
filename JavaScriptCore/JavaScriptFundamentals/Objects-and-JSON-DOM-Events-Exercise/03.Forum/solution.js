function solve() {
     $('button').eq(0).click((event) => {
          event.preventDefault();

          let userInfo = $('.user-info input');
          var topics = [];

          $.each($('.topics input:checked'), function() {
               topics.push($(this).val());
          });

          let user = {
               username: userInfo.eq(0).val(),
               password: userInfo.eq(1).val(),
               email: userInfo.eq(2).val(),
               topics
          };

          let tdUsername = $('<td>').text(user.username);
          let tdEmail = $('<td>').text(user.email);
          let tdTopics = $('<td>').text(user.topics.join(' '));

          let tr = $('<tr >')
               .append(tdUsername)
               .append(tdEmail)
               .append(tdTopics);

          $('tbody').append(tr); 
     });

     $('button').eq(1).click(() => {
          let search = $('input').last().val();

          Array.from(document.getElementsByTagName('tbody')[0].children)
               .forEach((el) => el.style.visibility = 'visible');

          Array.from(document.getElementsByTagName('tbody')[0].children)
               .filter((el) => !el.innerText.includes(search))
               .forEach((el) => el.style.visibility = 'hidden');          
     });
}
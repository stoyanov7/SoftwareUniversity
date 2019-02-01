function emailValidation(email) {
     let regex = new RegExp(/\b[(a-zA-Z\d._%+)]+@[(a-z)]+\.[a-z]+\b/);
     console.log(email.match(regex) ? 'Valid' : 'Invalid');
 }
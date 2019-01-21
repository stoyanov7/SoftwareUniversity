function register() {
  var usernameValue = document.getElementById('username').value;
  var emailValue = document.getElementById('email').value;
  var passwordValue = document.getElementById('password').value;
  var pattern = /(.+)@(.+).(com|bg)/gm;

  if (isEmpty(usernameValue) && isEmpty(passwordValue) && pattern.test(emailValue)) {
    var result = document.getElementById('result');
    result.innerHTML = `<h1>Successful Registration!</h1>Username: ${usernameValue}<br>Email: ${emailValue}<br>Password: ${'*'.repeat(passwordValue.length)}`;
  }

  setTimeout(clear, 5000);

  /**
   * Check if a string is empty, null or undefined.
   * @param {*} str 
   */
  function isEmpty(str) {
    return (str.length > 0);
  }

  function clear() {
    document.getElementById('result').innerHTML = '';
  }
}
function register() {
  var usernameValue = $('#username').val();
  var emailValue = $('#email').val();
  var passwordValue = $('#password').val();
  var pattern = /(.+)@(.+).(com|bg)/gm;

  if (isEmpty(usernameValue) && 
      isEmpty(passwordValue) &&
      pattern.test(emailValue)) {
    var result = $('#result');
    result.html(`<h1>Successful Registration!</h1>Username: ${usernameValue}<br>Email: ${emailValue}<br>Password: ${'*'.repeat(passwordValue.length)}`);
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
    $('#result').html('');
  }
}
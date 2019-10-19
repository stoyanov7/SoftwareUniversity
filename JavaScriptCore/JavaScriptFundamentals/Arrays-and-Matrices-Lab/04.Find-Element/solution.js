function solve() {
  let needle = parseInt($('#num').val());
  let inputArray = $('#arr').val;
  let haystack = JSON.parse(inputArray);
  let result = [];

  haystack.forEach(element => {
    let hasValue = element.includes(needle);
    let index = element.indexOf(needle);

    result.push(`${hasValue} -> ${index}`);
  });

  $('#result').text(result.join(','));
}
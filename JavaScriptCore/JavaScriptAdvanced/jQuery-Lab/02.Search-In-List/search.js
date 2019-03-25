function search() {
   let searchedValue = $('#searchText').val();
   $('#towns li').css('font-weight', 'normal');

   let towns = $(`#towns li:contains(${searchedValue})`)
      .css('font-weight', 'bold');

   $('#result').text(`${towns.length} mathces found`);
}
function addItem() {
     let item = $('#newItemText').val();
     let value = $('#newItemValue').val();

     let obj = {};
     obj[item] = value;

     let s = $('#menu');

     for (var val in obj) {
          $('<option />', {
               value: val,
               text: obj[val]
          }).appendTo(s);
     }

     $('#newItemText').val('');
     $('#newItemValue').val('')
}
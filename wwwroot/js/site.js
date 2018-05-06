// Write your JavaScript code.

function Search() {
  var theForm;
  theForm = document.createElement('form');
  theForm.action = 'search.php';
  theForm.method = 'post';
  var searchVal = document.getElementsByName('search').value;
  newInput1.name = 'searchVal';
  newInput1.value = searchVal;
  theForm.submit();
} 
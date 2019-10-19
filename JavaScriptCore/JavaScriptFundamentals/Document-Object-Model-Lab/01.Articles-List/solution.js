function solve() {
	let createTitleValue = $('#createTitle').val();
	let createContentValue = $('#createContent').val();

	if (createTitleValue && createContentValue) {
		let articleElement = $('<article>')
			.append($('<h3>').text(createTitleValue))
			.append($('<p>').text(createContentValue));

		$('#articles')
			.append(articleElement);

		$('#createTitle').val('');
		$('#createContent').val('');
	}
}
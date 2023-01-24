function truncateText(text) {
	let truncateText = text.substring(0, 100) + '...';
	let fixedText = truncateText;

	return fixedText;
}
function handleDateFormatting(date) {
	let formatedDate = date.toLocaleDateString('en-US', {
		year: 'numeric',
		month: 'long',
		day: 'numeric'
	});
	return formatedDate;
}

export { truncateText, handleDateFormatting };

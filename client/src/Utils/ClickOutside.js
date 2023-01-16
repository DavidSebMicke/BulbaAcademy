/**
 * A click outside hook used for when you want to catch clicks outside of an element.
 * Don't use this for things that are open all the time as it will add a click listener to the document.
 *
 * HOW TO USE:
 * add this to your html-tag where you want to catch clicks outside of it:
 * 	use:clickOutside
 *	on:click_outside={your callback function goes here}
 */
export function clickOutside(node) {
	const handleClick = (event) => {
		if (node && !node.contains(event.target) && !event.defaultPrevented) {
			node.dispatchEvent(new CustomEvent('click_outside', node));
		}
	};

	document.addEventListener('click', handleClick, true);

	return {
		destroy() {
			document.removeEventListener('click', handleClick, true);
		}
	};
}

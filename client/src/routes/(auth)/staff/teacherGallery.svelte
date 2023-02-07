<script>
	import { createEventDispatcher } from 'svelte';

	let currentItem;
	export let teachers;
	const dispatch = createEventDispatcher();

	function setIndexValue(indexNumber) {
		currentItem = teachers[indexNumber];
		console.log(currentItem);
		dispatch('Teacher', {
			Teacher: currentItem,
			Boolean: true
		});
	}
</script>

<body class="body">
	<div class="gallery">
		{#each teachers as image, index}
			<button on:click={() => setIndexValue(index)}>
				<div class="gallery-item">
					<h4>{image.name}</h4>
					<img src={image.id} alt="School staff" />
				</div>
			</button>
		{/each}
	</div>
</body>

<style lang="less">
	.gallery {
		display: grid;
		grid-template-columns: 10% 11% 10% 11% 10% 11% 10% 11%;
		column-gap: 0.2em;
		position: relative;
		background: none;
		padding-left: 10%;
	}
	button {
		border: none;
	}

	.gallery-item {
		text-align: center;
		color: white;
		font-size: 1.4em;
		text-transform: capitalize;
		img {
			border: 2px solid white;

			outline: 2px solid #030303;
		}
		&:hover img {
			border: none;
			outline: 2px solid #f2f5f5;
			outline-offset: -0.08em;
			border-radius: 25%;
			transform: translateY(-0.25em);
			opacity: 1;
			z-index: 99;
			offset: 2;
			scale: 1.5;
		}
	}
	.gallery-item img {
		transition: all 1s;
		opacity: 0.5;
		width: 50%;
		height: auto;
	}
</style>

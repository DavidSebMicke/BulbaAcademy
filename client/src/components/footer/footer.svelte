<script>
	import { onMount } from 'svelte';
	import { fly } from 'svelte/transition';
	let lastScrollPosition = 0;
	let hideFooter = false;

	onMount(() => {
		let footer = document.querySelector('.footer');

		window.addEventListener('scroll', () => {
			let currentScrollPosition = window.scrollY;
			if (currentScrollPosition < lastScrollPosition) {
				hideFooter = false;
			} else {
				hideFooter = true;
			}
			lastScrollPosition = currentScrollPosition;
		});
	});
</script>

{#if hideFooter}
	<div class="footer" transition:fly={{ y: 200, duration: 2000 }}>
		<p>Copyright Bulbasaur Academy - Pro group of developers</p>
		<a href="https://letmegooglethat.com/?q=Pro+developers" target="_blank" rel="noreferrer">
			Find us here!</a
		>
	</div>
{/if}

<style lang="less">
	.footer {
		position: fixed;
		bottom: 0;
		width: 100%;
		background-color: #333;
		color: #fff;
		padding: 10px;
		text-align: center;
	}
	a {
		color: #fff;
		text-decoration: none;
	}
	p {
		color: #fff;
		text-decoration: none;
	}
</style>

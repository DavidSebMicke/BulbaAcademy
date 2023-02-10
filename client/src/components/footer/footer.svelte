<script>
	import { onMount } from 'svelte';
	import { fly } from 'svelte/transition';

	let lastScrollPosition = 0;
	let hideFooter = false;

	onMount(() => {
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
	@import 'public/less/global.less';
	.footer {
		position: fixed;
		bottom: 0;
		width: 100%;
		background-color: var(--color);
		color: var(--bg-color);
		background-image: url('public/img/pencils.jfif');
		background-size: cover;
		padding: 5px;
		text-align: center;
		a {
			text-decoration: none;
			color: var(--bg-color);
		}
		p {
			text-decoration: none;
			color: var(--bg-color);
		}
	}
</style>

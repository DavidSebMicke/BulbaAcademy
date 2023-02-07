<script>
	import { onMount } from 'svelte';

	let currentTheme = '';
	onMount(() => {
		const userPrefersDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;
		const hasUserSetDarkModeManually = document.documentElement.dataset.theme == 'dark';
		if (!hasUserSetDarkModeManually) {
			setTheme(userPrefersDarkMode ? 'dark' : 'light');
		}
	});
	const setTheme = (theme) => {
		document.documentElement.dataset.theme = theme;
		document.cookie = `siteTheme=${theme};max-age=31536000;path="/"`;
		currentTheme = theme;
	};
</script>

<nav>
	<div class="container">
		<ul>
			<li class="relative">
				{#if currentTheme === 'light'}
					<a class="" href={'#'} on:click={() => setTheme('dark')}>
						<iconify-icon icon="mdi:white-balance-sunny" />
					</a>
				{:else}
					<a class="" href={'#'} on:click={() => setTheme('light')}>
						<iconify-icon icon="mdi:moon-waxing-crescent" />
					</a>
				{/if}
			</li>
		</ul>
	</div>
</nav>

<style lang="less">
	nav {
		font-size: 20px;
		margin-right: 1em;
		float: right;
		padding-right: 5px;
	}

	ul {
		list-style: none;
	}
</style>

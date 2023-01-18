<script>
	import { fade } from 'svelte/transition';
	const fadeIn = {
		delay: 100,
		duration: 200
	};

	const fadeOut = {
		delay: 0,
		duration: 100
	};

	let isExpanded = false;
</script>

<div class="nav-container">
	<nav class:expanded={isExpanded}>
		<button on:click={() => (isExpanded = !isExpanded)}>
			{#if isExpanded}
				<iconify-icon icon="material-symbols:keyboard-arrow-left" width="40" />
			{:else}
				<iconify-icon icon="material-symbols:keyboard-arrow-right" width="40" />
			{/if}
		</button>
		<ul>
			<!-- <li>Bulba Academy</li> -->
			<li>
				<a href="/mainPage"><iconify-icon icon="mdi:home" /></a>{#if isExpanded}<a
						in:fade={fadeIn}
						out:fade={fadeOut}
						href="/mainPage">Startsida</a
					>{/if}
			</li>
			<li>
				<a href="/"><iconify-icon icon="mdi:home" /></a>{#if isExpanded}<a
						class="text"
						in:fade={fadeIn}
						out:fade={fadeOut}
						href="/profile">Profil</a
					>{/if}
			</li>
			<li>
				<a href="/staff"><iconify-icon icon="mdi:home" /></a>{#if isExpanded}<a
						class="text"
						in:fade={fadeIn}
						out:fade={fadeOut}
						href="/staff">Personal</a
					>{/if}
			</li>
			<!-- <li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li>
			<li>Bulba Academy</li> -->
		</ul>
	</nav>
</div>

<style lang="less">
	@import 'public\less\variables.less';
	@import 'public\less\global.less';
	nav {
		cursor: pointer;
		color: @dark-mode-text;
	}

	ul {
		padding: 0px;
	}

	.text {
		margin-right: 2px;
		margin-left: 2px;
	}

	a {
		color: currentColor;
		text-decoration: none;
		text-align: left;
		font-size: 20px;
		justify-content: space-around;
		gap: 24px;
	}

	.nav-container {
		display: flex;
		justify-content: left;
		height: 100em;
		color: currentColor;
		background-color: #e1b382;
		text-decoration: none;
		float: left;
		padding: 10px;
		overflow: hidden;
		margin-bottom: 1%;
		margin-right: 1%;
	}

	h2 {
		display: flex;
		justify-content: left;
		height: 100em;
		color: currentColor;
		background-color: @dark-mode-background;
		text-decoration: none;
		float: left;
		padding: 10px;
		overflow: hidden;
		margin-bottom: 1%;
		margin-right: 1%;
	}

	nav ul {
		list-style-type: none;
		color: currentColor;
		text-decoration: none;
	}

	button {
		border: none;
		background: none;
		color: currentColor;
		text-transform: uppercase;
	}
</style>

<script>
	import { fade } from 'svelte/transition';
	import NoticeBoard from '../noticeBoard/noticeBoard.svelte';
	const fadeIn = {
		delay: 100,
		duration: 200
	};

	const fadeOut = {
		delay: 0,
		duration: 100
	};

	let isExpanded = true;
</script>

<div class="nav-container">
	<nav class:expanded={isExpanded}>
		<button on:click={() => (isExpanded = !isExpanded)}>
			{#if isExpanded}
				<iconify-icon icon="ci:hamburger" width="40" />
			{:else}
				<iconify-icon
					icon="ci:hamburger"
					rotate="90deg"
					flip="horizontal,vertical"
					width="40"
				/>
			{/if}
		</button>
		{#if isExpanded}
			<ul>
				<!-- <li>Bulba Academy</li> -->
				<li>
					<a href="/" iconify-icon icon="mdi:home" in:fade={fadeIn} out:fade={fadeOut}>
						Startsida
					</a>
				</li>

				<li>
					<a href="/profile"> <iconify-icon icon="healthicons:ui-user-profile" /> </a>
					<a class="text" in:fade={fadeIn} out:fade={fadeOut} href="/profile">Profil </a>
				</li>

				<li>
					<a href="/staff"><iconify-icon icon="ic:baseline-work" /> </a>
					<a class="text" in:fade={fadeIn} out:fade={fadeOut} href="/staff">Personal </a>
				</li>

				<li>
					<a href="/registration"><iconify-icon icon="material-symbols:forms-add-on" /></a
					><a class="text" in:fade={fadeIn} out:fade={fadeOut} href="/registration"
						>Formulär</a
					>
				</li>
				<li>
					<a href="/"><iconify-icon icon="ic:sharp-grid-on" /></a><a
						class="text"
						in:fade={fadeIn}
						out:fade={fadeOut}
						href="/">Avdelningar</a
					>
				</li>
				<li>
					<a href="/"><iconify-icon icon="mdi:file-document" /></a><a
						class="text"
						in:fade={fadeIn}
						out:fade={fadeOut}
						href="/"
						>Dokument
					</a>
				</li>
				<li>
					<NoticeBoard />
				</li>
			</ul>
		{:else}
			<ul class="iconOnly">
				<!-- <li>Bulba Academy</li> -->
				<li>
					<a href="/"><iconify-icon icon="mdi:home" width="40" /></a>
				</li>
				<li>
					<a href="/"><iconify-icon icon="healthicons:ui-user-profile" width="40" /></a>
				</li>
				<li>
					<a href="/staff"><iconify-icon icon="ic:baseline-work" width="40" /></a>
				</li>
				<li>
					<a href="/registration">
						<iconify-icon icon="material-symbols:forms-add-on" width="40" />
					</a>
				</li>
				<li>
					<a href="/staff"><iconify-icon icon="ic:sharp-grid-on" width="40" /></a>
				</li>
				<li>
					<a href="/staff"><iconify-icon icon="mdi:file-document" width="40" /></a>
				</li>
			</ul>
		{/if}
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
	.iconOnly {
		justify-content: center;
		align-items: center;
	}
	.text {
		margin-right: 2px;
		margin-left: 2px;
		background-color: var(--primary-color);
	}

	a {
		//color: currentColor;
		text-decoration: none;
		text-align: left;
		font-size: 20px;
		background-color: var(--primary-color);
		justify-content: center;
	}

	.nav-container {
		display: flex;
		justify-content: left;
		top: 0%;
		text-decoration: none;
		float: left;
		padding: 5px;
		overflow: none;
		margin-bottom: 1%;

		border-color: rgba(0, 0, 0, 0.233);
		border-style: solid;
		background-color: var(--primary-color);
		height: 100%;
		position: fixed;
		z-index: 1;
	}

	nav ul {
		list-style-type: none;
		//color: currentColor;
		text-decoration: none;
	}

	button {
		border: none;
		background: none;
		//color: currentColor;
		text-transform: uppercase;
	}
</style>

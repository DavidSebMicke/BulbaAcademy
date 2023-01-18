<script>
	let message;
	let title;
	let datePublished;
	let dateEnd;
	let showBanner = true;
	function toggleBanner() {
		showBanner = !showBanner;
	}
</script>

{#if !showBanner}
	<div class="messageButton">
		<button class="showMessage" on:click={toggleBanner}>Noticeboard</button>
	</div>
{/if}
{#if showBanner}
	<div class="crisis-banner">
		{title}
		<p>
			Attention: Crisis Crisis Crisis Crisis Crisis Crisis Crisis
			{message}
		</p>
		<p>
			{datePublished} /{dateEnd}
		</p>

		<button class="closeCross" on:click={toggleBanner}
			><iconify-icon icon="material-symbols:close" width="20" /></button
		>
	</div>
{/if}

<style lang="less">
	@import 'public\less\global.less';

	// .noticeBoard-container {
	// 	display: inline-flex;
	// }
	.crisis-banner {
		display: flex;
		background-color: @crisis-message-background;
		color: black;
		width: 100%;
		position: relative;
		padding: 1em;
	}
	.closeCross {
		display: inline-flex;
		position: absolute;
		right: 0;
		top: 0;
		background: none;
		border: none;
		&:hover {
			cursor: pointer;
		}
	}
	.messageButton {
		display: inline-flex;
		float: right;
	}
	.showMessage {
		padding: 0.2em;
		.classic-button;
	}
</style>

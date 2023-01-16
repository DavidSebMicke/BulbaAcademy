<script>
	import ChatWindow from './chatWindow.svelte';

	let showChatWindow = false;

	const openChat = () => (showChatWindow = true);
	const closeChat = () => (showChatWindow = false);
</script>

<div class="container">
	{#if showChatWindow}
		<ChatWindow {closeChat} />
	{:else}
		<button class="chatBubble" on:click={openChat} />
	{/if}
</div>

<style lang="less">
	@import '../../../public/less/variables.less';
	@import '../../../public/less/global.less';

	.container {
		position: absolute;
		width: fit-content;
		height: fit-content;
		max-height: 25rem;
		bottom: 1.5rem;
		right: 1.5rem;
		transition: all 0.5s ease;
	}

	.chatBubble {
		position: relative;
		background: @secondary-color;
		opacity: 0.2;
		width: 4rem;
		height: 4rem;
		border-radius: 50%;
		border: none;
		cursor: pointer;
		transition: all 0.3s ease;

		&:hover {
			opacity: 1;
		}
	}
</style>

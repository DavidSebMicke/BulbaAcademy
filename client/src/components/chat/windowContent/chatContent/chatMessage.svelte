<script>
	export let message;
	export let senders;

	$: sender = senders.find((sender) => sender.id === message.sender);

	console.log(senders);
</script>

<div class="container" class:userMessage={!sender}>
	{#if sender}
		<div class="sender">{sender.firstName}</div>
	{/if}

	<div class="message" class:userColor={!sender}>
		{message.message}
	</div>
</div>

<style lang="less">
	@import '../../../../../public/less/variables.less';
	@import '../../../../../public/less/global.less';

	.container {
		display: flex;
		flex-direction: row;
		align-items: center;
		justify-content: flex-start;
		width: 100%;
	}
	.userMessage {
		justify-content: flex-end;
	}

	.sender {
		font-size: 0.7rem;
		font-weight: 300;
	}

	.message {
		margin: 0.1rem;
		padding: 0.4rem;
		border-radius: 1rem;
		background-color: rgb(14, 165, 114);
		max-width: 60%;
	}

	.userColor {
		background-color: rgb(25, 102, 138);
	}
</style>

<script>
	import Dashboard from '../components/dashboard/dashboard.svelte';
	import ChatBubble from '../components/chat/chatBubble.svelte';
</script>

<Dashboard />
<slot />
<ChatBubble />

<style lang="less">
	.MpLink {
		color: red;
	}
</style>

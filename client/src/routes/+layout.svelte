<script>
	import Dashboard from '../components/dashboard/dashboard.svelte';
	import ChatBubble from '../components/chat/chatBubble.svelte';
	import 'iconify-icon';
</script>

<nav class="tempnav">
	<a href="/loginPage">Login sidan</a>
	<a href="/about">about</a>
	<a href="/mainPage">Startsida</a>
	<a href="/profile">profile</a>
</nav>

<slot />
<ChatBubble />
<button on:click={() => console.log('test')}>Test</button>

<style lang="less">
	.MpLink {
		color: red;
	}
</style>

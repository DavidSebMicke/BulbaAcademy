<script>
	import Dashboard from '$components/dashboard/dashboard.svelte';
	import ChatBubble from '$components/chat/chatBubble.svelte';
	import 'iconify-icon';
	import Dropdown from '$components/dropdown/dropdown.svelte';
</script>

<Dashboard />
<ChatBubble />
<Dropdown />
<slot />

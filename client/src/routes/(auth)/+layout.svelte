<script>
	import Dashboard from '$components/dashboard/dashboard.svelte';
	import NoticeBoard from '../../components/noticeBoard/noticeBoard.svelte';
	import ChatBubble from '$components/chat/chatBubble.svelte';

	import 'iconify-icon';
	import Dropdown from '$components/dropdown/dropdown.svelte';
</script>

<NoticeBoard />
<Dashboard />
<ChatBubble />
<Dropdown />
<slot />

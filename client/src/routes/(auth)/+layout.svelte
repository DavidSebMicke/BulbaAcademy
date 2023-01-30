<script>
	import Dashboard from '$components/dashboard/dashboard.svelte';
	import NoticeBoard from '../../components/noticeBoard/noticeBoard.svelte';
	import ChatBubble from '$components/chat/chatBubble.svelte';

	import 'iconify-icon';
</script>

<NoticeBoard />
<Dashboard />
<ChatBubble />
<slot />

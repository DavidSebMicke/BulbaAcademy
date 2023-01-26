<script>
	import Dashboard from '$components/dashboard/dashboard.svelte';
	import NoticeBoard from '../../components/noticeBoard/noticeBoard.svelte';
	import 'iconify-icon';
	import Dropdown from '$components/dropdown/dropdown.svelte';
</script>

<NoticeBoard />
<Dashboard />
<Dropdown />
<slot />

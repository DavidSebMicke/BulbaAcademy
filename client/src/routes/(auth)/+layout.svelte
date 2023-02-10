<script>
	import Dashboard from '$components/dashboard/dashboard.svelte';
	import ChatBubble from '$components/chat/chatBubble.svelte';
	import 'iconify-icon';
	import Dropdown from '$components/dropdown/dropdown.svelte';
	import DropdownModal from '../../components/dropdown/dropdownModal.svelte';
	import { onMount } from 'svelte';
	import { GetFromLocal } from '../../Utils/LocalStore';
	import { CheckUserData } from '../../app';

	onMount(async () => {
		CheckUserData();
	});



</script>

<Dashboard />
<ChatBubble />
<Dropdown />
<slot />

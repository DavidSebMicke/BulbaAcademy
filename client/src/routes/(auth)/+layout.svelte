<script>
	import Dashboard from '$components/dashboard/dashboard.svelte';
	import ChatBubble from '$components/chat/chatBubble.svelte';
	import 'iconify-icon';
	import Dropdown from '$components/dropdown/dropdown.svelte';
	import DropdownModal from '../../components/dropdown/dropdownModal.svelte';
	import { afterUpdate, onMount } from 'svelte';
	import { GetFromLocal } from '../../Utils/LocalStore';
	import { CheckUserData } from '../../app';
	import { user } from '../../stores/userStores';

	onMount(async () => {
		let newUser = CheckUserData();
		$user = newUser;
	});
</script>

<Dashboard />
<ChatBubble />
<Dropdown />
<slot />

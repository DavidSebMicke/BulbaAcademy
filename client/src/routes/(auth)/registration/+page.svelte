<script>
	import Header from '../../../components/header/header.svelte';
	import RegForm from '../../../components/registrationForm/regForm.svelte';
	import { user } from '../../../stores/userStores';
	import { onMount } from 'svelte';

	onMount(async () => {
		if (!$user || ($user.accessLevel != 'SEMIADMIN' && $user.accessLevel != 'ADMIN')) {
			document.location.href = '/';
		}
	});
</script>

<Header title="Registration" />
<RegForm />

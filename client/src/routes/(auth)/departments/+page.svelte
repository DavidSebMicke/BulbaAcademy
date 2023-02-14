<script>
	import Header from '../../../components/header/header.svelte';
	import GroupPage from './groupPage.svelte';
	import { user } from '../../../stores/userStores';
	import { onMount } from 'svelte';

	onMount(async () => {
		if (!$user || ($user.accessLevel != 'SEMIADMIN' && $user.accessLevel != 'ADMIN')) {
			document.location.href = '/';
		}
	});
</script>

<Header title="Avdelningar" />
<GroupPage />

<style lang="less">
	@import 'public/less/global.less';
</style>

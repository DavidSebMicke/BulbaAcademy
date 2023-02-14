<script>
import { onMount } from 'svelte';
	import { GetAllGroups } from '../../../api/groups';
import GroupList from './groupList.svelte';
	export let groups = [];

	onMount(async () => {
		GetAllGroups().then((data) => {
			if (data) {
				groups = data;
				console.log(groups);
			}
		});
	});
</script>
	<GroupList {groups} />
<style lang="less">

</style>
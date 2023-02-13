<script>
	import { onMount } from 'svelte';
	import Header from '../../../components/header/header.svelte';
	import { user } from '../../../stores/userStores';

</script>

<Header title="Profile" />

<div>Epost: {$user?.email}</div>
<div>
	 Namn: {#if $user?.name}{$user?.name}{:else}Ej Registrerad{/if}	{#if $user?.role}({$user?.role}){/if}
</div>
<div></div>

<style lang="less">
</style>

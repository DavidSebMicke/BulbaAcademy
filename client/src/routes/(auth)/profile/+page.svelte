<script>
	import Header from '../../../components/header/header.svelte';
	import DropdownModal from '../../../components/dropdown/dropdownModal.svelte';

	let showModal = false;

	function toggleModal() {
		showModal = !showModal;

		console.log(showModal);
	}
</script>

<Header title="Profile" />
{#if showModal}
	<DropdownModal bind:showModal />
{/if}

<button class="btn" on:click={toggleModal}>Ändra profil</button>

<style lang="less">
	.btn {
		font-size: 16px;
		display: inline-block;
		padding: 0.6rem 1.4rem;
		font-weight: 600;
		background-color: rgba(0, 0, 0, 0.242);
		color: var(--color);
		border-radius: 5px;
		text-align: center;
		font-size: 1em;
		cursor: pointer;
	}
</style>

<script>
	import Header from '../../../components/header/header.svelte';
	import { user } from '../../../stores/userStores';
	import DropdownModal from '../../../components/dropdown/dropdownModal.svelte';

	let showModal = false;

	function toggleModal() {
		showModal = !showModal;

	}
	let profileImage = 'https://thispersondoesnotexist.com/image'

</script>

<Header title="Profil" />
{#if showModal}
	<DropdownModal bind:showModal />
{/if}


<div class="profile">
	<div class="profile-header">
	  <img src={profileImage} alt="Profilbild">
	  <h2>{#if $user?.name}{$user?.name}{:else}Ej Registrerad{/if}</h2>
	  <p>{#if $user?.role}({$user?.role}){/if}</p>
	</div>
	<div class="profile-body">
	  <h2>Epost</h2>
	  <p>{$user?.email} </p>
	</div>
	<button class="btn" on:click={toggleModal}>Ändra profil</button>
  </div>
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
	.profile {
		display: grid;
		align-items: center;
		justify-content: center;
  width: 100%;
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
  box-sizing: border-box;
  font-family: Arial, sans-serif;
}

.profile-header {
  display: flex;
  align-items: center;
  margin-bottom: 20px;
}

.profile-header img {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  margin-right: 20px;
}

.profile-header p {
  font-size: 1.2em;
  margin: 0;
}

.profile-body {
  margin-top: 20px;
}

.profile-body h2 {
  font-size: 1.5em;
  margin: 0;
}

.profile-body p {
  line-height: 1.5;
}

@media (max-width: 600px) {
  .profile-header {
    flex-direction: column;
    align-items: flex-start;
  }

  .profile-header img {
    margin-right: 0;
    margin-bottom: 10px;
  }

  .profile-header h1 {
    font-size: 1.5em;
  }

  .profile-header p {
    font-size: 1em;
  }
}

</style>

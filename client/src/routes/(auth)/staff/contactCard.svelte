<script>
	import ClickOutside from '../../../Utils/ClickOutside';

	export let teachers;
	let showContactsList = false;
	function showContacts() {
		showContactsList = !showContactsList;
	}
</script>

{#if !showContactsList}
	<button class="contactUs" on:click={showContacts}>Kontakta oss!</button>
{:else}
	<div class="contactCard" use:ClickOutside on:click_outside={showContacts}>
		<div class="contact-card-info">
			<h2>Kontaktlista</h2>
			{#each teachers as teacher, i}
				<div class="teacher" style="grid-template-row='1' grid-column: {i}">
					<h3>
						{teacher.name}
					</h3>
				<h4>
					{teacher.profession}
				</h4>
					<h4>
					Telefon: {teacher.phoneNumber}
					</h4>
					<h4>
					Epost: {teacher.email}
					</h4>
				</div>
			{/each}
			<button class="closeCross" on:click={showContacts}
				><iconify-icon icon="material-symbols:close" width="40" /></button
			>
		</div>
	</div>
{/if}

<style lang="less">
	@import 'public\less\global.less';

	.contactUs {
		.classic-button;
		padding: 10px 20px;
		align-self: center;
		width: 10em;
		font-weight: 700;
		font-size: x-large;
		font-family: 'Times New Roman', Times, serif;
		transition: all 1s;
		&:hover {
			cursor: pointer;
			color: var(--primary-color);
			size: 0;
		}
	}
	.contact-card {
		position: fixed;
		top: 0;
		left: 0;
		width: 100%;
		height: 100%;
		background-color: rgba(0, 0, 0, 0.5);
		z-index: 10;
		background-color: none;
	}
	.contact-card-info {
		position: fixed;
		text-align: center;
		overflow-y: scroll;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		background-color: var(--bg-color);
		width: 70%;
		height: 80%;
		max-width: 600px;
		padding: 20px;
		border: 3px solid;
		z-index: 11;
		h2 {
			text-decoration: underline 8px solid;
		}
	}
	.teacher {
		border-bottom: 1px solid @light-mode-flavour1;
	}
	.closeCross {
		border: none;
    position: absolute;
    top: 0;
    right: 0;
    background-color: transparent;
    margin: 0;
    padding: 0;

		&:hover {
			cursor: pointer;
		}
	}
</style>

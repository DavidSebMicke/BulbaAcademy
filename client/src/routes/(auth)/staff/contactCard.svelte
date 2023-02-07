<script>
	import ClickOutside from '../../../Utils/ClickOutside';

	export let teachers;
	let showContactsList = false;
	function showContacts() {
		showContactsList = !showContactsList;
	}
</script>

{#if !showContactsList}
	<button class="contactUs" on:click={showContacts}>Contact us!</button>
{:else}
	<div class="contactCard" use:ClickOutside on:click_outside={showContacts}>
		<div class="contact-card-info">
			<h1>Contact List</h1>
			{#each teachers as teacher, i}
				<div class="teacher" style="grid-template-row='1' grid-column: {i}">
					<h3>
						{teacher.name}
					</h3>
					Phone: {teacher.phoneNumber} / Email: {teacher.email}
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
		padding: 10px 20px;
		background-color: white;
		color: black;
		align-self: center;
		width: 10em;
		font-weight: 700;
		font-size: x-large;
		font-family: 'Times New Roman', Times, serif;
		transition: all 1s;
		border: 2px solid rgb(11, 11, 11);
		&:hover {
			cursor: pointer;
			background-color: rgb(102, 102, 103);
			color: white;
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
	}
	.contact-card-info {
		position: fixed;
		text-align: center;
		overflow-y: scroll;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		background-color: #fff;
		width: 70%;
		height: 80%;
		max-width: 600px;
		padding: 20px;
		z-index: 11;
	}
	.teacher {
		border-bottom: 1px solid @light-mode-flavour1;
	}
	.closeCross {
		border: none;
		display: inline-flex;
		float: right;

		&:hover {
			cursor: pointer;
		}
	}
</style>

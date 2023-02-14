<script>
	import ClickOutside from '../../../Utils/ClickOutside';

	export let members;
    export let showMembersList;
	function showMembers() {
		showMembersList = !showMembersList;
	}
</script>

	<div class="contactCard" use:ClickOutside on:click_outside={showMembers}>
		<div class="contact-card-info">
			<h1>Contact List</h1>
			{#each members as member, i}
				<div class="teacher" style="grid-template-row='1' grid-column: {i}">
					<h3>
						{member.name}
					</h3>
					Phone: {member.phoneNumber} / Email: {member.email}
				</div>
			{/each}
			<button class="closeCross" on:click={showMembers}
				><iconify-icon icon="material-symbols:close" width="40" /></button
			>
		</div>
	</div>

<style lang="less">
	@import 'public/less/global.less';

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
		border: 3px dashed black;
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

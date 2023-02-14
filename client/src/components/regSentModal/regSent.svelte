<script>
	export let noCloseButton = false;
	export let showModal = false;
	import { empty } from 'svelte/internal';
	import ClickOutside from '../../Utils/ClickOutside';
	export let message = '';

	function closeModal() {
		showModal = false;
		message = '';
	}
</script>

<div class="modal" use:ClickOutside on:click_outside={closeModal}>
	<div class="modal-container">
		<div class="modal-header">
			<h2 class="modal-title">
				{#if message != ''}
					{message}
				{:else}
					<iconify-icon icon="svg-spinners:3-dots-bounce" width="80" height="80" />
				{/if}
			</h2>
		</div>

		<dev class="modal-footer">
			{#if !noCloseButton}
				<button class="buttondispatch" on:click={closeModal}>Ok</button>
			{/if}
		</dev>
	</div>
</div>

<style lang="less">
	@import 'public/less/global.less';
	.modal {
		position: fixed;
		top: 0;
		left: 0;
		width: 100%;
		height: 100%;
		background-color: rgba(0, 0, 0, 0.699);
		z-index: 10;

		&:global(*) {
			/* Chrome, Safari, Edge, Opera */
			input::-webkit-outer-spin-button,
			input::-webkit-inner-spin-button {
				-webkit-appearance: none;
				margin: 0;
			}

			/* Firefox */
			input[type='number'] {
				-moz-appearance: textfield;
			}
		}
	}
	.buttondispatch {
		.classic-button;
		position: relative;
		left: 30%;
		font-weight: bold;
		width: 40%;
		margin-left: 10px;
		margin-right: 10px;
		cursor: pointer;
		text-shadow: 2px 2px 2px black;
		box-shadow: 2px 2px 2px black;
	}

	.modal-text {
		padding: 20px;
	}
	.modal-container {
		position: fixed;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		background-color: rgb(94, 97, 88);
		width: 80%;
		max-width: 600px;
		// border: 2px solid black;
		border-radius: 10px;
		box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.39);
		z-index: 11;
	}

	.modal-title {
		text-align: center;
		margin: 0;
		font-size: 50px;
		text-shadow: 2px 2px 2px black;
	}

	.modal-content {
		padding: 30px;
		height: fit-content;
		display: flex;
		flex-direction: column;
	}
	.modal-header {
		position: relative;
		top: 0;
		padding-top: 2rem;
		padding-bottom: 2rem;
	}

	.modal-footer {
		position: relative;
		bottom: 0;
		width: 100%;
		justify-content: space-between;

		flex-direction: row;
		margin: 0;

		display: flex;
		padding: 10px;

		.buttondispatch:first-of-type {
			margin-left: 0;
		}
		.buttondispatch:last-of-type {
			margin-right: 0;
		}
	}
</style>

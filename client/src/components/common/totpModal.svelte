<script>
	import { fade } from 'svelte/transition';
	import { createEventDispatcher } from 'svelte';
	import ClickOutside from '../../Utils/ClickOutside';
	import { useForm, HintGroup, validators, Hint, required } from 'svelte-use-form';

	import { GetFromSession, RemoveFromSession, StoreInSession } from '../../Utils/SessionStore';
	import { TOTPLogIn } from '../../api/login';

	const dispatch = createEventDispatcher();
	const form = useForm();

	export let title = 'No title';
	export let noCloseButton = false;

	function CloseModal() {
		dispatch('message', {
			closeModal: true
		});
	}

	function convertQrToImage(qr) {
		return `data:image/png;base64,${qr}`;
	}

	export let fieldParams = {
		label: '',
		placeholder: 'write something...'
	};

	export let fieldValue = '';
	export let qrCode = '';

	function onSendClick() {
		var twoFToken = GetFromSession('TwoFToken');
		RemoveFromSession('TwoFToken');

		if (twoFToken) {
			console.log('Sending');

			TOTPLogIn(twoFToken, fieldValue).then((idToken) => {
				if (idToken) {
					document.location.href = '/';
				} else {
					console.log('wrong code');
				}
			});
		} else {
			console.log('no token');
		}
		CloseModal();
	}
</script>

<div class="modal" use:ClickOutside on:click_outside={CloseModal}>
	<div class="modal-container">
		<form name="sendCodeForm" use:form on:submit|preventDefault={onSendClick}>
			<div class="modal-header">
				<h2 class="modal-title">
					{title}
				</h2>
			</div>
			<div class="modal-content">
				<div class="inputfield-container">
					{#if qrCode != ''}
						<div class="qr-image-container">
							<img src={convertQrToImage(qrCode)} alt="" class="qr-image" />
						</div>
					{/if}

					{#if fieldParams.label}
						<label for="inputField">{fieldParams.label}</label>
					{/if}

					<input
						maxlength="6"
						name="inputField"
						use:validators={[required]}
						bind:value={fieldValue}
					/>
				</div>
			</div>

			<dev class="modal-footer">
				<button class="buttondispatch" visibility: hidden={!$form.valid} type="submit"
					>Send Code</button
				>
				{#if !noCloseButton}
					<button class="buttondispatch" on:click={CloseModal}>Avbryt</button>
				{/if}
			</dev>
		</form>
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
	}
	.buttondispatch {
		.classic-button;
		position: relative;

		font-weight: bold;
		width: fit-content;
		margin-left: 10px;
		margin-right: 10px;
	}

	.qr-image-container {
		display: flex;
		justify-content: center;
		padding: 20px;
	}

	.qr-image {
		width: 12rem;
		height: auto;
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
		justify-content: right;

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

	.inputfield-container {
		width: 50%;
		align-self: center;
	}

	input {
		width: 100%;
		font-size: 60px;
		text-align: center;
	}
</style>

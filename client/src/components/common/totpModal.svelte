<script>
	import { fade } from 'svelte/transition';
	import { createEventDispatcher } from 'svelte';
	import ClickOutside from '../../Utils/ClickOutside';
	import { useForm, HintGroup, validators, Hint, required } from 'svelte-use-form';
	import { onlyNumbersCheck } from '../../Utils/Validation';
	import { GetFromLocal, RemoveFromLocal } from '../../Utils/LocalStore';
	import { TOTPLogIn } from '../../api/login';

	const dispatch = createEventDispatcher();
	const form = useForm();

	export let title = 'No title';
	export let noCloseButton = false;
	export let loggingIn = false;
	let sendingCode = false;
	let incorrectCode = false;
	let sixNumbers = false;

	function CloseModal() {
		dispatch('message', {
			closeModal: true
		});
	}

	function convertQrToImage(qr) {
		return `data:image/png;base64,${qr}`;
	}

	function onCodeInput() {
		fieldValue = fieldValue.replace(' ', '');
	}

	export let fieldParams = {
		label: '',
		placeholder: 'write something...'
	};

	export let fieldValue = '';
	export let qrCode = '';

	function onSendClick() {
		sendingCode = true;
		incorrectCode = false;
		var twoFToken = GetFromLocal('TwoFToken');

		if (twoFToken) {
			console.log('Sending');

			TOTPLogIn(twoFToken, fieldValue).then((idToken) => {
				if (idToken) {
					RemoveFromLocal('TwoFToken');
					CloseModal();
					loggingIn = true;
					document.location.href = '/';
				} else {
					console.log('wrong code');
					fieldValue = '';
					loggingIn = false;
					incorrectCode = true;
				}
				sendingCode = false;
			});
		} else {
			console.log('no token');
			sendingCode = false;
			loggingIn = false;
		}
	}

	const handleKeyPress = (event) => {
		if (fieldValue.length == 6 && event.key != 'Enter') {
			sixNumbers = true;
			return false;
		}

		if (fieldValue.length == 6 && event.key === 'Enter') {
			onSendClick();
		}

		sixNumbers = false;

		if (fieldValue.length == 5) sixNumbers = true;
		return true;
	};

	const handleKeyDown = (event) => {
		if (event.key === 'Backspace') {
			sixNumbers = false;
		}

		if (event.key === 'Enter' && fieldValue.length != 6) {
			event.preventDefault();
		}
	};
</script>

<div class="modal">
	<div class="modal-container">
		<div class="modal-header">
			<h2 class="modal-title">
				{title}
			</h2>
		</div>
		<form name="sendCodeForm" use:form on:submit|preventDefault={onSendClick}>
			<div class="modal-content">
				<div class="inputfield-container">
					{#if !sendingCode}
						{#if qrCode != ''}
							<div class="qr-image-container">
								<img src={convertQrToImage(qrCode)} alt="" class="qr-image" />
							</div>
						{/if}

						{#if fieldParams.label}
							<label for="codeInput">{fieldParams.label}</label>
						{/if}

						<input
							minlength="6"
							maxlength="6"
							name="codeInput"
							on:input={onCodeInput}
							use:validators={[required, onlyNumbersCheck]}
							on:keypress={handleKeyPress}
							on:keydown={handleKeyDown}
							bind:value={fieldValue}
						/>
						<HintGroup for="codeInput">
							<Hint on="invalidInput" hideWhenRequired>
								{$form.codeInput.errors.invalidInput}
							</Hint>
						</HintGroup>
						{#if incorrectCode}
							<p>Fel kod</p>
						{/if}
					{:else}
						<iconify-icon icon="svg-spinners:3-dots-bounce" width="80" height="80" />
					{/if}
				</div>
			</div>

			<dev class="modal-footer">
				{#if !noCloseButton}
					<button class="buttondispatch" on:click={CloseModal} tabindex="-1"
						>Avbryt</button
					>
				{/if}

				{#if $form.valid && !sendingCode && sixNumbers}
					<button class="buttondispatch" type="submit"> Skicka </button>
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

		font-weight: bold;
		width: fit-content;
		margin-left: 10px;
		margin-right: 10px;
		cursor: pointer;
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

	.inputfield-container {
		width: 100%;
		justify-self: center;
	}

	input {
		width: 100%;
		font-size: 60px;
		text-align: center;
	}
</style>

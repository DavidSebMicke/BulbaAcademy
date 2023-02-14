<script>
	import { PasswordLogIn } from '../../../api/login';
	import { useForm, HintGroup, validators, Hint, email, required } from 'svelte-use-form';
	import { emailCheck, RequiredMsg } from '../../../Utils/Validation';
	import TotpModal from '../../../components/common/totpModal.svelte';
	import { StoreInLocal } from '../../../Utils/LocalStore';

	const form = useForm();

	let logInForm = {
		email: '',
		password: ''
	};
	let qrCode = '';
	let pwLoginInvalidResponse = false;

	let showTOTPmodal = false;
	let sendingLogin = false;
	let loggingIn = false;

	function openModal() {
		showTOTPmodal = true;
	}

	function closeModal(event) {
		if (event.detail.closeModal) {
			showTOTPmodal = false;
			// loggingIn = true;
		}
	}

	function handleLoginClick() {
		pwLoginInvalidResponse = false;
		sendingLogin = true;
		PasswordLogIn(logInForm).then((loginResp) => {
			pwLoginInvalidResponse = !loginResp;

			if (loginResp) {
				StoreInLocal('TwoFToken', loginResp.token);

				qrCode = loginResp.qrCode;
				openModal();
			}
			sendingLogin = false;
		});
	}
</script>

<img class="logga" src="public\img\logo3.png" alt="gfdk" />

<body class="login">
	<div id="step1">Logga in i Bulba Academy</div>

	<div class="step2">
		<form name="loginForm" use:form on:submit|preventDefault={handleLoginClick}>
			<div>
				Användarnamn<br />
				<input
					type="email"
					name="email"
					disabled={sendingLogin || showTOTPmodal}
					use:validators={[required, emailCheck]}
					bind:value={logInForm.email}
				/>
				<HintGroup for="email">
					<Hint on="required">{RequiredMsg('Epost')}</Hint>
					<Hint on="invalidEmail" hideWhenRequired>{$form.email.errors.invalidEmail}</Hint
					>
				</HintGroup>
			</div>

			<div>
				Lösenord<br />
				<input
					type="password"
					name="password"
					disabled={sendingLogin || showTOTPmodal}
					use:validators={[required]}
					bind:value={logInForm.password}
				/>
				<HintGroup for="password">
					<Hint on="required">{RequiredMsg('Lösenord')}</Hint>
				</HintGroup>
				<br /><br />
			</div>
			<div>
				{#if sendingLogin}
					<iconify-icon icon="svg-spinners:3-dots-bounce" width="80" height="80" />
				{:else if loggingIn}
					<h2 class="logIn-text">Loggar in</h2>
					<iconify-icon icon="svg-spinners:3-dots-bounce" width="80" height="80" />
				{:else}
					<button
						id="step3"
						disabled={!$form.valid || sendingLogin || showTOTPmodal}
						type="submit"
					>
						<h2 class="logIn-text">Logga in</h2>
					</button>
				{/if}
				{#if pwLoginInvalidResponse}
					<p>Inkorrekt epost eller lösenord</p>
				{/if}
			</div>
		</form>
	</div>

	<img class="bulben" src="public\img\bulbi.png" alt="gfdkl" />
</body>

{#if showTOTPmodal}
	<TotpModal title={'Engångskod'} {qrCode} bind:loggingIn on:message={closeModal} />
{/if}

<style lang="less">
	// @import 'public\less\variables.less';
	// @import 'public\less\global.less';
	@import url('https://fonts.googleapis.com/css2?family=Poiret+One&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Plus+Jakarta+Sans&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Inter&display=swap');

	.logIn-text {
		font-size: 1.8em;
	}
	.login {
		font-family: 'Poiret One', cursive;
		font-family: 'Plus Jakarta Sans', sans-serif;
		font-family: 'Inter', sans-serif;
		display: grid;
		grid-template-columns: 1fr 1fr;
	}
	#step1 {
		position: absolute;
		width: 724px;
		height: 88px;
		left: 128px;
		top: 90px;
		font-family: 'Poiret One';
		font-style: normal;
		font-weight: 600;
		font-size: 40px;
		line-height: 75px;
		display: grid;
		align-items: center;
		letter-spacing: 0.04em;
	}

	.step2 {
		position: absolute;
		width: 236px;
		height: 39px;
		left: 128px;
		top: 200px;
		font-family: 'Plus Jakarta Sans';
		font-style: normal;
		font-weight: 500;
		font-size: 18px;
		line-height: 25px;
		display: grid;
		align-items: center;
		letter-spacing: 0.04em;
		color: var(--color);
		background-color: var(--bg-color);
	}
	.loginp {
		background-color: white;
	}

	#step3 {
		position: relative;
		width: 333px;
		height: 50px;
		position: absolute;
		background-color: var(--bg-color);
		display: grid;
		top: 200px;
border-color: var(--color);
		font-family: 'Inter';
		font-style: normal;
		font-weight: 500;
		font-size: 10px;
		line-height: 5px;
		display: grid;
		align-items: center;
		text-align: center;
		color: var(--color);
		cursor: pointer;
	}

	#step3:disabled {
		opacity: 0.3;
		cursor: not-allowed;
	}

	.bulben {
		box-sizing: border-box;

		display: grid;
		position: absolute;
		width: 237.61px;
		height: 250.18px;
		left: 50rem;
		top: 5rem;
	}

	.logga {
		box-sizing: border-box;
		display: grid;
		position: absolute;
		width: 335px;
		height: 51px;
		left: 50rem;
		top: 20rem;
		border-radius: nullpx;
	}
</style>

<script>
	import { PasswordLogIn } from '../../../api/user';
	import { useForm, HintGroup, validators, Hint, email, required } from 'svelte-use-form';
	import { emailCheck } from '../../../Utils/Validation'
	import { onMount } from 'svelte';
	import TotpModal from '../../../components/common/totpModal.svelte';
	import {StoreInSession} from '../../../Utils/SessionStore'


	const form = useForm();
	let 
	logInForm = {
		email : "",
		password : ""
	};

	let pwLoginInvalidResponse = false;

	let showTOTPmodal = false;

	function openModal() {
		showTOTPmodal = true;
	}


	
	function closeModal(event) {
		
		if(event.detail.closeModal){
			showTOTPmodal = false;
		}

		
	}



	function handleLoginClick() {
		pwLoginInvalidResponse = false;

		PasswordLogIn(logInForm).then((token) => {
			
			pwLoginInvalidResponse = !token;
			
			if(token){
				StoreInSession("TwoFToken", token);
				openModal();
			}
			
		});
	}



</script>

<div class="griden">
	<div id="step1">Logga in i Bulba Academy</div>

	<div class="step2">
		<form name="loginForm" use:form on:submit|preventDefault={handleLoginClick}>
			<div>
				Användarnamn<br />
				<input
					type="email"
					name="email"
					use:validators={[required, emailCheck]}
					bind:value={logInForm.email}
				/>
				<HintGroup for="email">
					<Hint on="required">* You need to enter your email</Hint>
					<Hint on="invalidEmail" hideWhenRequired>{$form.email.errors.invalidEmail}</Hint>
				</HintGroup>
			</div>

			<div>
				Lösenord<br />
				<input
					type="password"
					name="password"
					use:validators={[required]}
					bind:value={logInForm.password}
				/>
				<HintGroup for="password">
					<Hint on="required">* You need to enter your password</Hint>
				</HintGroup>
				<br /><br />
			</div>
			<div>
				<button id="step3" disabled={!$form.valid} type="submit">
					<h1>Logga in</h1>
				</button>
				{#if pwLoginInvalidResponse}
					<p>Incorrect email or password</p>
				{/if}
			</div>
		</form>
	</div>

	<img class="bulben" src="public\img\bulbi.png" alt="gfdkl" />


</div>

{#if showTOTPmodal}
	
	<TotpModal title={"Engångskod"} noCloseButton={true}  on:message={closeModal} /> 


{/if}

<style lang="less">
	// @import 'public\less\variables.less';
	// @import 'public\less\global.less';
	@import url('https://fonts.googleapis.com/css2?family=Poiret+One&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Plus+Jakarta+Sans&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Inter&display=swap');

	// .body {
	// 	font-family: 'Poiret One', cursive;
	// 	font-family: 'Plus Jakarta Sans', sans-serif;
	// 	font-family: 'Inter', sans-serif;
	// }
	.griden {
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

		color: #000000;

		//border: 1px solid #000000;
		//text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
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

		color: #000000;
	}

	#step3 {
		position: relative;
		width: 333px;
		height: 50px;
		position: absolute;
		background-color: blue;
		display: grid;
		top: 200px;

		font-family: 'Inter';
		font-style: normal;
		font-weight: 500;
		font-size: 10px;
		line-height: 5px;
		display: grid;
		align-items: center;
		text-align: center;
		color: #ffffff;
	}

	.bulben {
		box-sizing: border-box;

		display: grid;
		position: absolute;
		width: 237.61px;
		height: 250.18px;
		left: 50rem;
		top: 10rem;

		//border: 1px solid #000000;
		//transform: rotate(33.25deg);
	}
</style>

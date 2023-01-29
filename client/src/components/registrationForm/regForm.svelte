<script>
	import {
		useForm,
		Hint,
		HintGroup,
		validators,
		required,
		minLength,
		email
	} from 'svelte-use-form';
	import { SSNCheck, emailCheck, RequiredMsg } from '$Utils/Validation';
	const form = useForm();
	let formValues = {
		email: ''
	};
</script>

<main>
	<form use:form>
		<h1>Registrering</h1>
		<label for="email">Epost</label>
		<input
			type="email"
			name="email"
			use:validators={[required, emailCheck]}
			bind:value={formValues.email}
		/>
		<HintGroup for="email">
			<Hint on="required">{RequiredMsg('Epost')}</Hint>
			<Hint on="invalidEmail" hideWhenRequired>{$form.email.errors.invalidEmail}</Hint>
		</HintGroup>
		<h3>Vårdnadshavare</h3>
		<label for="name">Förnamn </label>
		<input type="text" name="name" />
		<label for="name">Efternamn </label>
		<input type="text" name="name" />
		<h3>Barn</h3>
		<label for="name">Förnamn</label>
		<input type="text" name="name" />
		<label for="name">Efternamn</label>
		<input type="text" name="name" />
		<label for="sSNnumber">Personnummer</label>
		<input name="sSNnumber" use:validators={[required, SSNCheck]} />
		<HintGroup for="sSNnumber">
			<Hint on="required">{RequiredMsg('Personnummer')}</Hint>
			<Hint on="invalidSSN" hideWhenRequired>{$form.sSNnumber.errors.invalidSSN}</Hint>
		</HintGroup><br />

		<button disabled={!$form.valid} on:click|preventDefault> Registrera </button>
	</form>
	<pre>
		{JSON.stringify($form, null, 1)}
	</pre>
</main>

<style>
	:global(.touched:invalid) {
		border-color: red;
		outline-color: red;
	}

	main {
		display: flex;
		justify-content: space-around;
		height: 400px;
		width: 400px;
		position: relative;
		flex-wrap: nowrap;
	}

	form {
		height: 100%;
		flex-wrap: nowrap;
		position: absolute;
		left: 20;
		width: 95%;
		top: 0;
		display: flex;
		align-items: left;
		justify-content: left;
		flex-direction: column;
	}

	pre {
		bottom: 0;
		height: 0px;
		width: 50px;
		overflow: none;
		font-size: 12px;
		position: absolute;
	}
</style>

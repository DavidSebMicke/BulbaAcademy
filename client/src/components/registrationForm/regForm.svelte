<script>
	import { useForm, Hint, HintGroup, validators, required, number } from 'svelte-use-form';
	import {
		SSNCheck,
		emailCheck,
		RequiredMsg,
		streetAddressCheck,
		phoneNumberCheck,
		cityCheck,
		postCodeCheck
	} from '$Utils/Validation';
	const form = useForm();
	let formValues = {
		careTaker: {
			email: '',
			streetaddress: '',
			city: '',
			postalCode: '',
			phoneNumber: '',
			firstName: '',
			lastName: '',
			sSN: ''
		},
		children: [
			{
				firstName: '',
				lastName: '',
				sSN: '',
				group: number
			}
		]
	};

	function submitForm() {
		console.log(formValues);
	}

	let groups = [
		{
			id: 1,
			name: `Myran`
		},
		{
			id: 2,
			name: `Humlan`
		},
		{
			id: 3,
			name: `Fjärillen`
		},
		{
			id: 4,
			name: `Nyckelpigan`
		}
	];
</script>

<main>
	<form use:form on:submit|preventDefault={submitForm}>
		<h1>Registrering</h1>

		<h3>Vårdnadshavare</h3>

		<label for="phonenumber">Telefonnummer</label>
		<input
			type="phonenumber"
			name="phonenumber"
			use:validators={[required, phoneNumberCheck]}
			bind:value={formValues.careTaker.phoneNumber}
		/>
		<HintGroup for="phonenumber">
			<Hint on="required">{RequiredMsg('Telefonnummer')}</Hint>
			<Hint on="invalidPhoneNumber" hideWhenRequired>
				{$form.phonenumber.errors.invalidPhoneNumber}
			</Hint>
		</HintGroup>

		<label for="email">Epost</label>
		<input
			type="email"
			name="email"
			use:validators={[required, emailCheck]}
			bind:value={formValues.careTaker.email}
		/>
		<HintGroup for="email">
			<Hint on="required">{RequiredMsg('Epost')}</Hint>
			<Hint on="invalidEmail" hideWhenRequired>{$form.email.errors.invalidEmail}</Hint>
		</HintGroup>

		<label for="Firstname">Förnamn </label>
		<input
			type="text"
			name="Firstname"
			use:validators={[required]}
			bind:value={formValues.careTaker.firstName}
		/>
		<HintGroup for="Firstname">
			<Hint on="required">{RequiredMsg('Förnamn')}</Hint>
		</HintGroup>

		<label for="Lastname">Efternamn </label>
		<input
			type="text"
			name="Lastname"
			use:validators={[required]}
			bind:value={formValues.careTaker.lastName}
		/>

		<HintGroup for="Lastname">
			<Hint on="required">{RequiredMsg('Efternamn')}</Hint>
		</HintGroup>

		<label for="sSNnumber">Personnummer</label>
		<input
			name="sSNnumber"
			use:validators={[required, SSNCheck]}
			bind:value={formValues.careTaker.sSN}
		/>
		<HintGroup for="sSNnumber">
			<Hint on="required">{RequiredMsg('Personnummer')}</Hint>
			<Hint on="invalidSSN" hideWhenRequired>{$form.sSNnumber.errors.invalidSSN}</Hint>
		</HintGroup><br />

		<label for="address">Gatuaddress</label>
		<input
			type="text"
			name="address"
			use:validators={[required, streetAddressCheck]}
			bind:value={formValues.careTaker.streetaddress}
		/>
		<HintGroup for="address">
			<Hint on="required">{RequiredMsg('Gatuaddress')}</Hint>
			<Hint on="invalidStreetAddress" hideWhenRequired>
				{$form.address.errors.invalidStreetAddress}
			</Hint>
		</HintGroup>

		<label for="stad">Stad</label>
		<input
			type="text"
			name="stad"
			use:validators={[required, cityCheck]}
			bind:value={formValues.careTaker.city}
		/>
		<HintGroup for="stad">
			<Hint on="required">{RequiredMsg('Stad')}</Hint>
			<Hint on="invalidCity" hideWhenRequired>
				{$form.stad.errors.invalidCity}
			</Hint>
		</HintGroup>

		<label for="postalCode">Postkod</label>
		<input
			type="text"
			name="postalCode"
			use:validators={[required, postCodeCheck]}
			bind:value={formValues.careTaker.postalCode}
		/>
		<HintGroup for="postalCode">
			<Hint on="required">{RequiredMsg('Postkod')}</Hint>
			<Hint on="invalidCity" hideWhenRequired>
				{$form.stad.errors.invalidPostCode}
			</Hint>
		</HintGroup>

		<h3>Barn</h3>
		<label for="ChildFirstname">Förnamn</label>
		<input
			type="text"
			name="ChildFirstname"
			use:validators={[required]}
			bind:value={formValues.children[0].firstName}
		/>
		<HintGroup for="ChildFirstname">
			<Hint on="required">{RequiredMsg('Förnamn')}</Hint>
		</HintGroup>
		<label for="ChildLastname">Efternamn</label>
		<input
			type="text"
			name="ChildLastname"
			use:validators={[required]}
			bind:value={formValues.children[0].lastName}
		/>
		<HintGroup for="ChildLastname">
			<Hint on="required">{RequiredMsg('Efternamn')}</Hint>
		</HintGroup>

		<label for="sSNChild">Personnummer</label>
		<input
			name="sSNChild"
			use:validators={[required, SSNCheck]}
			bind:value={formValues.children[0].sSN}
		/>
		<HintGroup for="sSNChild">
			<Hint on="required">{RequiredMsg('Personnummer')}</Hint>
			<Hint on="invalidSSN" hideWhenRequired>{$form.sSNChild.errors.invalidSSN}</Hint>
		</HintGroup><br />

		<div class="form">
			<label for="group">Avdelning</label>
			<select class="drops" bind:value={formValues.children[0].group}>
				{#each groups as group}
					<option class="optDrop" value={group}>
						{group.name}
					</option>
				{/each}
			</select>
		</div>

		<button class="subButton" type="submit" disabled={!$form.valid}> Registrera </button>
	</form>
</main>

<style lang="less">
	.drops {
		width: 100%;
		margin-bottom: 3%;
		cursor: pointer;
	}

	:global(.touched:invalid) {
		border-color: red;
		outline-color: red;
	}

	main {
		flex: content;
		justify-content: center;
		height: 30em;
		width: 30em;
		position: relative;
		flex-wrap: nowrap;
		margin-bottom: 40%;
		left: 40%;
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

	.subButton {
		font-size: 20px !important;
	}
</style>

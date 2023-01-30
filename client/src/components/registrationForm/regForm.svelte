<script>
	import { useForm, Hint, HintGroup, validators, required, number } from 'svelte-use-form';
	import {
		SSNCheck,
		emailCheck,
		RequiredMsg,
		streetAddressCheck,
		phoneNumberCheck
	} from '$Utils/Validation';
	const form = useForm();
	let formValues = {
		careTaker: {
			email: '',
			address: '',
			phoneNumber: '',
			firstName: '',
			lastName: '',
			sSN: ''
		},
		child: {
			firstName: '',
			lastName: '',
			sSN: '',
			group: 
		}
	};

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
	<form use:form>
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

		<label for="address">Address</label>
		<input
			type="address"
			name="address"
			use:validators={[required, streetAddressCheck]}
			bind:value={formValues.careTaker.address}
		/>
		<HintGroup for="address">
			<Hint on="required">{RequiredMsg('Address')}</Hint>
			<Hint on="invalidStreetAddress" hideWhenRequired>
				{$form.address.errors.invalidStreetAddress}
			</Hint>
		</HintGroup>

		<h3>Barn</h3>
		<label for="ChildFirstname">Förnamn</label>
		<input
			type="text"
			name="ChildFirstname"
			use:validators={[required]}
			bind:value={formValues.child.firstName}
		/>
		<HintGroup for="ChildFirstname">
			<Hint on="required">{RequiredMsg('Förnamn')}</Hint>
		</HintGroup>
		<label for="ChildLastname">Efternamn</label>
		<input
			type="text"
			name="ChildLastname"
			use:validators={[required]}
			bind:value={formValues.child.lastName}
		/>
		<HintGroup for="ChildLastname">
			<Hint on="required">{RequiredMsg('Efternamn')}</Hint>
		</HintGroup>

		<label for="sSNChild">Personnummer</label>
		<input
			name="sSNChild"
			use:validators={[required, SSNCheck]}
			bind:value={formValues.child.sSN}
		/>
		<HintGroup for="sSNChild">
			<Hint on="required">{RequiredMsg('Personnummer')}</Hint>
			<Hint on="invalidSSN" hideWhenRequired>{$form.sSNChild.errors.invalidSSN}</Hint>
		</HintGroup><br />

		<div class="form">
			<select bind:value={child.group.number}>
				{#each groups as group}
					<option value={group}>
						{group.name}
					</option>
				{/each}
			</select>

			<input bind:value={selected} />
		</div>

		<button disabled={!$form.valid} on:click|preventDefault> Registrera </button>

		<!-- <pre>
		{JSON.stringify($form, null, 1)}
	</pre> -->
	</form>
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
		margin-bottom: 40%;
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

	/* pre {
		bottom: 0;
		height: 0px;
		width: 50px;
		overflow: none;
		font-size: 12px;
		position: absolute;
	} */
</style>

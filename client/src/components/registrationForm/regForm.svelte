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
	import { RegisterChildWithCaregivers } from '../../api/forms';
	import { onMount } from 'svelte';
	import { GetAllGroups } from '../../api/groups';
	import RegSent from '../regSentModal/regSent.svelte';
	let showModal = false;
	let message = '';

	const form = useForm();

	let formValues = {
		child: {
			sSN: '',
			firstName: '',
			lastName: '',
			eligebableGroups: []
		},
		caregivers: [
			{
				sSN: '',
				firstName: '',
				lastName: '',
				homeAddress: {
					streetAddress: '',
					city: '',
					postalCode: null
				},
				phoneNumber: '',
				emailAddress: ''
			}
			// {
			// 	sSN: '',
			// 	firstName: '',
			// 	lastName: '',
			// 	homeAddress: {
			// 		streetAddress: '',
			// 		city: '',
			// 		postalCode: null
			// 	},
			// 	phoneNumber: '',
			// 	emailAddress: ''
			// }
		]
	};

	function submitForm() {
		RegisterChildWithCaregivers(formValues).then((formResponse) => {
			console.log(formResponse);
			if (formResponse.caregivers && formResponse.child) {
				message = 'Information nu registrerat';
				showModal = true;
				resetFormFunction();
			} else {
				message = 'Något gick fel';
				showModal = true;
			}
		});
	}

	export let groups = [];

	onMount(async () => {
		GetAllGroups().then((data) => {
			if (data) {
				groups = data;
				console.log(groups);
			}
		});
	});

	function resetFormFunction() {
		document.getElementById('formy').reset();
	}
</script>

<main>
	<form id="formy" class="CCForm" use:form on:submit|preventDefault={submitForm}>
		<div class="Child">
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
		</div>
		<div class="form">
			<label for="group">Avdelning</label>
			{#if groups.length > 0}
				<select class="drops" bind:value={formValues.child.eligebableGroups[0]}>
					{#each groups as group}
						<option class="optDrop" value={group.id}>
							{group.name}
						</option>
					{/each}
				</select>
			{/if}
		</div>

		<div class="CareGiver1">
			<h3>Vårdnadshavare 1</h3>

			<label for="Firstname">Förnamn </label>
			<input
				type="text"
				name="Firstname"
				use:validators={[required]}
				bind:value={formValues.caregivers[0].firstName}
			/>
			<HintGroup for="Firstname">
				<Hint on="required">{RequiredMsg('Förnamn')}</Hint>
			</HintGroup>

			<label for="Lastname">Efternamn </label>
			<input
				type="text"
				name="Lastname"
				use:validators={[required]}
				bind:value={formValues.caregivers[0].lastName}
			/>

			<HintGroup for="Lastname">
				<Hint on="required">{RequiredMsg('Efternamn')}</Hint>
			</HintGroup>

			<label for="sSNnumber">Personnummer</label>
			<input
				name="sSNnumber"
				use:validators={[required, SSNCheck]}
				bind:value={formValues.caregivers[0].sSN}
			/>
			<HintGroup for="sSNnumber">
				<Hint on="required">{RequiredMsg('Personnummer')}</Hint>
				<Hint on="invalidSSN" hideWhenRequired>{$form.sSNnumber.errors.invalidSSN}</Hint>
			</HintGroup><br />

			<label for="email">Epost</label>
			<input
				type="email"
				name="email"
				use:validators={[required, emailCheck]}
				bind:value={formValues.caregivers[0].emailAddress}
			/>
			<HintGroup for="email">
				<Hint on="required">{RequiredMsg('Epost')}</Hint>
				<Hint on="invalidEmail" hideWhenRequired>{$form.email.errors.invalidEmail}</Hint>
			</HintGroup>

			<label for="phonenumber">Telefonnummer</label>
			<input
				type="phonenumber"
				name="phonenumber"
				use:validators={[required, phoneNumberCheck]}
				bind:value={formValues.caregivers[0].phoneNumber}
			/>
			<HintGroup for="phonenumber">
				<Hint on="required">{RequiredMsg('Telefonnummer')}</Hint>
				<Hint on="invalidPhoneNumber" hideWhenRequired>
					{$form.phonenumber.errors.invalidPhoneNumber}
				</Hint>
			</HintGroup>

			<label for="address">Gatuaddress</label>
			<input
				type="text"
				name="address"
				use:validators={[required, streetAddressCheck]}
				bind:value={formValues.caregivers[0].homeAddress.streetAddress}
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
				bind:value={formValues.caregivers[0].homeAddress.city}
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
				bind:value={formValues.caregivers[0].homeAddress.postalCode}
			/>
			<HintGroup for="postalCode">
				<Hint on="required">{RequiredMsg('Postkod')}</Hint>
				<Hint on="invalidCity" hideWhenRequired>
					{$form.stad.errors.invalidPostCode}
				</Hint>
			</HintGroup>
		</div>

		<button
			class="subButton"
			type="submit"
			disabled={!$form.valid || showModal}
			on:click={() => {
				showModal = true;
			}}
		>
			Registrera
		</button>
	</form>
	{#if showModal}
		<RegSent bind:showModal bind:message />
	{/if}
</main>

<style lang="less">
	.drops {
		width: 95%;
		margin-bottom: 3%;
		cursor: pointer;
	}

	:global(.touched:invalid) {
		border-color: red;
		outline-color: red;
	}

	main {
		justify-content: center;
		height: 100em;
		width: 30em;
		position: absolute;
		flex-wrap: nowrap;
		margin-bottom: 40%;
		left: 40%;
	}

	.CareGiver1,
	.CareGiver2,
	.Child {
		height: 100%;

		left: 20;
		width: 95%;
		top: 10;
		display: flex;
		align-items: left;
		justify-content: left;
		flex-direction: column;
		margin-bottom: 4%;
	}

	.subButton {
		font-size: 20px !important;
		margin-bottom: 20%;
		margin: auto;
		position: absolute;
		left: 33%;
	}
</style>

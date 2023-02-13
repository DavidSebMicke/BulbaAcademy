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



</script>

<form>
	<div class="form-group">
		<label for="Förnamn">Förnamn</label>
		<input name="Förnamn" label="Förnamn" placeholder="Skriv in ditt förnamn" />
		<label for="Efternamn"> Efternamn</label>
		<input name="Efternamn" label="Efternamn" placeholder="Skriv in ditt efternamn" />
		<label for="email"> E-postadress</label>
		<input type="mail" name="email" label="email" placeholder="Skriv in din e-postadress" />
	</div>
	<span class="subButt">
		<button class="classic-button" type="submit">Registrera</button>
	</span>
</form>

<style lang="less">
	.form-group {
		justify-content: center;
		height: 100em;
		width: 30em;
		position: absolute;
		flex-wrap: nowrap;
		margin-bottom: 40%;
		left: 40%;
		height: 100%;
		top: 10;
		display: flex;
		align-items: left;
		justify-content: left;
		flex-direction: column;
		margin-bottom: 4%;
	}
	.subButt {
		width: 95%;
		margin-bottom: 3%;
		cursor: pointer;
		position: relative;
		font-size: 20px !important;
		margin-bottom: 20%;
		align-self: flex-end;
		top: 100;
	}
</style>

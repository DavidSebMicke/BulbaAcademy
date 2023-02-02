<script>
	import { fade } from 'svelte/transition';
	import { createEventDispatcher } from 'svelte';
	import ClickOutside from '../../Utils/ClickOutside';
	import { useForm, HintGroup, validators, Hint, required } from 'svelte-use-form';

	
	import { GetFromSession, RemoveFromSession, StoreInSession } from '../../Utils/SessionStore';
	import { TOTPLogIn } from '../../api/user';

	const dispatch = createEventDispatcher();
	const form = useForm();

	export let title = "No title";
	export let noCloseButton = false;

	function CloseModal() {
		dispatch('message', {
			closeModal: true
		});

	}

    
    export let fieldParams = {
        label:"",
        placeholder:"write something..."
    };

    export let fieldValue = "";

    function onSendClick() {

		var twoFToken = GetFromSession("TwoFToken");
		RemoveFromSession("TwoFToken");

		if(twoFToken){
			console.log("Sending");

			TOTPLogIn(twoFToken, fieldValue).then(data => {
				
				if(data.userToken){

					console.log(data.userToken);
					StoreInSession("UserToken", data.userToken);
				}
				else{
					console.log("wrong code");
				}
			});
		}
		else{
			console.log("no token")
		}
		CloseModal();
	}


	//contenteditable="true"
</script>

<div class="modal" use:ClickOutside on:click_outside={CloseModal}>
	<div class="modal-container">
		<form name="sendCodeForm" use:form on:submit|preventDefault={onSendClick}>
			<div class="modal-header">
				<h2 class="modal-title">
					{title}
				</h2>
			</div>

			<div class="modal-content" >

				<div class="inputfield-container">
					{#if fieldParams.label}
						<label for="inputField">{fieldParams.label}</label>
					{/if}
					
					<input name="inputField" use:validators={[required]} bind:value={fieldValue} placeholder={fieldParams.placeholder} />
					
				</div>
			
			</div>

			
			<dev class="modal-footer">

				<button class="buttondispatch" disabled={!$form.valid}  type="submit">Send Code</button>
				{#if !noCloseButton}
					<button class="buttondispatch"  on:click={CloseModal} >Avbryt</button>
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
		background-color: rgba(0, 0, 0, 0.5);
		z-index: 10;
	}
	.buttondispatch {
		.classic-button;
		position: relative;

		font-weight: bold;
		width:fit-content;
		margin-left: 10px;
		margin-right: 10px;


	}

	.modal-text{
		padding: 20px;
	}
	.modal-container {
		position: fixed;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);

		width: 80%;
		max-width: 600px;

		z-index: 11;
		
	}

	.modal-title{

		text-align: center;
		margin: 0;

	}

	.modal-content{
		padding: 30px;
		height:fit-content;
		display: flex;
		flex-direction: column;
		
	}
	.modal-header{
		position: relative;
		top: 0;
		padding-top: 10px;
		padding-bottom: 10px;

	}

	.modal-footer{
		position: relative;
		bottom: 0;
		width: 100%;
		justify-content: right;
		
		flex-direction: row;
		margin: 0;


		display: flex;
		padding: 10px;

		.buttondispatch:first-of-type{
			margin-left: 0;
		}
		.buttondispatch:last-of-type{
			margin-right: 0;
		}
	}

	.inputfield-container{
        width: 100%;
    }


    input{
        width: 100%;
    }   
</style>

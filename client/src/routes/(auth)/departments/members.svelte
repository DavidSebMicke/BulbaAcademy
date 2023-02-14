<script>
	import { createEventDispatcher } from 'svelte';
	import ClickOutside from '../../../Utils/ClickOutside';

	export let members;
    export let showMembersList;
    let dispatch = createEventDispatcher();
	function showMembers() {
        dispatch('boolToggle', {
			Boolean: false,
        })
	}
</script>

	<div class="member-container" >
		<div class="member-info"use:ClickOutside on:click_outside={showMembers}>
            <h2>Medlemmar</h2>
			{#each members as member, i}
				<div class="member" style="grid-template-row='1' grid-column: {i}">
					<h3>
						{member.name}
					</h3>
                    <h4>
                        {member.role}
                    </h4>
                    <h4>
                        Telefon: {member.phoneNumber}
                        </h4>
                        <h4>
                        Epost: {member.email}
                        </h4>
				</div>
			{/each}
			<button class="closeCross" on:click={showMembers}
				><iconify-icon icon="material-symbols:close" width="40" /></button
			>
		</div>
	</div>

<style lang="less">
	@import 'public/less/global.less';

	.contactUs {
		.classic-button;
		padding: 10px 20px;
		align-self: center;
		width: 10em;
		font-weight: 700;
		font-size: x-large;
		font-family: 'Times New Roman', Times, serif;
		transition: all 1s;
		&:hover {
			cursor: pointer;
			color: var(--primary-color);
			size: 0;
		}
	}
	.member-container {
		position: fixed;
		top: 0;
		left: 0;
		width: 100%;
		height: 100%;
		background-color: rgba(0, 0, 0, 0.5);
		z-index: 10;
		background-color: none;
	}
	.member-info {
		position: fixed;
		text-align: center;
		overflow-y: scroll;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		background-color: var(--bg-color);
		width: 70%;
		height: 80%;
		max-width: 600px;
		padding: 20px;
		border: 3px solid;
		z-index: 11;
        h2{
            text-decoration: underline 8px solid;
        }
	}
	.member {
		border-bottom: 1px solid @light-mode-flavour1;
	}
	.closeCross {
		border: none;
    position: absolute;
    top: 0;
    right: 0;
    background-color: transparent;
    margin: 0;
    padding: 0;

		&:hover {
			cursor: pointer;
		}
	}
</style>

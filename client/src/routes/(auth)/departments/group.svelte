<script>
	import Members from "./members.svelte";

    export let group;
    let members = [
		{
			name: 'Ingrid',
			role: 'Lärare',
			phoneNumber: '070-313 33 33',
			email: 'hasse@bulbaacademy.awesome',
		},
		{
			name: 'Kerstin',
			role: 'Lärare',
			phoneNumber: '070-313 33 33',
			email: 'karen@bulbaacademy.awesome',
		},
		{
			name: 'Sten-Åke',
			role: 'Förälder',
			phoneNumber: '070-313 33 33',
			email: 'brollan@bulbaacademy.awesome',
		},
		{
			name: 'Håkan',
			role: 'Förälder',
			email: 'birgit@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
		},
		{
			name: 'Gudrun',
			role: 'Flat Earther',
			phoneNumber: '070-313 33 33',
			email: 'maja@bulbaacademy.awesome',
		},
		{
			name: 'Samuel',
			role: 'Förälder',
			email: 'lasse@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
		},
		{
			name: 'Lillemor',
			role: 'Förälder',
			email: 'magda@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
		},
		{
			name: 'Glenn',
			role: 'Vaktmästare',
			phoneNumber: '070-313 33 33',
			email: 'bertil@bulbaacademy.awesome',
		}
	];

    let showMembersList = false;
function closeList(event) {
showMembersList = event.detail.Boolean;
}
    function showMembers() {
		showMembersList = !showMembersList;
	}
  </script>
<div class="group">
    <h2>{group.name}</h2>
    {#if !showMembersList}
        <button class="member-list" on:click={showMembers}>Medlemmar</button>
        {:else}
        <Members {members} on:boolToggle={closeList} />
    {/if}
    <button class="member-list">Boka Aktivitet</button>

</div>

<style lang="less">
    @import 'public/less/variables.less';
    @import 'public/less/global.less';
    
.group {
  padding: 10px;
}

.group h2 {
  margin: 0 0 10px;
}

.group p {
  margin: 0;
  color: var(--color);
}
.member-list {
    .classic-button;
		padding: 10px 20px;
		align-self: center;
		width: 10em;
		font-weight: 700;
		font-size: x-large;
		font-family: 'Times New Roman', Times, serif;
        outline: 2px solid;
        outline-offset: -0.4em;
        outline-style:outset;

		&:hover {
			cursor: pointer;
			color: var(--primary-color);
			size: 0;
		}
}
</style>
  

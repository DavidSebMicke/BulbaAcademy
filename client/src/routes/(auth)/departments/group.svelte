<script>
	import Members from "./members.svelte";

    export let group;
    let members = [
		{
			id: 'public/img/Hasse.jfif',
			name: 'Hasse',
			profession: 'Teacher',
			phoneNumber: '070-313 33 33',
			email: 'hasse@bulbaacademy.awesome',
		},
		{
			id: 'public/img/Karen.jfif',
			name: 'Karen',
			profession: 'Headmaster',
			phoneNumber: '070-313 33 33',
			email: 'karen@bulbaacademy.awesome',
		},
		{
			id: 'public/img/Brollan.jfif',
			name: 'Brollan',
			profession: 'Janitor',
			phoneNumber: '070-313 33 33',
			email: 'brollan@bulbaacademy.awesome',
		},
		{
			id: 'public/img/Birgit.jfif',
			name: 'Birgit',
			profession: 'Teacher',
			email: 'birgit@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
		},
		{
			id: 'public/img/Maja.jfif',
			name: 'Maja',
			profession: 'Teacher',
			phoneNumber: '070-313 33 33',
			email: 'maja@bulbaacademy.awesome',
		},
		{
			id: 'public/img/Lasse.jfif',
			name: 'Lasse',
			profession: 'Arts & Craft',
			email: 'lasse@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
		},
		{
			id: 'public/img/Magda.jfif',
			name: 'Magda',
			profession: 'Woodcraft',
			email: 'magda@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
		},
		{
			id: 'public/img/Bertil.jfif',
			name: 'Bertil',
			phoneNumber: '070-313 33 33',
			email: 'bertil@bulbaacademy.awesome',
			profession: 'Coffe-drinker',
		}
	];

    let showMembersList = false;

    function showMembers() {
		showMembersList = !showMembersList;
	}
  </script>
<div class="group">
    <h2>{group.name}</h2>
    {#if !showMembersList}
        <button class="member-list">Medlemmar</button>
        {:else}
        <Members {members} />
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
  

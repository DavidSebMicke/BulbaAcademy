<script>
    import Group from './Group.svelte';
    export let groups;

</script>

<div class="group-List">
    {#each groups as group}
      <Group {group} />
    {/each}
  </div>



  <style lang="less">
.group-List {
  display: grid;
  justify-items: center; 
  align-items: center; 
  text-align: center;
  margin-top: 5em;
  gap: 0.5em;
  padding: 1em;
}

  </style>

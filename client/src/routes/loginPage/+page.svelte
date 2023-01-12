
<p class="step1">Logga in på Bulba Academy</p>
<script>
	
	function handleClick() {
		alert('Du är inloggad')
		
	}

	</script>


	<div class="step2">

	<p>Användarnamn<p><input value="">
	<p>Lösenord</p><input value="">

	
</div>
<div>
	<img src="public\img\bulba.png" alt="gfdkl">
</div>
<button on:click={handleClick}>
	Logga in
</button>

<style lang="less">
	@import 'public\less\variables.less';
	@import 'public\less\global.less'; 
	  
	.test {
		color: @second-sec-color;
		border: none;
	}
	
</style>
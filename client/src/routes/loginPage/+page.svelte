<script>
	
	function handleClick() {
		alert('Du är inloggad')
		
	}
	
</script>


<div class="griden">
	<div id="step1">Logga in i Bulba Academy</div>
	
	<div class="step2">

	<p>Användarnamn<br><input value="">
	<p>Lösenord<br><input value="">
		<br><br>
		
		<button id="step3" on:click={handleClick}>
			<h1>Logga in</h1>
		</button>
	</div>
	
	<img class="bulben" src="public\img\bulbi.jpg" alt="gfdkl">
	
</div>



<style lang="less">
	@import 'public\less\variables.less';
	@import 'public\less\global.less'; 
	@import url('https://fonts.googleapis.com/css2?family=Poiret+One&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Plus+Jakarta+Sans&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Inter&display=swap');

	
</style>
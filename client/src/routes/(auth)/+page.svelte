<script>
	import Calendar from '$components/calendar/calendar.svelte';
	import 'iconify-icon';
</script>

<div class="StartCalendar">
	<Calendar />
</div>

<style lang="less">
	@import 'public/less/variables.less';
	@import 'public/less/global.less';

	.StartCalendar {
		width: 80%;
		height: 70%;
		position: absolute;
		left: 10%;
		bottom: 3%;
	}
</style>

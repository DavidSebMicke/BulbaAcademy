<script>
	import Calendar from '$components/calendar/calendar.svelte';
	import 'iconify-icon';
	import Header from '$components/header/header.svelte'
</script>
<Header title="Bulba Academy" />
<div class="StartCalendar">
	<Calendar />
</div>

<style lang="less">
	@import 'public/less/variables.less';
	@import 'public/less/global.less';

	.StartCalendar {
		height: 90dvh;
		padding-top: 2rem;
		padding-left: 12rem;
	}
</style>

<script>
	import Calendar from '@event-calendar/core';
	import DayGrid from '@event-calendar/day-grid';
	import TimeGrid from '@event-calendar/time-grid';

	export let editable = false;
	export let events = [];

	let plugins = [TimeGrid, DayGrid];

	let options = {
		view: 'timeGridWeek',
		locale: 'en-gb', // en-gb locale for english days with 24h clock. Check later to see if locale has an impact on the calendar timezone
		firstDay: 1,
		scrollTime: '07:00:00',
		height: '100%',
		headerToolbar: {
			start: 'title',
			center: 'dayGridMonth,timeGridWeek',
			end: 'today prev,next'
		},
		hiddenDays: [0, 6],
		editable,
		events
	};
</script>

<Calendar {plugins} {options} />

<style>
</style>

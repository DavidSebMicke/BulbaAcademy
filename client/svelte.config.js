import sveltePreprocess from 'svelte-preprocess';
import less from 'svelte-preprocess';

/** @type {import('@sveltejs/kit').Config} */
const config = {
	preprocess: sveltePreprocess({}),
	preprocess: [less({})]
};

export default config;

import sveltePreprocess from 'svelte-preprocess';
import less from 'svelte-preprocess';
import adapter from "@sveltejs/adapter-auto";

/** @type {import('@sveltejs/kit').Config} */
const config = {
	preprocess: sveltePreprocess({}),
	preprocess: [less({})],
	kit: {
		adapter: adapter(),
		
	  },	  
	
};

export default config;

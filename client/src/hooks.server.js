import { redirect } from '@sveltejs/kit';

/** @type {import('@sveltejs/kit').Handle} */
export const handle = async ({ event, resolve }) => {
  const theme = event.cookies.get("siteTheme");

  if(event.route.id?.startsWith("/(auth)")){
    throw redirect(302, "/loginPage");
  }


  const response = await resolve(event, {
    transformPageChunk: ({ html }) =>
      html.replace('data-theme=""', `data-theme="${theme}"`),
  });
  return response;
};
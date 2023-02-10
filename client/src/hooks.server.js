import  { redirect } from '@sveltejs/kit';




/** @type {import('@sveltejs/kit').Handle} */
export const handle = async ({ event, resolve }) => {
  const theme = event.cookies.get("siteTheme");
  const loggedIn = event.cookies.get("LoggedIn");

  if(event.route.id.startsWith("/(auth)") && !loggedIn){
    throw redirect(302, "/loginPage");
  }
  else if(event.route.id.includes("/loginPage") && loggedIn){

    throw redirect(302, "/");
  }

  const response = await resolve(event, {
    transformPageChunk: ({ html }) =>
      html.replace('data-theme=""', `data-theme="${theme}"`),
  });
  return response;
};
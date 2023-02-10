import  { redirect } from '@sveltejs/kit';


/** @type {import('@sveltejs/kit').Handle} */
export const handle = async ({ event, resolve }) => {
  const theme = event.cookies.get("siteTheme");
  const idToken = event.cookies.get("IDToken");
  const user = event.cookies.get("LoggedInUser");

  if(event.route.id.startsWith("/(auth)") && !idToken && !user){
    throw redirect(302, "/loginPage");
  }
  else if(event.route.id.includes("/loginPage") && idToken && user){

    throw redirect(302, "/");
  }

  const response = await resolve(event, {
    transformPageChunk: ({ html }) =>
      html.replace('data-theme=""', `data-theme="${theme}"`),
  });
  return response;
};
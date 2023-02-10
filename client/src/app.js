import { removeCookie } from "./Utils/CookieUtils";

export function logOut(){
    removeCookie("IDToken", "/");
    removeCookie("LoggedInUser", "/");

    document.location.href="/loginPage";

}
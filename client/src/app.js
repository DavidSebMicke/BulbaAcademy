import { removeCookie, setCookie } from "./Utils/CookieUtils";
import { GetFromLocal, RemoveFromLocal, StoreInLocal } from "./Utils/LocalStore";

export function logOut(){

    RemoveFromLocal("IDToken");
    RemoveFromLocal("LoggedInUser");
    RemoveFromLocal("AccessToken");
    removeCookie("LoggedIn", true, "/");

    document.location.href="/loginPage";

}

export function logIn(logInData){

    if(!logInData.accessToken || !logInData.idToken || !logInData.loggedInUser) return false;

    StoreInLocal("IDToken", logInData.idToken);
    StoreInLocal("LoggedInUser", JSON.stringify(logInData.loggedInUser));
    StoreInLocal("AccessToken", logInData.accessToken);
    setCookie("LoggedIn", true, "/");

    return true;
}

export function CheckUserData(){


    let accessToken = GetFromLocal("AccessToken");
    let idToken = GetFromLocal("IDToken");
    let loggedInUser = GetFromLocal("LoggedInUser");


    if(!accessToken || !idToken || !loggedInUser){
        logOut();
    }

	
}


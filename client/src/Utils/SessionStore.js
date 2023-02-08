export function StoreInSession(name, value){

    window.sessionStorage.setItem(name, value);
}

export function GetFromSession(name){

    return window.sessionStorage.getItem(name);
}


export function RemoveFromSession(name){

    return window.sessionStorage.removeItem(name);
}
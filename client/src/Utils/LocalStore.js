export function StoreInLocal(name, value){

    window.localStorage.setItem(name, value);
}

export function GetFromLocal(name){

    return window.localStorage.getItem(name);
}


export function RemoveFromLocal(name){

    return window.localStorage.removeItem(name);
}
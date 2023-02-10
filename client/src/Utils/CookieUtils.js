export function setCookie(name, value, path){
    document.cookie = `${name}=${value}; path=${path}; SameSite=None; Secure`;

}


export function removeCookie(name, path){
     document.cookie = `${name}=; path=${path}; SameSite=None; max-age=0; path=/; Secure`;
}
document.addEventListener('DOMContentLoaded', main)

async function main(){
    alert("Macskák")

    let macskafaktdiv = document.querySelector('#macskafakt');
    macskafaktdiv.innerHTML='X';
    let url = fetch("https://catfact.ninja/fact")
    let szotar = await olvaso_fetch(url);
    console.log(szotar['fact']);
    macskafaktdiv.innerHTML=szotar.fact;
}

function olvaso_fetch(url){
    let promise = await fetch(url)
    let promise_json = await promise.json();
    return promise_json;
}


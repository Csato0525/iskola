document.addEventListener('DOMContentLoadaded', main);
function main()
{
    alert('hali')
    m = document.querySelector('main');

    feladatok = [
        {cim: '3000M', tartalom: 'ez egy jo nehez feladat'},
        {cim: '3000L', tartalom: 'ez egy jo nehez feladat ok'},
        {cim: '3000O', tartalom: 'ez egy jo nehez feladat okok'},
        {cim: '3000J', tartalom: 'ez egy jo nehez feladat nem'},
    ]
    for (const feladat of feladatok) {
        let d = document.createElement('div');
        d.setAttribute('class','maindiv')
        d.innerHTML = `<h2>${feladat.nev}</h2>
                <p class="tartalom">${feladat.tartalom}</p>
                <div>ítélet:</div>
                <select id="">
                    <option value="elfogadva">Elfogadva</option>
                    <option value="hibas">Hibás</option>
                    <option value="hianyos">Hiányos</option>
                    <option value="ertektelen">Értéktelen</option>
                </select>`
        m = document.querySelector('main')
        m.appendChild(d)
    }
}



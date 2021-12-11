
const UI={
    number: document.querySelector('.number').querySelector('h1'),
    button1:document.querySelector('#button1'),
    button3:document.querySelector('#button3'),
    onMoveDiv: document.querySelector('.hw2'),
    coords:{
        x: document.querySelector('.x'),
        y: document.querySelector('.y'),
        button: document.querySelector('.button')
    },
    text: document.querySelector(".text")
};
//Практическое задание №1
//Задание 1


UI.button1.onclick = () => {
    UI.number.innerText=Math.floor(Math.random()*100+1);
}

//Задание 2
UI.onMoveDiv.onmousemove = (ev) => {
    UI.coords.x.innerText=ev.x;
    UI.coords.y.innerText=ev.y;
}

UI.onMoveDiv.onmousedown = (ev) => {
    ev=ev|| window.event;
    switch(ev.button){
        case 0:
            UI.coords.button.innerText = 'Left bullon';
            break;
        case 1:
            UI.coords.button.innerText = 'Middle bullon';
            break;
        case 2:
            UI.coords.button.innerText = 'Right bullon';
            break;
        }
}

//Задание 3
UI.button3.onclick = () => {
    if(UI.text.style.visibility === 'hidden') UI.text.style.visibility = 'visible'
    else UI.text.style.visibility = 'hidden';
}

//Задание 4

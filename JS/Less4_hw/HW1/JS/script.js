console.log("Hello");

function init(){
    const newBtn=document.querySelector('#newBtn');
    newBtn.onclick=()=>{
        let size=document.querySelector('#size').value;
        if(size !='') newGame(parseInt(size,10));
    }
    let lastGame=localStorage.getItem('lastGame')?localStorage.getItem('lastGame'):[];
    if(lastGame.length!==0){
        let continueBtn=document.createElement('input');
        continueBtn.type='button';
        continueBtn.className='continueBtn';
        continueBtn.value='Continue game';
        continueBtn.onclick = () => {
            continueGame();
        }
        const panel=document.body.querySelector('.buttonsPanel');
        panel.appendChild(continueBtn);
    }
}

function createBoard(){
    let board=document.querySelector('.board');
    if(board) board.remove();
    board=document.createElement('div');
    board.className='board';
    document.body.appendChild(board);
    board.onmousedown = (e) => {
        isSwipe = true;
        x=e.x;
        y=e.y;
    }
    board.onmouseup = (e) => {
        isSwipe = false;
        const moveX=x-e.x;
        const moveY=y-e.y;
        if(Math.abs(moveX)>40 || Math.abs(moveY)>40){
            if(Math.abs(moveX) > Math.abs(moveY)){
               if(moveX>0) moveLeft(); else moveRight();
            }
            else{
                if(moveY > 0) moveUp(); else moveDown();  
            } 
        }
    }
    return board;
}

function newGame(size){
    let board=createBoard();
    for(let i=1; i<=size; i++){
        let row=document.createElement('div');
        row.classList.add('row');
        for(let j=1; j<=size; j++){
            let cell=document.createElement('div');
            cell.classList.add('cell',`col${j}`,`row${i}`,'empty');
            row.appendChild(cell);
        }
        board.appendChild(row);
    }
    addNumber();
    addNumber();
}

function continueGame(){
    let board=createBoard();
    board.innerHTML=localStorage.getItem('lastGame');
}

function addNumber(){
    let arrayCells = document.querySelectorAll('.empty');
    if(arrayCells.length === 0){
        let text=document.createElement('h1');
        text.innerHTML='Game Over!';
        document.body.appendChild(text);
        let board=document.querySelector('.board');
        board.classList.add('disabled');
        return;
    }
    let cell=Math.floor(Math.random()*arrayCells.length+1);
    arrayCells[cell-1].innerHTML='2';
    arrayCells[cell-1].id='num-2';
    arrayCells[cell-1].classList.remove('empty');
    save();
}

function moveDown(){
    const rows = document.body.querySelectorAll('.row');
    for(let i=1; i<=rows.length; i++){
        const startNum=rows.length-1;
        const endNum=0;
        let currNum=startNum;
        const cells = document.body.querySelectorAll(`.col${i}`);
        let isEmpty=false;
        while(currNum!==endNum && isEmpty==false){
            if(cells[currNum].innerHTML.length === 0){
                for(let j=currNum-1; j>=endNum; j--){
                    if(cells[j].innerHTML.length !== 0){
                        cells[currNum].innerHTML=cells[j].innerHTML;
                        cells[currNum].classList.remove('empty');
                        cells[currNum].id=cells[j].id;
                        cells[j].innerHTML='';
                        cells[j].classList.add('empty');
                        cells[j].id='';
                        isEmpty=false;
                        break;
                    }
                    else{
                        isEmpty=true;
                    }
                }
            }
            else{
                for(let j=currNum-1; j>=endNum; j--){
                    if(cells[j].innerHTML.length !== 0){
                        if(cells[j].innerHTML===cells[currNum].innerHTML)
                        {
                            cells[currNum].innerHTML=parseInt(cells[currNum].innerHTML,10)+parseInt(cells[j].innerHTML,10);
                            cells[j].innerHTML='';
                            cells[j].classList.add('empty');
                            cells[j].id='';
                            cells[currNum].id=`num-${cells[currNum].innerHTML}`;
                        }
                        currNum--;
                        isEmpty=false;
                        break;
                    }
                    else{
                        isEmpty=true;
                    }
                }
            }
        }
    }
    addNumber();
}

function moveUp(){
    const rows = document.body.querySelectorAll('.row');
    for(let i=1; i<=rows.length; i++){
        const startNum=0;
        const endNum=rows.length-1;
        let currNum=startNum;
        const cells = document.body.querySelectorAll(`.col${i}`);
        let isEmpty=false;
        while(currNum!==endNum && isEmpty==false){
            if(cells[currNum].innerHTML.length === 0){
                for(let j=currNum+1; j<=endNum; j++){
                    if(cells[j].innerHTML.length !== 0){
                        cells[currNum].innerHTML=cells[j].innerHTML;
                        cells[currNum].classList.remove('empty');
                        cells[currNum].id=cells[j].id;
                        cells[j].innerHTML='';
                        cells[j].classList.add('empty');
                        cells[j].id='';
                        isEmpty=false;
                        break;
                    }
                    else{
                        isEmpty=true;
                    }
                }
            }
            else{
                for(let j=currNum+1; j<=endNum; j++){
                    if(cells[j].innerHTML.length !== 0){
                        if(cells[j].innerHTML===cells[currNum].innerHTML)
                        {
                            cells[currNum].innerHTML=parseInt(cells[currNum].innerHTML,10)+parseInt(cells[j].innerHTML,10);
                            cells[j].innerHTML='';
                            cells[j].classList.add('empty');
                            cells[j].id='';
                            cells[currNum].id=`num-${cells[currNum].innerHTML}`;
                        }
                        currNum++;
                        isEmpty=false;
                        break;
                    }
                    else{
                        isEmpty=true;
                    }
                }
            }
        }
    }
    addNumber();
}

function moveRight(){
    const rows = document.body.querySelectorAll('.row');
    for(let i=1; i<=rows.length; i++){
        const startNum=rows.length-1;
        const endNum=0;
        let currNum=startNum;
        const cells = document.body.querySelectorAll(`.row${i}`);
        let isEmpty=false;
        while(currNum!==endNum && isEmpty==false){
            if(cells[currNum].innerHTML.length === 0){
                for(let j=currNum-1; j>=endNum; j--){
                    if(cells[j].innerHTML.length !== 0){
                        cells[currNum].innerHTML=cells[j].innerHTML;
                        cells[currNum].classList.remove('empty');
                        cells[currNum].id=cells[j].id;
                        cells[j].innerHTML='';
                        cells[j].classList.add('empty');
                        cells[j].id='';
                        isEmpty=false;
                        break;
                    }
                    else{
                        isEmpty=true;
                    }
                }
            }
            else{
                for(let j=currNum-1; j>=endNum; j--){
                    if(cells[j].innerHTML.length !== 0){
                        if(cells[j].innerHTML===cells[currNum].innerHTML)
                        {
                            cells[currNum].innerHTML=parseInt(cells[currNum].innerHTML,10)+parseInt(cells[j].innerHTML,10);
                            cells[j].innerHTML='';
                            cells[j].classList.add('empty');
                            cells[j].id='';
                            cells[currNum].id=`num-${cells[currNum].innerHTML}`;
                        }
                        currNum--;
                        isEmpty=false;
                        break;
                    }
                    else{
                        isEmpty=true;
                    }
                }
            }
        }
    }
    addNumber();
}

function moveLeft(){
    const rows = document.body.querySelectorAll('.row');
    for(let i=1; i<=rows.length; i++){
        const startNum=0;
        const endNum=rows.length-1;
        let currNum=startNum;
        const cells = document.body.querySelectorAll(`.row${i}`);
        let isEmpty=false;
        while(currNum!==endNum && isEmpty==false){
            if(cells[currNum].innerHTML.length === 0){
                for(let j=currNum+1; j<=endNum; j++){
                    if(cells[j].innerHTML.length !== 0){
                        cells[currNum].innerHTML=cells[j].innerHTML;
                        cells[currNum].classList.remove('empty');
                        cells[currNum].id=cells[j].id;
                        cells[j].innerHTML='';
                        cells[j].classList.add('empty');
                        cells[j].id='';
                        isEmpty=false;
                        break;
                    }
                    else{
                        isEmpty=true;
                    }
                }
            }
            else{
                for(let j=currNum+1; j<=endNum; j++){
                    if(cells[j].innerHTML.length !== 0){
                        if(cells[j].innerHTML===cells[currNum].innerHTML)
                        {
                            cells[currNum].innerHTML=parseInt(cells[currNum].innerHTML,10)+parseInt(cells[j].innerHTML,10);
                            cells[j].innerHTML='';
                            cells[j].classList.add('empty');
                            cells[j].id='';
                            cells[currNum].id=`num-${cells[currNum].innerHTML}`;
                        }
                        currNum++;
                        isEmpty=false;
                        break;
                    }
                    else{
                        isEmpty=true;
                    }
                }
            }
        }
    }
    addNumber();
}

function save(){
    const forSave=document.querySelector('.board').innerHTML;
    localStorage.setItem('lastGame', forSave);
}


let isSwipe=false;
let x=0;
let y=0;
init();

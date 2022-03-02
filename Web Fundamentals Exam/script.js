function clickRemove(button){
    button.remove();
}

var count212=212;
var countElement212=document.querySelector("#count212");

function like1(){
    count212++
    countElement212.innerText=count212
    console.log(count212);
}

var count32=32;
var countElement32=document.querySelector("#count32");

function like2(){
    count32++
    countElement32.innerText=count32
    console.log(count32);
}

var count68=68;
var countElement68=document.querySelector("#count68");

function like3(){
    count68++
    countElement68.innerText=count68
    console.log(count68);
}

var search=document.querySelector("#search");

function getValue(){
    alert('You are searching for ' + search.value)
}
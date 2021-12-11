//Практическое задание №5
//Задание 1
class Button{

    constructor(height, width, text){
        this.height=height;
        this.width=width;
        this.text=text;
    }

    showBtn(){
        const htmlcode=`<input type=button height=${this.height}px width=${this.width}px value="${this.text}">`;
        document.write(htmlcode);
    }
}

class BootstrapButton extends Button{

    constructor(height, width, text, color){
        super(height, width, text);
        this.color=color;
    }

    showBtn(){
        const htmlcode=`<input style="background-color: ${this.color}" type=button height=${this.height}px width=${this.width}px value="${this.text}">`;
        document.write(htmlcode);
    }
}

const btn = new Button(20, 50, "Submit");
btn.showBtn();

const btnbootstrap = new BootstrapButton(20, 50, "Submit", "white");
btnbootstrap.showBtn();

//Задание 2
class figure{

    name='';
    res=0;

    constructor(a, b){
        this.a=a;
        this.b=b;
    }

    get Name(){
        return `<br>${this.name}`;
    }

    square(){
        return `<br>Square of the ${this.name} = ${res}`;
    }

    perimeter(){
        return `<br>Perimeter of the ${this.name} = ${res}`;
    }

    getInfo(){
        return `<br>a = ${this.a}, b = ${this.b}`;
    }
}

class triangle extends figure{
    name="Triangle";
    constructor (a, b, c, h){
        super(a, b);
        this.c=c;
        this.h=h;
    }

    square(){
        this.res=0.5*this.a*this.h;
        return `<br>Square of the ${this.name} = ${this.res}`;
    }

    perimeter(){
        this.res=this.a+this.b+this.c;
        return `<br>Perimeter of the ${this.name} = ${this.res}`;
    }

    getInfo(){
        return `<br>a = ${this.a}, b = ${this.b}, c = ${this.c}, h = ${this.h}`;
    }
}

class square extends figure{
    name="Square";
    constructor (a, b){
        super(a, b);
    }

    square(){
        this.res=this.a*2;
        return `<br>Square of the ${this.name} = ${this.res}`;
    }

    perimeter(){
        this.res=this.a*4;
        return `<br>Perimeter of the ${this.name} = ${this.res}`;
    }

    getInfo(){
        return `<br>a = ${this.a}`;
    }
}

class rectangle extends figure{
    name="Rectangle";
    constructor (a, b){
        super(a, b);
    }

    square(){
        this.res=this.a*this.b;
        return `<br>Square of the ${this.name} = ${this.res}`;
    }

    perimeter(){
        this.res=this.a*this.b*2;
        return `<br>Perimeter of the ${this.name} = ${this.res}`;
    }

}

const arr = [new triangle(10,10,20,6), new square(10), new rectangle(10,5)];

for(let i=0; i<arr.length; i++)
{
    document.write(arr[i].Name);
    document.write(arr[i].getInfo());
    document.write(arr[i].perimeter());
    document.write(arr[i].square());
    document.write("<br>");
}

//Задание №3

class ExtentedArray extends Array{

    getString(separator){
        return this.join(separator);
    }

    getHtml(tagName){
        const str=this.map(x => `<${tagName}>${x}</${tagName}>`);
        if(tagName === "li") return `<ul>${str.getString("")}</ul>`
        else return str.getString("");
    }
}

const extArr = new ExtentedArray (1,2,3,7,8,9,0,4,5,6);

document.write(extArr.getHtml("li"));
document.write(extArr.getString(","));

//Домашнее задание №5
//Задание 1

class marker{
    color = "#fff";
    volume = 100;
    constructor(color){
        this.color=color;
    }

    print(text){
        const str=[...text];
        if(this.volume>0){
            document.write(`<br><font color="${this.color}">`)
            str.forEach(element => {
                if(this.volume>0){
                    document.write(element);
                    if(element != " "){
                        this.volume-=0.5;
                    }
                }
            });
            document.write(`</font>`);
        }
    }
}

const mark=new marker("green");
mark.print("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
mark.print("Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

class refMarker extends marker{
    reFill(){
        this.volume=100;
    }
}

const refMark=new refMarker("blue");
refMark.print("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
refMark.print("Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");
refMark.reFill();
refMark.print("Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");

//Задание 2

class ExtendedDate extends Date{
    dateToText(){
        const date=this.getDate();
        const arr1=["первое", "второе", "третье", "четвертое", "пятое", "шестое", "седьмое", "восьмое", "девятое", "десятое", "одинадцатое", "двенадцатое", "тринадцатое", "четырнадцатое", "пятнадцатое", "шетнадцатое", "семнадцатое", "восемнадцатое", "девятнадцатое", "двадцатое"];
        const arr2=["двадцать", "тридцатое", "тридцать первое"];
        var options = {  month: 'long' };
        const month=newDate.toLocaleDateString('ru-ru', options);
        if(date<=20) return month+" "+arr1[date-1]
        else if(date<30) return month+" "+arr2[0]+" "+arr1[date%10-1]
        else if(date===30) return month+" "+arr2[1]
        else if(date===31) return month+" "+arr2[2];
    }

    checkDate(){
        const now=new Date(Date.now());
        const today=new Date(`${now.getFullYear()}-${now.getMonth()+1}-${now.getDate()}`);
        return (this<today)?false:true;
    }

    checkYear(){
        const year=this.getFullYear();
        if(year%4!=0) return false
        else if(year%100!=0) return true
        else if(year%400==0)return true
        else return false;
    }

    nextDate(){
        const nextDay = new Date(this);
        nextDay.setDate(this.getDate() + 1);
        return nextDay;
    }
}

const newDate= new ExtendedDate("2021-12-31");
document.write(newDate.dateToText());
document.write(newDate.checkDate());
document.write(newDate.checkYear());
document.write(newDate.nextDate());

//Задание 3

class Employee{
    constructor(firstName, lastName, age, address){
        this.firstName=firstName;
        this.lastName=lastName;
        this.age=age;
        this.address=address;
    }
}

class EmpTable{
    body="";
    constructor(...arr){
        this.arr=arr;
    }

    getHtml(){
        const start="<table><tbody><thead><tr><td>FirstName</td><td>LastName</td><td>Age</td><td>Address</td></tr></thead>";
        const end="</tbody></table>";
        this.arr.forEach(element => {
            this.body+=`<tr><td>${element.firstName}</td><td>${element.lastName}</td><td>${element.age}</td><td>${element.address}</td></tr>`;
        })
        return start+this.body+end;
    }
}

    const emplTable=new EmpTable(
    new Employee('Vasya', 'Pupkin',23,'Dnipro'),
    new Employee('Petya', 'Ivanov', 31, 'Mariupol')
)

document.write(`<br>${emplTable.getHtml()}`);

//Задание 4

class StyledEmpTable extends EmpTable{
    getStyles(){
        const styleStart="<style type='text/css'>"
        const styleEnd="</style>";
        const styleTable=".styledTable {width: 100%; border: 1px solid gray;} .styledTable thead { font-weight: bold; } .styledTable td { border: 1px solid gray; }";
        return styleStart+styleTable+styleEnd;
    }

    getHtml(){
        const html=super.getHtml().replace("<table>","<table class='styledTable'>");
        // html=html.replace("<table>","<table class='styledTable>'");
        return this.getStyles()+html;
    }
}

    const sEmplTable=new StyledEmpTable(
    new Employee('Vasya', 'Pupkin',23,'Dnipro'),
    new Employee('Petya', 'Ivanov', 31, 'Mariupol')
)

document.write(`<br>${sEmplTable.getHtml()}`);

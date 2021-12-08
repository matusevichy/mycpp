//Task 1
function compare(a,b)
{
    if(a<b) return -1
    else if(a>b) return 1
    else return 0;
}

function factorial(a)
{
    let n;
    if(a==0) return 1
    else
    {
        return a*factorial(a-1)
    }
}

function makenum(a,b,c)
{
    return a*100+b*10+c;
}

function square(a,b)
{
    if(a && b) return a*b
    else if(a && !b) return a*a
    else if(!a && b) return b*b
    else return "Error"
}

function isperfect(a)
{
    let n=0;
    for(let i=a-1; i>0; i--)
    {
        if(a%i == 0) n+=i
    }
    if(n == a) return true
    else return false
}

function findperfect(a,b)
{
    let min=a,max=b;
    if(a>b)
    {
        min=b;
        max=a;
    }
    for(let i=min; i<=max; i++)
    {
        if(isperfect(i)) document.write(i+'<br>')
    }
}

function maketime(h,m,s)
{
    if(h === undefined) return 'Error data';
    if(h<10) h='0'+h;
    if(m<10) m='0'+m;
    if(s<10) s='0'+s;
    return `${h} : ${m || '00'} : ${s || '00'}`;

}

function converttime2sec(h,m,s)
{
    return (h*60*60+m*60+s || 0);
}

function maketimefromsec(s)
{
    let h = (s >=3600)? Math.floor(s/3600) : 0;
    s = (s >=3600)? s - h*3600 : s;
    let m = (s>=60)? Math.floor(s/60) : 0;
    s = (s >=60)? s - m*60 : s;
    return maketime(h,m,s);
}

function calctimebetween(h1,m1,s1,h2,m2,s2)
{
    let sec1=converttime2sec(h1,m1,s1);
    let sec2=converttime2sec(h2,m2,s2);
    if(sec1>sec2) return maketimefromsec(converttime2sec(23,59,59)-sec1+1+sec2)
    else return maketimefromsec(sec2-sec1);
}

document.write('Task 1<br>');

document.write(compare(10,20)+"<br>");

document.write(factorial(5)+"<br>");

document.write(makenum(5,0,1)+"<br>");

document.write(square(0,4)+"<br>");

document.write(isperfect(28)+"<br>");

findperfect(10,9028);

document.write(maketime()+"<br>");

document.write(converttime2sec(1,1,1)+"<br>");

document.write(maketimefromsec(123761)+"<br>");

document.write(calctimebetween(23,10,0,0,10,0)+"<br>");

//Task 2

function min(a,b)
{
    return (a<b)? a:b;
}

function pov(a,b)
{
    if(b==0) return 1;
    let n=1;
    for(let i=1; i<=Math.abs(b);i++)
    {
        n*=a;
    }
    if(b>0) return n;
    if(b<0) return 1/n;
}

function calc(a,b,act)
{
    switch(act){
    case '+':
        return a+b;
        break;
    case '-':
        return a-b;
        break;
    case '*':
        return a*b;
        break;
    case '/':
        return a/b;
        break;
    }
}

function isprime(a)
{
    if(a<=0 || a!=Math.abs(a)) return false;
    for(let i=2;i<a; i++)
    {
        if(a%i == 0) return false;
    }
    return true;
}

function makemulttable(a)
{
    if(a<2 || a>9) return false;
    let s='';
    for(let i=1; i<=10; i++)
    {
        s+=`${a} * ${i} = ${a*i}<br>`;
    }
    return s;
}

function remainder(a,b)
{
    if(b == 0) return 'Dividion by zero';
    while(a>=b)
    {
        a-=b;
    }
    return a;
}

function sum(...args)
{
    let s=0;
    for(let i=0;i<args.length;i++)
    {
        s+=args[i];
    }
    return s;
}

function max(...args)
{
    let s=args[0];
    for(let i=1;i<args.length;i++)
    {
        if(s<args[i]) s=args[i];
    }
    return s;
}

function getnumbersby(min, max, arg)
{
    let arr = [1,2];
    arr = Array.from({length:max-min+1},(v,k)=>min+k);
    let newarr;
    if(arg === true) newarr=arr.filter(item => item%2 == 0)
    else newarr=arr.filter(item => item%2 != 0)
    return newarr;
}

function nextday(d,m,y)
{
    let nextday;
    if(d <= 0 || d > 31 || m <= 0 || m>12 || y <= 0) return "Error";
    if([4,6,9,11].includes(m)){
        if(d>30) return "Error";
        if(d==30){
            d=1;
            if(m==12){
                m=1;
                y++;
            }
            else m++;
        }
        else d++;
    } 
    else if([1,3,5,7,8,10,12].includes(m)){
        if(d==31){
            d=1;
            if(m==12){
                m=1;
                y++;
            }
            else m++;
        }
        else d++;
    }
    else{
        if(isleapyear(y)){
            if(d==29){
                d=1;
                if(m==12){
                    m=1;
                    y++;
                }
                else m++;
            }
            else d++;
        }
        else{
            if(d==28){
                d=1;
                if(m==12){
                    m=1;
                    y++;
                }
                else m++;
            }
            else d++;
        }
    }
    return `${(d<10)?'0'+d:d}.${(m<10)?'0'+m:m}.${(y<1000)?(y<100)?(y<10)?'000'+y:'00'+y:'0'+y:y}` 
}

function isleapyear(y)
{
    if(y%4!=0) return false
    else if(y%100!=0) return true
    else if(y%400==0)return true
    else return false;
}

document.write('Task 2<br>');
document.write(min(10,20)+"<br>");
document.write(pov(2,-1)+"<br>");
document.write(calc(2,-2,'/')+"<br>");
document.write(isprime(5)+"<br>");
document.write(makemulttable(9)+"<br>");
document.write(remainder(59,4)+"<br>");
document.write(sum(1,2,3,4,5)+"<br>");
document.write(max(1,2,30,4,5)+"<br>");
document.write(getnumbersby(5,20,false)+"<br>");
document.write(nextday(29,02,1980,false)+"<br>");



function makeRequest(url, act, num) {
    var httpRequest = false;

    if (window.XMLHttpRequest) { // Mozilla, Safari, ...
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }
    } else if (window.ActiveXObject) { // IE
        try {
            httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {}
        }
    }

    if (!httpRequest) {
        alert('Невозможно создать экземпляр класса XMLHTTP ');
        return false;
    }
    httpRequest.onreadystatechange = function() { getContent(httpRequest, act, num); };
    httpRequest.open('GET', url, true);
    httpRequest.send(null);
}

function getContent(httpRequest, act, num) {

    if (httpRequest.readyState == 4) {
        if (httpRequest.status == 200) {
            if(act === 'getlist')
            {
                moviesList(JSON.parse(httpRequest.responseText),num);
            }
            else if(act === 'getinfo')
            {
                movieInfo(JSON.parse(httpRequest.responseText));
            }
            const result=JSON.parse(httpRequest.responseText);
            console.log(result);
        } else {
            alert('С запросом возникла проблема.');
        }
    }

}

function moviesList(result, pageNum){ 
    movies.remove();
    movies=document.createElement("div");
    content.insertBefore(movies, footer);
    listBlock=document.createElement('div');
    listBlock.className='list-block';
    if(result.Response == "True")
    {
        for(let i=0; i<=result.Search.length-1; i++)
        {
            listBlock.innerHTML+=`<div class="list-item"><img src="${(result.Search[i].Poster == "N/A")? "Images/placeholder.png" : result.Search[i].Poster}"><div class="info"><div class="type">${result.Search[i].Type}</div><div class="title">${result.Search[i].Title}</div><div class="year">${result.Search[i].Year}</div><div class="details"><input type="button" class="deatilsBtn" value="Details" onclick="getMovieInfo('${result.Search[i].imdbID}')"></div></div></div>`;
        }
    }
    else
    {
        listBlock.innerHTML=`<h1>${result.Error}</h1>`;
    }
    movies.insertBefore(listBlock, footer);
    if(result.Response == "True")
    {
        createPaginator(pageNum, result.totalResults);
    }
}

function createPaginator(pageNum, totalResults){
    paginator=document.createElement("div");
    paginator.className="paginator";
    if(pageNum>0)
    {
        paginator.innerHTML+=`<input type="button" value="<<" onclick="goToPage(${pageNum-1})">`;
    }
    else
    {
        paginator.innerHTML+=`<input type="button" value="<<" class="disabled">`;
    }
    const start = (pageNum < 9)? 0: pageNum-1;
    const end = (pageNum < 9)? 10: 10+pageNum-1;
    for(let j=start;j<end&&j<totalResults/10;j++)
    {
        if(j == pageNum) paginator.innerHTML+=`<input type="button" value="${j+1}" class="current">`
        else
        {
            paginator.innerHTML+=`<input type="button" value="${j+1}" onclick="goToPage(${j})">`;
        }
    }
    if(pageNum<totalResults/10-1)
    {
        paginator.innerHTML+=`<input type="button" value=">>" onclick="goToPage(${pageNum+1})">`;
    }
    else
    {
        paginator.innerHTML+=`<input type="button" value=">>" class="disabled">`;
    }
    movies.insertBefore(paginator, footer);
}

function goToPage(pageNum){
    const title=document.querySelector("#title");
    const url=`http://www.omdbapi.com/?apikey=f807d897&s=${title.value}&type=${type.options[type.selectedIndex].value}&page=${pageNum+1}`;
    console.log(url);
    makeRequest(url,'getlist',pageNum);
}

function movieInfo(result){
    let movie=document.querySelector(".movie-block");
    console.log(movie);
    if(movie) movie.remove();
    movie=document.createElement("div");
    movie.className="movie-block";
    movie.innerHTML+=`<img src="${(result.Poster == "N/A")? "Images/placeholder.png" : result.Poster}">`;
    movie.innerHTML+=`  <div class="info">
                            <div><div class="label">Title:</div>${result.Title}</div>
                            <div><div class="label">Released:</div>${result.Released}</div>
                            <div><div class="label">Genre:</div>${result.Genre}</div>
                            <div><div class="label">Country:</div>${result.Country}</div>
                            <div><div class="label">Director:</div>${result.Director}</div>
                            <div><div class="label">Writer:</div>${result.Writer}</div>
                            <div><div class="label">Actors:</div>${result.Actors}</div>
                            <div><div class="label">Awards:</div>${result.Awards}</div>
                        </div>`;
    movies.insertBefore(movie, footer);
}

function getMovieInfo(id){
    const url=`http://www.omdbapi.com/?apikey=f807d897&i=${id}&plot=full`;
    console.log(url);
    makeRequest(url,'getinfo');
}

const search= document.querySelector("#search");
const searchForm = document.querySelector(".search-form")
const type=document.querySelector("#type");
const content=document.querySelector(".content");
let movies=document.querySelector(".movies");
const footer=document.footer;

searchForm.onsubmit = (event) => {
    goToPage(0);
    event.preventDefault();
}


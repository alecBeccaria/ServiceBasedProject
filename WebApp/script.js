var myData = null;
var searchResultsDiv = document.getElementById('searchOutput');
var searchText = document.getElementById('txtSearch');
var searchPriceMin = document.getElementById('txtPriceMin');
var searchPriceMax = document.getElementById('txtPriceMax');

const fetchData = async (url) => {
    const response = await fetch(url);
    const data = await response.json();
    myData = shuffleArr(data);
    console.log(myData);
    returnData(myData);
};

const returnData = arr => {
    searchResultsDiv.innerHTML = '';
    for (let i = 0; i < arr.length; i++) {
        title = arr[i].title;
        price = arr[i].price;
        desc = arr[i].description;
        searchResultsDiv.innerHTML += `<div><h2>${title}: $${price}</h2></div><br>
                                        <div>${desc}</div><br>`;
    }
};

async function searchBtnSwitch() {
    if (searchText.value.trim.length) {
        getItems('catalog/items');
    } else {
        getItems('catalog/items/search/' + searchText.value);
    }
}

async function getItems(uri) {
    fetchData(`http://localhost:5156/${uri}`);
};

// async function handleClick() {
//     var selectCategory = document.getElementById('category');
//     var inputCategory = selectCategory.value;
//     var selectJokeAmount = document.getElementById('numOfJokes');
//     var inputJokeAmount = selectJokeAmount.value;
//     //const response = await fetch(`http://localhost:3000/api?amount=${inputJokeAmount}&type=${inputCategory}`);
//     console.log(inputCategory);
//     console.log(inputJokeAmount);

//     fetchData(`http://localhost:3000/api?amount=${inputJokeAmount}&type=${inputCategory}`);
// };

const shuffleArr = myArr => {
    let a, b;
    for (let i = 0; i < myArr.length - 1; i++) {
        let rand = Math.floor(Math.random() * myArr.length);

        a = myArr[i];
        b = myArr[rand];
        myArr[i] = b;
        myArr[rand] = a;
    }
    return myArr;
};


//document.getElementById('searchBtn').addEventListener('click', handleClick);
document.getElementById('searchBtn').addEventListener('click', searchBtnSwitch);

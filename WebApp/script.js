var myData = null;
var searchResultsDiv = document.getElementById('searchOutput');
var searchText = document.getElementById('txtSearch');
var searchPriceMin = document.getElementById('txtPriceMin');
var searchPriceMax = document.getElementById('txtPriceMax');
var BasketHTML = document.getElementById('Basket');
var basket = null;

// var itemObj = {
//     id,
//     title,
//     description,
//     price,
//     quantity
// }

class Basket {
    constructor(id, userId, items){
        this.id = id
        this.userId = userId
        this.items = items
    }
}

const createBasket = async () => {
    var url = "http://localhost:5159/basket/add";
    const response = await fetch(url);
    
    b = await response.json();
    console.log(b);
    setBasketCallback(b)
}


const setBasketCallback = (data) => {
    globalThis.basket = data;
    
}

createBasket();



const addToCart = async (item) => {

    var url = `http://localhost:5156/catalog/items/${item.id}`
    const response = await fetch(url);
    item = await response.json();

    if(basket.items.length == 0){
        basket.items.push(item);
        BasketHTML.innerHTML +=`
            <div>
                <h2>${item.title}: ${item.price}</h2>
            </div><br></br>`
    }else{
        let containsItem = false;
        for(let i = 0; i < basket.items.length; i++){
            
            if(basket.items[i].id == item.id){
                containsItem = true;
            }
        }
        if(!containsItem){
            basket.items.push(item);
            console.log(item.id)
            BasketHTML.innerHTML +=`
            <div>
                <h2>${item.title}: ${item.price}</h2>
            </div><br></br>`
        }
    }
    
    

    
    console.log(basket);
}


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
        searchResultsDiv.innerHTML += `
    <div>
        <h2>${title}: ${price}</h2>
    </div><br>
    <div>
        ${desc}
        <input id=${arr[i].id} type="button" value="Add to Cart"><br>
    </div><br>`

        
    }

    for (let i = 0; i < arr.length; i++){
        document.getElementById(arr[i].id).addEventListener("click", (e) =>
        {
            addToCart(e.target)
        })
    }
        
    
};



async function searchBtnSwitch() {
    if (searchText.value == "") {
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

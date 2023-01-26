const baseURL = "https://fakestoreapi.com/products";
const NewProduct = document.getElementById("newProducts");
const searchBar = document.getElementById("searchBar");
const btnContainer = document.querySelector("#btn-container");
let products = [];






//searchBar

searchBar.addEventListener("keyup", function (e) {
    const searchString = e.target.value.toLowerCase();
    const filterProducts = products.filter(product => {
        return product.category.toLowerCase().includes(searchString) ||
            product.title.toLowerCase().includes(searchString);
    });
    displayProducts(filterProducts);
});

//load products

const loadProducts = async () => {

    try {
        const res = await fetch(baseURL);
        products = await res.json();
        displayProducts(products);
        if (!res.ok) throw new Error(`${products.message} ${res.status}`);
    }
    catch (err) {
        console.log(err);
    }
}

const displayProducts = (products) => {
    const htmlString = products.map((product) => {
        return `
                    <div class = "col-md-4">
                        <div class = "card">
                            <img class="card-img-top" width="40" src="${product.image}" alt=<"card image cap">
                            <div class="card-body">\
                            <h5 class="card-title">${product.category}</h5>
                            <a href="/UI/Product" class="btn-primary">Go to Products</a>
                            </div>
                        </div>
                    </div>
                `
    }).join('');
    NewProduct.innerHTML = htmlString;
}

loadProducts();



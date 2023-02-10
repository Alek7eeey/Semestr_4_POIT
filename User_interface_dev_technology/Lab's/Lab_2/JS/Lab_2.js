class Product {
    id;
    size;
    color;
    price;
    sale;
    endPrice;
    type;
    get Type() {
        return this.type;
    }
    get ID() {
        return this.id;
    }
    get Size() {
        return this.size;
    }
    get Color() {
        return this.color;
    }
    get Price() {
        return this.endPrice;
    }
    set Price(v) {
        this.price = v;
        this.endPrice = (100 - this.sale) * this.price / 100;
    }
    constructor(ID, type, price, Size, color, Sale = 0) {
        this.sale = 0;
        this.id = ID;
        this.size = Size;
        this.color = color;
        this.sale = Sale;
        this.price = price;
        this.endPrice = (100 - Sale) * price / 100;
        this.type = type;
    }
    toString() {
        return (`id: ${this.id}\n name: ${this.type} \n color: ${this.color} \n size: ${this.size}\n price: ${this.endPrice}`);
    }
}
let products = [
    new Product(1, "Кроссовки", 150, 42, "black"),
    new Product(2, "Ботинки", 200, 40, "black", 20),
    new Product(3, "Сандали", 50, 42, "white", 10)
];
class ProductIterator {
    products;
    index;
    constructor(products) {
        this.products = products;
        this.index = -1;
        this.products = products;
    }
    next() {
        if (this.index < products.length - 1) {
            return { done: false, value: products[++this.index] };
        }
        else {
            return { done: true, value: null };
        }
    }
}
let iterator = new ProductIterator(products);
let prod = iterator.next();
while (prod.done != true) {
    console.log(prod.value);
    prod = iterator.next();
}
//Задание_3
function filtreByPrice(priceFrom, priceTo) {
    console.log("\nFilter by price:");
    products.forEach(Element => {
        if (Element.price < priceTo && Element.price > priceFrom) {
            console.log(Element.toString());
            //console.log(`id: ${Element.id}\n name: ${Element.type} \n color: ${Element.color} \n size: ${Element.size}\n price: ${Element.price}`);
        }
    });
}
function filtreByColor(color) {
    console.log('\nFilter by color: ');
    products.forEach(element => {
        if (element.color == color) {
            console.log(element.toString());
        }
    });
}
function filtreBySize(size) {
    console.log('\nFilter by size: ');
    products.forEach(element => {
        if (element.size == size) {
            console.log(element.toString());
        }
    });
}
filtreBySize(40);
filtreByColor("black");
filtreByPrice(50, 151);
let boot1 = {
    ID: 53,
    Size: 32,
    Color: "Green",
    Price: 120
};
let boot2 = {
    ID: 44,
    Size: 39,
    Color: "Yellow",
    Price: 600
};
let sandal1 = {
    ID: 38,
    Size: 44,
    Color: "Blue",
    Price: 325
};
let sandal2 = {
    ID: 45,
    Size: 49,
    Color: "Orange",
    Price: 666
};
let Boots = {
    ID: 1,
    Boots: [boot1, boot2]
};
const Sandals = {
    ID: 2,
    Boots: [sandal1, sandal2]
};
let produc = {
    Products: Boots.Boots.concat(Sandals.Boots)
};

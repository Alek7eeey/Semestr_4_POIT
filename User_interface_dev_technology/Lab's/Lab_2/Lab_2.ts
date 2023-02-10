//Задание_1, 4
interface IProduct
{
  endPrice: number;
  readonly size : number;
  readonly color : string;
  price : number;
  sale : number;
  type: string;
  get Type(): string;
  get ID(): number;
  get Size() : number;
  get Color() : string;
  get Price() : number;
  set Price(v : number);

  toString(): string;
}

class Product implements IProduct
{
  private readonly id: number;
  readonly size : number;
  readonly color : string;
  price : number;
  sale : number;
  endPrice : number;
  type: string;

  public get Type():string
  {
    return this.type;
  }

  public get ID(): number
  {
    return this.id;
  }
  public get Size() : number 
  {
    return this.size;
  }

public get Color() : string   
  {
    return this.color;
  }

public get Price() : number 
  {
    return this.endPrice;
  }

public set Price(v : number) 
{
    this.price = v;
    this.endPrice = (100 - this.sale) * this.price / 100;
}

  constructor(ID: number,type: string, price: number, Size: number, color: string, Sale: number = 0) {
    this.sale = 0;
    this.id = ID;
    this.size = Size;
    this.color = color;
    this.sale = Sale;
    this.price = price;
    this.endPrice = (100 - Sale) * price / 100; 
    this.type = type;
  }

  public toString() : string
  {
    return(`id: ${this.id}\n name: ${this.type} \n color: ${this.color} \n size: ${this.size}\n price: ${this.endPrice}` );
  }
}
let products = [
  new Product(1,"Кроссовки", 150, 42, "black"),
  new Product(2,"Ботинки", 200, 40, "black", 20),
  new Product(3,"Сандали", 50, 42, "white", 10)
];

//Задание_2
interface IProductIterator
{
  index: number;
  next() : any;
}

class ProductIterator implements IProductIterator
{
  index: number
  constructor(public products: Product[]) 
  {
      this.index = -1;
      this.products = products;
  }

  public next() : any
   {
      if (this.index < products.length-1) 
      {
          return { done: false, value: products[++this.index] };
      }
      else {
          return { done: true, value: null };
      }
  }
}
let iterator: ProductIterator = new ProductIterator(products);
let prod: any = iterator.next();

while(prod.done != true)
{
  console.log( prod.value );
  prod=iterator.next();
}

//Задание_3

function filtreByPrice(priceFrom: number, priceTo: number) : void
{
  console.log("\nFilter by price:");
  products.forEach(Element => {
    if(Element.price < priceTo && Element.price > priceFrom)
    {
      console.log(Element.toString());
      //console.log(`id: ${Element.id}\n name: ${Element.type} \n color: ${Element.color} \n size: ${Element.size}\n price: ${Element.price}`);
    }
  });
}

function filtreByColor(color: string) : void
{
  console.log('\nFilter by color: ');
  products.forEach(element => {
    if (element.color == color) {
      console.log(element.toString());
    }
  }); 
}

function filtreBySize(size: number) : void 
{
  console.log('\nFilter by size: ');
  products.forEach(element => {
    if(element.size == size)
    {
      console.log(element.toString());
    }
  }); 
}

filtreBySize(40);
filtreByColor("black");
filtreByPrice(50, 151);

// Задание_4

// Object.defineProperty(products, "id", { //нельзя удалить 
//   writable: false,
//   enumerable: true,
//   configurable: false
// });

//--------------------------------//
interface IBoot
{
    readonly ID : number;
    readonly Size : number;
    readonly Color : string;
    Price : number;
}

interface ICategory
{
    ID: number;
    Boots: IBoot[];
}

interface IProducts
{
    Products: IBoot[]
}

let boot1 : IBoot =
{
  ID: 53,
  Size: 32,
  Color: "Green",
  Price: 120
};

let boot2 : IBoot =
{
  ID: 44,
  Size: 39,
  Color: "Yellow",
  Price: 600
};

let sandal1 : IBoot =
{
  ID: 38,
  Size: 44,
  Color: "Blue",
  Price: 325
};

let sandal2 : IBoot =
{
  ID: 45,
  Size: 49,
  Color: "Orange",
  Price: 666
};

let Boots : ICategory = 
{
    ID: 1,
    Boots: [boot1, boot2]
}

const Sandals : ICategory =
{
    ID: 2,
    Boots: [sandal1, sandal2]
}

let produc : IProducts = 
{
    Products: Boots.Boots.concat(Sandals.Boots)
}

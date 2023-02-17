//1) ---------------types---------------
const str:string = "Hello";
const logicalType1: boolean = true;
const logicalType2: boolean = false;
let integer: number = 12;
let num: number = 3E10;
let array: number[] = [2,3,52,12];
const arrayAsCollection: Array<number> = [3,54,324,12];

//Tuple - массив разных типов давнных
let contact: [string, string, number] = ["Vlad", "+375445635869", 12];

//Any
let newVar: any = "Hello";
newVar = 21;

//2) ---------------function-1---------------
function sayMyName(name: string) : void
{
    console.log(name);
}
sayMyName("HelloMyGuest");

//never
function throwError(str: string) : never
{
    throw new Error(str);
}

function throwError2(str: string) : never
{
    while(true)
    {}
}

//3) ---------------type---------------
type login = string | boolean;
const log: login = "abcd";
let a: login = true;

type SomeType = string | undefined | null;

//4)---------------interface---------------
interface Rect{
    readonly id: string;
    color?: string;
    size:
    {
        width: number;
        height: number;
    }
}

const rect: Rect = {
    id: "12a",
    size: {
        width: 12,
        height: 32
    }
}
rect.color = "#34354";

const rect3 ={} as Rect;
const rect4 = <Rect>{};

//наследование
interface newInterface extends Rect 
{
    getArea: () => number;
}

const rect5: newInterface =
{
    id: "12a",
    size: {
        width: 12,
        height: 32
    },
    getArea(): number
    {
        return this.size.width * this.size.height;
    }
}

//наследование классов
interface IInterface{
time: Date
setTime(date: Date) : void
}

class Clock implements IInterface
{
    time: Date = new Date()
    setTime(date: Date): void {
        this.time = date
    }
}

//интерфейс для объекта с большим количеством динамических ключей
interface Styles {
    [key: string]: string
}

const Css: Styles = {
    border: '1px solid black',
    marginTop: '3px'
}

//5)---------------enum---------------
enum color{
    black,
    white,
    green
}

const col = color.black;
const col2 = color[1];

enum city{
    minsk = "Minsk",
    grodno = "Grodno",
    brest = "Brest"
}

const newCity = city.minsk;

//6) ---------------function-2---------------
interface interfaceForFunct 
{
    x: number,
    y: number
}

function newFunct(x: number, y: number) : interfaceForFunct
{
 return {x, y}
}

//7) ---------------CLASS---------------
class newClass
{
    name: string;
    constructor(na: string)
    {
        this.name = na;
    }

    info() : string| null {
        return this.name;
    }
}

//классы полей могут создаваться в конструкторе, если указать модификатор доступа
// class Car {
//   readonly model: string
//   readonly numberOfWheels: number = 4
//
//   constructor(theModel: string) {
//     this.model = theModel
//   }
// }

class Car {
    readonly numberOfWheels: number = 4;
    protected voice: string = ''; //для класса и наследника класса, но не объекта наследника
    private newVar: string;
    constructor(readonly model: string) {} //или public модель
  }

  class newCar extends Car{

  }

//8) ---------------Abstract class---------------
abstract class Component
{
    abstract render(): void;
    abstract info(): string;
}

class newComp extends Component
{
    render(): void {
        console.log(`Some info`);
    }

    info(): string {
        return 'some stroke';
    }
}

//8) ---------------Guards---------------
function someFunction(x: string| number)
{
    if(typeof x == 'number')
    {
        return x.toFixed();
    }

    else {
        return x.trim();
    }
}

class MyResponse
{
    header = 'responce header';
    result = 'responce result';
}

 class MyError
 {
    header = 'error header';
    message = 'error message';
 }

 function handle(res: MyResponse | MyError)
 {
    if(res instanceof MyResponse)
    {
        return {
            info: res.header + res.result
        }
    }

    else
    {
        return {
            info: res.header + res.message
        }
    }
 }

 /////////////////////////////
 type AlertType = 'sucxess' | 'danger'| 'warning';

 function setAlertType(type: AlertType)
 {
    //...something...
 }

 setAlertType('sucxess');
 //setAlertType('asas'); - NEVER
 setAlertType('warning');

 // 9) ---------------Generic---------------
 const arrayOfNumber: Array<number> = [1,1,2,3];

 function reverse<T>(array: T[]) : T[] {
    return array.reverse();
 }

 // 10) ---------------some operators---------------
 interface Person {
    name: string
    age: number
 }

 type PersonKey = keyof Person  // >> name && age
 const myName: PersonKey = 'name'; 

 type User = {
    _id: number
    name: string
    email: string
    createdAt: Date
  }
  
  type UserKeysNoMeta1 = Exclude<keyof User, '_id' | 'createdAt'> // 'name' | 'email' >> исключаем
  type UserKeysNoMeta2 = Pick<User, 'name' | 'email'> // 'name' | 'email' >> сохраняем 
  
  
  let u1: UserKeysNoMeta1 = 'name'
  // u1 = '_id'
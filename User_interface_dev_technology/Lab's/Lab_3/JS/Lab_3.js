//1) ---------------types---------------
const str = "Hello";
const logicalType1 = true;
const logicalType2 = false;
let integer = 12;
let num = 3E10;
let array = [2, 3, 52, 12];
const arrayAsCollection = [3, 54, 324, 12];
//Tuple - массив разных типов давнных
let contact = ["Vlad", "+375445635869", 12];
//Any
let newVar = "Hello";
newVar = 21;
//2) ---------------function-1---------------
function sayMyName(name) {
    console.log(name);
}
sayMyName("HelloMyGuest");
//never
function throwError(str) {
    throw new Error(str);
}
function throwError2(str) {
    while (true) { }
}
const log = "abcd";
let a = true;
const rect = {
    id: "12a",
    size: {
        width: 12,
        height: 32
    }
};
rect.color = "#34354";
const rect3 = {};
const rect4 = {};
const rect5 = {
    id: "12a",
    size: {
        width: 12,
        height: 32
    },
    getArea() {
        return this.size.width * this.size.height;
    }
};
class Clock {
    time = new Date();
    setTime(date) {
        this.time = date;
    }
}
const Css = {
    border: '1px solid black',
    marginTop: '3px'
};
//5)---------------enum---------------
var color;
(function (color) {
    color[color["black"] = 0] = "black";
    color[color["white"] = 1] = "white";
    color[color["green"] = 2] = "green";
})(color || (color = {}));
const col = color.black;
const col2 = color[1];
var city;
(function (city) {
    city["minsk"] = "Minsk";
    city["grodno"] = "Grodno";
    city["brest"] = "Brest";
})(city || (city = {}));
const newCity = city.minsk;
function newFunct(x, y) {
    return { x, y };
}
//7) ---------------CLASS---------------
class newClass {
    name;
    constructor(na) {
        this.name = na;
    }
    info() {
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
    model;
    numberOfWheels = 4;
    voice = ''; //для класса и наследника класса, но не объекта наследника
    newVar;
    constructor(model) {
        this.model = model;
    } //или public модель
}
class newCar extends Car {
}
//8) ---------------Abstract class---------------
class Component {
}
class newComp extends Component {
    render() {
        console.log(`Some info`);
    }
    info() {
        return 'some stroke';
    }
}
//8) ---------------Guards---------------
function someFunction(x) {
    if (typeof x == 'number') {
        return x.toFixed();
    }
    else {
        return x.trim();
    }
}
class MyResponse {
    header = 'responce header';
    result = 'responce result';
}
class MyError {
    header = 'error header';
    message = 'error message';
}
function handle(res) {
    if (res instanceof MyResponse) {
        return {
            info: res.header + res.result
        };
    }
    else {
        return {
            info: res.header + res.message
        };
    }
}
function setAlertType(type) {
    //...something...
}
setAlertType('sucxess');
//setAlertType('asas'); - NEVER
setAlertType('warning');
// 9) ---------------Generic---------------
const arrayOfNumber = [1, 1, 2, 3];
function reverse(array) {
    return array.reverse();
}
const myName = 'name';
let u1 = 'name';
// u1 = '_id'

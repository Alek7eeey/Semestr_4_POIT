//ex1
type Person = {
    id: number,
    name: string,
    group: number
}

const array: Person[] = [
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

//ex2
type CarsType =
{
    manufacturer?: string;
    model?: string;
}

let car: CarsType = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';

//ex3
const car1: CarsType = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';

const car2: CarsType = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';

type ArrayCarsType = {
    cars: CarsType[];
}

const arrayCars: Array<ArrayCarsType> = [{
    cars: [car1, car2]
}];

//ex4
type DoneType = boolean;
type MarkFilterType = 1|2|3|4|5|6|7|8|9|10;
type GroupFilterType = 1|2|3|4|5|6|7|8|9|10|11|12;

type MarkType = {
    subject: string,
    mark: MarkFilterType, // может принимать значения от 1 до 10
    done: DoneType,
}
type StudentType = {
    id: number,
    name: string,
    group: GroupFilterType, // может принимать значения от 1 до 12
    marks: Array<MarkType>,
}


type GroupType = {
    students: Array<StudentType>, // массив студентов типа StudentType
    studentsFilter: (group: GroupFilterType) => Array<StudentType>, // фильтр по группе
    marksFilter: (mark: MarkFilterType) => Array<StudentType>, // фильтр по  оценке
    deleteStudent: (id: number) => void, // удалить студента по id из  исходного массива
    mark: MarkFilterType,
    group: GroupFilterType,
}

const group: GroupType = {

    students: [],

    studentsFilter(group: GroupFilterType): Array<StudentType> 
    {
        const filteredStudents: Array<StudentType> = [];

        for (let student of this.students) 
        {
            if (student.group == group) 
            {
             filteredStudents.push(student);
            }
        }
        return filteredStudents;
   },

    marksFilter(mark: MarkFilterType): Array<StudentType> 
    {
        const filteredStudents: Array<StudentType> = [];

        for (let student of this.students) 
        {
            if (student.mark == mark) 
            {
             filteredStudents.push(student);
            }
        }
        return filteredStudents;
    },

    deleteStudent(id: number): void 
    {
      this.students = this.students.filter((student) => student.id !== id);
    },

    mark: 10,
    group: 5,
  };

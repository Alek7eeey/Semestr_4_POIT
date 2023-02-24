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

let mark1: MarkType = {
    subject: "math",
    mark: 5,
    done: true
} 

let mark2: MarkType = {
    subject: "OOP",
    mark: 10,
    done: true
} 

let mark3: MarkType = {
    subject: "Design",
    mark: 8,
    done: true
} 

type StudentType = {
    id: number,
    name: string,
    group: GroupFilterType, // может принимать значения от 1 до 12
    marks: Array<MarkType>,
}

let student1: StudentType = {
    id: 1,
    name: "Aleksandr",
    group: 4,
    marks: [mark1, mark2, mark3]
}

let student2: StudentType = {
    id: 2,
    name: "Daria",
    group: 5,
    marks: [mark1, mark2]
}

let student3: StudentType = {
    id: 3,
    name: "Igor",
    group: 6,
    marks: [mark2, mark3]
}


type GroupType = {
    students: Array<StudentType>, // массив студентов типа StudentType
    studentsFilter: (group: GroupFilterType) => Array<StudentType>, // фильтр по группе
    marksFilter: (mark: MarkFilterType) => Array<StudentType>, // фильтр по  оценке
    deleteStudent: (id: number) => void // удалить студента по id из  исходного массива
}

const group: GroupType = {

    students: [student1, student2, student3],

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
            for(let mark_ of student.marks) {
                
            if (mark_.mark == mark) 
            {
                filteredStudents.push(student);
            }
        }

        }
        return filteredStudents;
    },

    deleteStudent(id: number): void 
    {
      this.students = this.students.filter((student) => student.id !== id);
    }

  };

  console.log(group.studentsFilter(5));
  console.log(group.marksFilter(10));
  group.deleteStudent(2);

  for(let a of group.students)
  {
    console.log(a);
  }

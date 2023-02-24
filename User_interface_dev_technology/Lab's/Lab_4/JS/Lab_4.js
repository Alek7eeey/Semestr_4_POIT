const array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
let car = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';
//ex3
const car1 = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';
const car2 = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';
const arrayCars = [{
        cars: [car1, car2]
    }];
let mark1 = {
    subject: "math",
    mark: 5,
    done: true
};
let mark2 = {
    subject: "OOP",
    mark: 10,
    done: true
};
let mark3 = {
    subject: "Design",
    mark: 8,
    done: true
};
let student1 = {
    id: 1,
    name: "Aleksandr",
    group: 4,
    marks: [mark1, mark2, mark3]
};
let student2 = {
    id: 2,
    name: "Daria",
    group: 5,
    marks: [mark1, mark2]
};
let student3 = {
    id: 3,
    name: "Igor",
    group: 6,
    marks: [mark2, mark3]
};
const group = {
    students: [student1, student2, student3],
    studentsFilter(group) {
        const filteredStudents = [];
        for (let student of this.students) {
            if (student.group == group) {
                filteredStudents.push(student);
            }
        }
        return filteredStudents;
    },
    marksFilter(mark) {
        const filteredStudents = [];
        for (let student of this.students) {
            for (let mark_ of student.marks) {
                if (mark_.mark == mark) {
                    filteredStudents.push(student);
                }
            }
        }
        return filteredStudents;
    },
    deleteStudent(id) {
        this.students = this.students.filter((student) => student.id !== id);
    }
};
console.log(group.studentsFilter(5));
console.log(group.marksFilter(10));
group.deleteStudent(2);
for (let a of group.students) {
    console.log(a);
}

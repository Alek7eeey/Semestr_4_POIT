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
const group = {
    students: [],
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
            if (student.mark == mark) {
                filteredStudents.push(student);
            }
        }
        return filteredStudents;
    },
    deleteStudent(id) {
        this.students = this.students.filter((student) => student.id !== id);
    },
    mark: 10,
    group: 5,
};

package by.employee;

public class employee {
    public String name;
    public int yearExp;
    public boolean education;

    @Override
    public String toString() {
        return "employee:\n" +
                "name: '" + name + '\'' +
                "\nyearExp: " + yearExp +
                ",\neducation: " + education;
    }

    public employee(String name, int yearExp, boolean education) {
        this.name = name;
        this.yearExp = yearExp;
        this.education = education;
    }
}

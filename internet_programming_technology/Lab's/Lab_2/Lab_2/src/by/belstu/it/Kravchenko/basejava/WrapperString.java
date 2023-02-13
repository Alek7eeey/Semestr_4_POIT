package by.belstu.it.Kravchenko.basejava;

import java.util.Objects;

/*
@author KravchenkoAleksey
@version 1.1
 */
public class WrapperString {
    private String name;

    /*
     * @return void
     * @throws java.Exception
     * @param char oldchar && char newchar
     * */
    public void replace (char oldchar, char newchar)
    {
        name = name.replace(oldchar, newchar);
    }
    public void setName(String name) {
        this.name = name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        WrapperString that = (WrapperString) o;
        return Objects.equals(name, that.name);
    }

    @Override
    public String toString() {
        return "WrapperString{" +
                "name='" + name + '\'' +
                '}';
    }

    @Override
    public int hashCode() {
        return Objects.hash(name);
    }

    public String getName() {
        return name;
    }

    public WrapperString(String name) {
        this.name = name;
    }

    public WrapperString() {
    }
}

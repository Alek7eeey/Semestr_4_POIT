package by.Lab_4.xmlSeriaize;

import by.Lab_4.Employee.Employee;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import static by.Lab_4.Main.main.employees;

public class SaxParser extends DefaultHandler
{
    private String name, position, lastElementName;
    private Boolean education;
    private Integer Salary;

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
        lastElementName = qName;
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        String information = new String(ch, start, length);

        information = information.replace("\n", "").trim();

        if (!information.isEmpty()) {
            if (lastElementName.equals("name"))
                name = information;
            if (lastElementName.equals("higherEducation"))
                education = Boolean.parseBoolean(information);
            if (lastElementName.equals("position"))
                position = information;
            if (lastElementName.equals("salary"))
                Salary = Integer.parseInt(information);
        }
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        if ( (name != null && !name.isEmpty()) && (position != null && !position.isEmpty()) && education !=null && Salary != null) {
            employees.add(new Employee(name,education,position,Salary));
            name = null;
            position = null;
            education = null;
            Salary = null;
        }
    }
}

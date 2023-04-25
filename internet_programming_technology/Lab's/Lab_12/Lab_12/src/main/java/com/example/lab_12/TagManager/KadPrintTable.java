package com.example.lab_12.TagManager;

import com.example.lab_12.People;
import jakarta.servlet.jsp.JspException;
import jakarta.servlet.jsp.JspWriter;
import jakarta.servlet.jsp.tagext.TagSupport;

import java.io.IOException;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

@SuppressWarnings("serial")
public class KadPrintTable extends TagSupport {
    List<People> peopleList = new ArrayList<People>();
    private String nameTable;
    private String nameDB;
    public void setNameTable(String nameTable)
    {
        this.nameTable = nameTable;
    }

    public void setNameDB(String nameDB)
    {
        this.nameDB = nameDB;
    }
    @Override
    public int doStartTag() throws JspException
    {
        String str = null;
        JspWriter out = pageContext.getOut();
        if(nameTable == null || nameTable.isEmpty()) {
            try {
                out.println("Значение атрибута для тега = NULL/EMPTY");
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
        else{
            String connectionString = "jdbc:mysql://localhost:3306/"+nameDB+"?autoReconnect=true&useSSL=false";
            String table = "<table>\n<tr>";
            try {
                Class.forName("com.mysql.cj.jdbc.Driver");
            }
            catch (ClassNotFoundException e) {
                throw new RuntimeException(e);
            }

            try (Connection connection = DriverManager.getConnection(connectionString, "root", "Kravchenko1")) {

                Statement stmt = connection.createStatement();
                String sql2 = "select * from " + nameTable;

                try (ResultSet rs = stmt.executeQuery(sql2)) {
                 ResultSetMetaData metaData = rs.getMetaData();
                    int columnCount = metaData.getColumnCount();
                    String[] columnNames = new String[columnCount];
                    int[] columnTypes = new int[columnCount];

                 for (int i = 1; i <= columnCount; i++) {
                        String columnName = metaData.getColumnName(i);
                        columnNames[i-1] = metaData.getColumnName(i);
                        table +="<th>" + columnName +"</th>\n";
                 }
                 table += "</tr>\n";

                    while (rs.next()) {
                        table+="<tr>\n";
                        for (int i = 0; i < columnCount; i++) {
                            Object value = rs.getObject(i+1);
                            int columnType = columnTypes[i];
                            String strValue = "";
                            if (value != null) {
                                switch (columnType) {
                                    case Types.BIGINT:
                                    case Types.INTEGER:
                                    case Types.SMALLINT:
                                    case Types.TINYINT:
                                        strValue = Integer.toString(rs.getInt(i+1));
                                        break;
                                    case Types.FLOAT:
                                    case Types.DOUBLE:
                                    case Types.DECIMAL:
                                    case Types.NUMERIC:
                                        strValue = Double.toString(rs.getDouble(i+1));
                                        break;
                                    case Types.BOOLEAN:
                                        strValue = Boolean.toString(rs.getBoolean(i+1));
                                        break;
                                    default:
                                        strValue = value.toString();
                                }
                            }
                            table += "<td>" + strValue + "</td>";
                        }
                        table+="</tr>\n";
                    }

                    rs.close();
                    stmt.close();
                    connection.close();

                    try {
                        out.println(table + "</table>\n");
                    } catch (IOException e) {
                        throw new RuntimeException(e);
                    }

                }
                catch (SQLException e) {
                    try {
                        out.println("Такой таблицы в Базе данных не существует\n");
                    } catch (IOException ex) {
                        throw new RuntimeException(ex);
                    }
                }
            }
            catch (SQLException e) {
                try {
                    out.println("Такой Базы данных не существует\n");
                } catch (IOException ex) {
                    throw new RuntimeException(ex);
                }
            }
        }
        return SKIP_BODY;
    }
}

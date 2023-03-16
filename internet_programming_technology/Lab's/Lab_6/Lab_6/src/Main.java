import by.settings.Config;
import by.settings.DataBaseHandler;
import org.apache.log4j.xml.DOMConfigurator;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import org.apache.log4j.*;
import org.apache.log4j.xml.DOMConfigurator;
import org.apache.log4j.Logger;
import org.apache.log4j.LogManager;
public class Main extends Config {

    static {
        new DOMConfigurator().doConfigure("log/log4j.xml", LogManager.getLoggerRepository());
    }

    private static final Logger LOG = Logger.getLogger(Main.class);
    public static void main(String[] args) throws SQLException, ClassNotFoundException {
        DataBaseHandler handler = new DataBaseHandler();

        String day = "Понедельник";
        String auditory = "106-1";
        List list = new ArrayList<>();
        ResultSet resultSet = null;

        try {
            LOG.info("Start query 1");
            /*Вывести информацию о преподавателях, работающих в заданный день
            недели в заданной аудитории.*/
            String select1 = "select * from Teacher inner join Lessons" +
                    " on Teacher.leadSubject = Lessons.nameOfLesson" +
                    " where Lessons.dayOfLesson = 'Понедельник'" +
                    " and Lessons.nameOfAuditory = '106-1';\n";
            PreparedStatement st = handler.getDbConnection().prepareStatement(select1);
            resultSet = st.executeQuery();
            System.out.println("Преподователь, который будет работать в заданный день в заданной аудитории:");
            while (resultSet.next()) {
                String name = resultSet.getString("FIO");
                System.out.println(name);
            }
            LOG.info("Start query 2");
            /*Вывести информацию о преподавателях, которые не ведут занятия в
            заданный день недели.*/
            String select2 = "select * from Teacher inner join Lessons " +
                    "\n on Teacher.leadSubject = Lessons.nameOfLesson " +
                    "\n where Lessons.dayOfLesson != 'Понедельник';";
            st = handler.getDbConnection().prepareStatement(select2);
            resultSet = st.executeQuery();
            System.out.println("\nПреподователи, который не будет работать в заданный день: ");
            while (resultSet.next()) {
                String name = resultSet.getString("FIO");
                String sub = resultSet.getString("leadSubject");
                System.out.println(name + "\t" + sub);
            }

            LOG.info("Start query 3");
            /*Вывести дни недели, в которых проводится заданное количество
            занятий.*/
            String select3 = "select * from Teacher inner join Lessons" +
                    "\n on Teacher.leadSubject = Lessons.nameOfLesson " +
                    "\n where Teacher.countLessonOfSubject like 3;";
            st = handler.getDbConnection().prepareStatement(select3);
            resultSet = st.executeQuery();
            System.out.println("\nДни недели, в которых проводится заданное количество" +
                    " занятий: ");
            while (resultSet.next()) {
                String dayOfWeek = resultSet.getString("dayOfLesson");
                System.out.println(dayOfWeek);
            }
            LOG.info("Start query 4");
            /*Вывести дни недели, в которых занято заданное количество аудиторий.*/
            String select4 = "select * \n" +
                    "from Lessons as l inner join Teacher as t\n" +
                    "on l.nameOfLesson = t.leadSubject\n" +
                    "where 2 in (select count(*) \n" +
                    "from Lessons where l.dayOfLesson = Lessons.dayOfLesson \n" +
                    "group by dayOfLesson)";

            st = handler.getDbConnection().prepareStatement(select4);
            resultSet = st.executeQuery();
            System.out.println("\nДень недели, в который занято 3 аудитории:  ");
            String dayOfWeek = "";
            while (resultSet.next()) {
                dayOfWeek = resultSet.getString("dayOfLesson");
            }
            System.out.println(dayOfWeek);
            LOG.info("Execution ended");
        }
        catch (SQLException e)
        {
            e.printStackTrace();
        } catch (ClassNotFoundException e)
        {
            e.printStackTrace();
        }

    }
}
package by.belstu.it.Kravchenko.basejava;

import static java.lang.Math.*;
/*
@author KravchenkoAleksey
@version 1.0
 */
public class JavaTest {
    static int sint;
    public final int const1 = 23; //в java final == const
    public static final int const2 = 243;

    /*
    * @return void
    * @throws java.Exception
    * @param String[] args
    * */
    public static void main(String[] args) {
        /*
        * @value 'b'
        * @see Должна быть ссылка))
        * */
        char sym = 'b';
        int num = 154343;
        String str = "hello ";
        short shNum = 1513;
        byte bNum = 127;
        long lNum = -1213243;
        boolean bool = true;
        double dblNum = 2.343;

        String resultStrAndNum = str + num;
        System.out.println(resultStrAndNum);

        String resultStrAndSym = str + sym;
        System.out.println(resultStrAndSym);

        String resultStrAndDouble = str + dblNum;
        System.out.println(resultStrAndDouble);

        //byte newByte = bNum + num; -- байт в диапазоне до 127

        int newInt = (int) dblNum + (int) lNum;
        System.out.println(newInt);

        long newL = (long) num + (long) 2147483647;
        System.out.println(newL);

        System.out.println(sint);
        System.out.println(true && false);
        System.out.println(true ^ false);

        //System.out.println(true + false); - NEVER

        var var1 = 9223372036854775807l; //необходимо добавить в конце l
        var var2 = 0x7fff_ffff_fffl;

        char s1 = 'a';
        char s2 = '\u0061';
        char s3 = 97;

        System.out.println(s1 + s2 + s3); //291: сумма кодов символов s1 и s2 + 97

        System.out.println(3.45 % 2.4);
        System.out.println(1.0 / 0.0); //inf
        System.out.println(0.0 / 0.0); //NaN
        System.out.println(Math.log(-345)); //NaN
        System.out.println(Float.intBitsToFloat(0x7F800000)); //inf
        System.out.println(Float.intBitsToFloat(0xFF800000)); //-inf

        //const - в 2, 8, 10, 16 notation

        var Pi = Math.PI;
        var E = Math.E;

        System.out.println(PI);
        System.out.println(E);
        System.out.println(Math.min(Pi, E));
        System.out.println(Math.round(Pi));
        System.out.println(Math.round(E));

        Boolean b = false;
        Character c = 'c';
        Integer i = 23;
        Long l = 5430L;
        Short s = 4;
        Byte b1 = 30;
        Double d = 36.6;

        System.out.println(c >> 2);
        System.out.println(c << 2);
        System.out.println(l * 0.1);
        System.out.println(b && true);
        System.out.println(c + i);

        System.out.println(Long.MAX_VALUE);
        System.out.println(Long.MIN_VALUE);
        System.out.println(Double.MAX_VALUE);
        System.out.println(Double.MIN_VALUE);

        //упаковка
        int NewInt = 23;
        Integer intRef = NewInt;

        //распаковка
        NewInt = intRef;

        int testInt = Integer.parseInt("12");
        System.out.println(testInt);

        System.out.println(Integer.toHexString(134));
        System.out.println(Integer.compare(13, 26));
        System.out.println(Integer.toString(31));
        System.out.println(Integer.bitCount(12)); //count of 1 in 2 notation
        System.out.println(Double.isNaN(NewInt));

        String stroke = "2345";

        //int i1 = new Integer(stroke);
        var i2 = Integer.parseInt(stroke);
        var i3 = Integer.valueOf(stroke);

        byte[] bytes = stroke.getBytes();
        String st = new String(bytes);
        System.out.println(st);

        String strAsBool = "true";
        Boolean newBool = Boolean.parseBoolean(strAsBool);
        //Boolean newBool2 = new Boolean(strAsBool);
        Boolean newBool3 = Boolean.valueOf(strAsBool);

        String strokeComp1 = "This is stroke";
        String strokeComp2 = "This is stroke";
        System.out.println(strokeComp1.equals(strokeComp2));
        System.out.println(strokeComp1.compareTo(strokeComp2));
        System.out.println(strokeComp1 == strokeComp2);

        /*String strokeComp3 = "This is stroke";
        String strokeComp4 = null;
        System.out.println("\n" + strokeComp3.equals(strokeComp4));
        System.out.println(strokeComp3.compareTo(strokeComp4));
        System.out.println(strokeComp3 == strokeComp4);*/

        System.out.println('\n' + str.hashCode());
        System.out.println(str.indexOf('l'));
        System.out.println(str.length());
        System.out.println(str.replace('e', 'u'));

        char[][] c1;
        char[] c2[];
        char c3[][]; //судя по всему, любым из этих способов

        //Можно ли определить массив нулевой длины? - да
        //Что случится, если индекс массива превысит его длину? - ошибка 'выход за диапазон допустимых значений'

        c1 = new char[3][];
        c1[0] = new char[1];
        c1[1] = new char[2];
        c1[2] = new char[3];
        System.out.println(c1.length);
        System.out.println(c1[0].length);
        System.out.println(c1[1].length);
        System.out.println(c1[2].length);

        c2 = new char[][]{{'a','b'}, {'c', 'd'}};
        c3 = new char[][]{{'b','c'}, {'s', 'e'}};
        System.out.println(c2 == c3);
        c2 = c3;
        System.out.println(c2 == c3);

        System.out.println('\n');
        for (var it : c2
             ) {
            System.out.println(it);
        }

        int newArr[] = {1,4,5,6};
        /*This is mistake
        for (int x = 0; x<newArr.length + 1; x++)
        {
            System.out.println(newArr[x]);
        }*/

        WrapperString ws = new WrapperString("Begin");
        ws.replace('e', 'a');
        System.out.println(ws.getName());

        WrapperString ws2 = new WrapperString("Begin") {
            public void replace(char oldchar, char newchar) {
                super.replace(oldchar, newchar); //super - basic class
            }

            public void delete(char newchar) {
                super.replace(newchar, ' ');
            }
        };

        /*
        * Аннотации – это пометки, с помощью которых программист указывает компилятору
        *  Java и средствам разработки, что делать с участками кода помимо
        *  исполнения программы.
         * */
    }
}

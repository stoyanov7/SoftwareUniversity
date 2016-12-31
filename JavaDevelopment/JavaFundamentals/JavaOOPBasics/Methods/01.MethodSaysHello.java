import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.Scanner;

class Person {
    String name;

    public static String sayHello(String s) {
        return s + " says \"Hello\"!";
    }
}

public class MethodSaysHello {
    public static void main(String[]args) throws ClassNotFoundException {
        Scanner scanner = new Scanner(System.in);
        String name = scanner.nextLine();
        System.out.println(Person.sayHello(name));

        Field[] fields = Person.class.getDeclaredFields();
        Method[] methods = Class.forName("Person").getDeclaredMethods();
        if (fields.length != 1 || methods.length != 1) {
            throw new ClassFormatError();
        }
    }
}

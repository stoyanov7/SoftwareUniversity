import java.lang.reflect.Field;

class Person {
    private String name;
    private int age;
}

public class DefineClassPerson {
    public static void main(String[] args) throws Exception {
        Class person = Person.class;
        Field[] fields = person.getDeclaredFields();
        System.out.println(fields.length);
    }
}

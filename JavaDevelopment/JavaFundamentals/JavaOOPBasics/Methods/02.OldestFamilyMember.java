import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

class Person {
    private String name;
    private Integer age;

    public Person(String name, Integer age) {
        this.name = name;
        this.age = age;
    }

    public String getName() {
        return this.name;
    }

    public Integer getAge() {
        return this.age;
    }
}

class Family {
    private List<Person> personList;

    public Family() {
        this.personList = new ArrayList<>();
    }

    public void addMember(Person member) {
        personList.add(member);
    }

    public Person getOldestMember() {
        List<Person> buffer =
            personList.stream()
            .sorted((p1, p2) -> p2.getAge().compareTo(p1.getAge()))
            .collect(Collectors.toList());

        return buffer.get(0);
    }
}

public class OldestFamilyMember {
    public static void main(String[]args) throws ClassNotFoundException, NoSuchMethodException {
        Scanner scanner = new Scanner(System.in);
        Family family = new Family();
        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" ");
            Person person = new Person(input[0], Integer.parseInt(input[1]));
            family.addMember(person);
        }

        System.out.printf("%s %d",
                family.getOldestMember().getName(),
                family.getOldestMember().getAge()
        );

        Method getOldestMethod = Family.class.getMethod("getOldestMember");
        Method addMemberMethod = Family.class.getMethod("addMember", Person.class);
    }
}

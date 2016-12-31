import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class Person implements Comparable<Person> {
    private String name;
    private int age;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public String getName() {
        return this.name;
    }

    public int getAge() {
        return this.age;
    }

    @Override
    public int compareTo(Person p) {
        return this.getName().compareTo(p.getName());
    }
}

public class OpinionPoll {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Person person;
        List<Person> personList = new ArrayList<>();
        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" ");
            String name = input[0];
            int age = Integer.parseInt(input[1]);
            person = new Person(name,age);

            if (person.getAge() > 30) {
                personList.add(person);
            }
        }
        
        personList.stream().sorted().forEach(p -> System.out.printf("%s - %d%n", p.getName(), p.getAge()));
    }
}

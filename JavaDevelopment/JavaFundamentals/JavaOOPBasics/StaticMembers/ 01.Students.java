import java.util.Scanner;

class Student {
    private String name;
    public static int countStudent = 0;

    public Student(String name) {
        this.name = name;
        countStudent++;
    }
}

public class StudentsStartUp {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        while (true) {
            String input = scanner.nextLine();
            if (input.equals("End")) {
                break;
            }
            Student student = new Student(input);
        }
        System.out.println(Student.countStudent);
    }
}

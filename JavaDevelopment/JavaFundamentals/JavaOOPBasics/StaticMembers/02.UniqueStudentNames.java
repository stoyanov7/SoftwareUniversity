import java.util.HashSet;
import java.util.Scanner;

class Student {
    private String name;

    public Student(String name) {
        this.name = name;
        StudentGroup.uniqueStudents.add(this.name);
    }
}

class StudentGroup {
    public static HashSet<String> uniqueStudents = new HashSet<>();
}

public class UniqueStudentNames {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = null;

        while (!(input = scanner.nextLine()).toLowerCase().equals("end")) {
            Student student = new Student(input);
        }

        System.out.println(StudentGroup.uniqueStudents.size());
    }
}

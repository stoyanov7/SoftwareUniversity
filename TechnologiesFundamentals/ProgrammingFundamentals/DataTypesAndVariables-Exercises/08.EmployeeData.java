import java.util.Scanner;

public class EmployeeData {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String firstName = scanner.nextLine();
        String lastName = scanner.nextLine();
        int age = Integer.parseInt(scanner.nextLine());
        String gender = scanner.nextLine();
        long personalID = Long.parseLong(scanner.nextLine());
        long uniqueNumber = Long.parseLong(scanner.nextLine());

        System.out.printf("First name: %s%n", firstName);
        System.out.printf("Last name: %s%n", lastName);
        System.out.printf("Age: %d%n", age);
        System.out.printf("Gender: %s%n", gender);
        System.out.printf("Personal ID: %d%n", personalID);
        System.out.printf("Unique Employee number: %d%n", uniqueNumber);
    }
}

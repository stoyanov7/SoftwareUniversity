import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String firstName = scanner.nextLine();
        String lastName = scanner.nextLine();
        int age = scanner.nextInt();
        scanner.nextLine();
        String town = scanner.nextLine();

        System.out.printf("You are %s %s, a %d-years old person from %s.%n",
                firstName, lastName, age, town);
    }
}

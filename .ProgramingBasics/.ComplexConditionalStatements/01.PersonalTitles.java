import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double age = scanner.nextDouble();
        scanner.nextLine();
        String sex = scanner.nextLine();

        if (sex.equals("m")) {
            if (age >= 16) {
                System.out.println("Mr.");
            }
            else if (age < 16) {
                System.out.println("Master");
            }
        }
        else if (sex.equals("f")) {
            if (age >= 16) {
                System.out.println("Ms.");
            }
            else if (age < 16) {
                System.out.println("Miss");
            }
        }
    }
}

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int input = scanner.nextInt();

        if (input >= 100 && input <= 200) {
            System.out.println();
        }
        else if (input == 0) {
            System.out.println();
        }
        else {
            System.out.println("invalid");
        }
    }
}

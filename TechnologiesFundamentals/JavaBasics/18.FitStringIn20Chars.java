import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        if (input.length() < 20) {
            System.out.print(input);
            for (int i = input.length(); i < 20; i++) {
                System.out.print("*");
            }
        }

        if (input.length() > 20) {
            System.out.println(input.substring(0, 20));
        }
    }
}

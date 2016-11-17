import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = 0;

        do {
            try {
                n = Integer.parseInt(scanner.nextLine());
                if (n % 2 == 0) {
                    break;
                }

                System.out.println("The number is even.");
                n = Integer.parseInt(scanner.nextLine());
            }
            catch (NumberFormatException nfex) {
                System.out.println("Invalid number!");
            }
        }while (true);
        System.out.printf("Even number entered: %d", n);
    }
}

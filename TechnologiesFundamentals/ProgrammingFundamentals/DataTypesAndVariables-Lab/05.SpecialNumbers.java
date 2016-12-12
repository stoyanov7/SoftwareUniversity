import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i <= n; i++) {
            int sumOfDigits = 0;
            int number = i;

            while (number > 0)
            {
                sumOfDigits += number % 10;
                number = number / 10;
            }

            boolean isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
            System.out.printf("%d -> %s%n", i, isSpecial);
        }
    }
}

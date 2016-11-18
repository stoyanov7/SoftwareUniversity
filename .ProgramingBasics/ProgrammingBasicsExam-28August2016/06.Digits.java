import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());
        int firstDigit = number / 100;
        int secondDigit = (number / 10) % 10;
        int thirdDigit = number % 10;

        int rows = firstDigit + secondDigit;
        int cols = firstDigit + thirdDigit;

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (number % 5 == 0) {
                    number -= firstDigit;
                }
                else if (number % 3 == 0) {
                    number -= secondDigit;
                }
                else {
                    number += thirdDigit;
                }
                System.out.print(number + " ");
            }
            System.out.println();
        }
    }
}

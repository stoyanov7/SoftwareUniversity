import java.util.Scanner;

public class NumbersInReversedOrder {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String inputNumber = scanner.nextLine();
        reverseNumber(inputNumber);
    }

    private static void reverseNumber(String number) {
        for (int i = number.length() - 1; i >= 0; i--) {
            System.out.print(number.charAt(i));
        }
    }
}

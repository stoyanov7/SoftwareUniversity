import java.util.Scanner;

public class MathPower {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double a = Double.parseDouble(scanner.nextLine());
        double b = Double.parseDouble(scanner.nextLine());

        System.out.println((int)raiseToPower(a, b));
    }

    private static double raiseToPower(double number, double power) {
        double result = number;

        for (int i = 1; i < power; i++) {
            result *= number;
        }

        return result;
    }
}

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double num1 = scanner.nextDouble();
        double num2 = scanner.nextDouble();
        double num3 = scanner.nextDouble();

        if (num1 == num2 && num1 == num3) {
            System.out.println("yes");
        }
        else {
            System.out.println("no");
        }
    }
}

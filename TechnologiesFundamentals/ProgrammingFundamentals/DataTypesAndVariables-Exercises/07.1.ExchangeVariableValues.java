import java.util.Scanner;

public class ExchangeVariableValues {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int a = Integer.parseInt(scanner.nextLine());
        int b = Integer.parseInt(scanner.nextLine());

        System.out.println("Before:");
        System.out.printf("a = %d%n", a);
        System.out.printf("b = %d%n", b);

        System.out.println("After:");
        int temp = b;
        b = a;
        a = temp;
        System.out.printf("a = %d%n", a);
        System.out.printf("b = %d%n", b);

   }
}

import java.util.Scanner;

public class GreaterNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter two integers:");
        int num1 = Integer.parseInt(scanner.nextLine());
        int num2 = Integer.parseInt(scanner.nextLine());

        if (num1 > num2) {
            System.out.println("Greater number: " + num1);
        }
        else {
            System.out.println("Greater number: " + num2);
        }
    }
}

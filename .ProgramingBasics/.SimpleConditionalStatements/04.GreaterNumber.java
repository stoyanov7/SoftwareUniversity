import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter two integers:");
        int num1 = scanner.nextInt();
        int num2 = scanner.nextInt();

        if (num1 > num2) 
            System.out.println("Greater number: " + num1);
        else
            System.out.println("Greater number: " + num2);
    }
}

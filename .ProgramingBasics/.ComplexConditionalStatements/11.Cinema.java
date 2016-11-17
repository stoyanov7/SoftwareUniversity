import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        int row = scanner.nextInt();
        int col = scanner.nextInt();
        double price;

        if (input.equals("Premiere")) {
            price = 12.00;
            System.out.printf("%.2f leva", price * row * col);
        }
        else if (input.equals("Normal")) {
            price = 7.50;
            System.out.printf("%.2f leva",price * row * col);
        }
        else if (input.equals("Discount")) {
            price = 5.00;
            System.out.printf("%.2f leva",price * row * col);
        }
    }
}

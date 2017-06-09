import java.util.Scanner;

public class Cinema {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        int row = Integer.parseInt(scanner.nextLine());
        int col = Integer.parseInt(scanner.nextLine());
        double price = 0;

        switch (input) {
            case "Premiere":
                price = 12.00;
                System.out.printf("%.2f leva", price * row * col);
                break;
            case "Normal":
                price = 7.50;
                System.out.printf("%.2f leva", price * row * col);
                break;
            case "Discount":
                price = 5.00;
                System.out.printf("%.2f leva", price * row * col);
                break;
        }
    }
}
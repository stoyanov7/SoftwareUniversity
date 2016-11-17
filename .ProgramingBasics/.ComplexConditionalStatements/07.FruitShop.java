import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String fruit = scanner.nextLine();
        String dayOfWeek = scanner.nextLine();
        double quantity = scanner.nextDouble();
        double price = 0.0;

        if (dayOfWeek.equals("Monday") || dayOfWeek.equals("Tuesday") ||
                dayOfWeek.equals("Wednesday") || dayOfWeek.equals("Thursday")
                || dayOfWeek.equals("Friday")) {
            switch (fruit) {
                case "banana":
                    price = 2.50;
                    System.out.printf("%.2f", price * quantity);
                    break;
                case "apple":
                    price = 1.20;
                    System.out.printf("%.2f", price * quantity);
                    break;
                case "orange":
                    price = 0.85;
                    System.out.printf("%.2f", price * quantity);
                    break;
                case "grapefruit":
                    price = 1.45;
                    System.out.printf("%.2f", price * quantity);
                    break;
                case "kiwi":
                    price = 2.70;
                    System.out.printf("%.2f", price * quantity);
                    break;
                case "pineapple":
                    price = 5.50;
                    System.out.printf("%.2f", price * quantity);
                    break;
                case "grapes":
                    price = 3.85;
                    System.out.printf("%.2f", price * quantity);
                    break;
                default:
                    System.out.println("error");
                    break;
            }
        }
        else if (dayOfWeek.equals("Saturday") || dayOfWeek.equals("Sunday")) {
            switch (fruit) {
                case "banana":
                    price = 2.70;
                    System.out.printf("%.2f",price * quantity);
                    break;
                case "apple":
                    price = 1.25;
                    System.out.printf("%.2f",price * quantity);
                    break;
                case "orange":
                    price = 0.90;
                    System.out.printf("%.2f",price * quantity);
                    break;
                case "grapefruit":
                    price = 1.60;
                    System.out.printf("%.2f",price * quantity);
                    break;
                case "kiwi":
                    price = 3.00;
                    System.out.printf("%.2f",price * quantity);
                    break;
                case "pineapple":
                    price = 5.60;
                    System.out.printf("%.2f",price * quantity);
                    break;
                case "grapes":
                    price = 4.20;
                    System.out.printf("%.2f",price * quantity);
                    break;
                default:
                    System.out.println("error");
            }
        }
        else
            System.out.println("error");
    }
}

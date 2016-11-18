import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        String category = scanner.nextLine();
        int numberOfPeople = Integer.parseInt(scanner.nextLine());

        double transportPrice = 0.0;
        if (numberOfPeople >= 1 && numberOfPeople < 5) {
            budget *= 0.25;
        } 
        else if (numberOfPeople >= 5 && numberOfPeople < 10) {
            budget *= 0.40;
        } 
        else if (numberOfPeople >= 10 && numberOfPeople < 25) {
            budget *= 0.50;
        } 
        else if (numberOfPeople >= 25 && numberOfPeople < 50) {
            budget *= 0.60;
        } 
        else {
            budget *= 0.75;
        }

        double ticket = category.equals("VIP") ? 499.99 : 249.99;
        double moneyForTickets = ticket * numberOfPeople;
        double left = budget - moneyForTickets;

        if (moneyForTickets <= budget) {
            System.out.printf("Yes! You have %.2f leva left.", left);
        } else {
            System.out.printf("Not enough money! You need %.2f leva.", Math.abs(left));
        }
    }
}

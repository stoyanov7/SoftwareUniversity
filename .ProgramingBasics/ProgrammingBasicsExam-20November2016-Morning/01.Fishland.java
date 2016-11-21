import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double priceМackerel = Double.parseDouble(scanner.nextLine());
        double priceSprat = Double.parseDouble(scanner.nextLine());
        double kgBonito = Double.parseDouble(scanner.nextLine());
        double kgScad = Double.parseDouble(scanner.nextLine());
        double kgMussels = Double.parseDouble(scanner.nextLine());

        double priceMackerel = priceМackerel + priceМackerel * 0.60;
        double sumSprat = kgBonito * priceMackerel;
        double priceBonito = priceSprat + priceSprat * 0.80;
        double sumScad = kgScad * priceBonito;
        double sumMussels = kgMussels * 7.50;

        double sumAll = sumSprat + sumScad + sumMussels;
        System.out.printf("%.2f", sumAll);
    }
}

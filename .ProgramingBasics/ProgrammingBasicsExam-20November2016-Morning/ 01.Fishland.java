import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double priceMackerel = Double.parseDouble(scanner.nextLine());
        double priceSprat = Double.parseDouble(scanner.nextLine());
        double kgBonito = Double.parseDouble(scanner.nextLine());
        double kgScad = Double.parseDouble(scanner.nextLine());
        double kgMussels = Double.parseDouble(scanner.nextLine());

        double priceBonito = priceMackerel + priceMackerel * 0.60;
        double sumBonito = kgBonito * priceBonito;
        double priceScad = priceSprat + priceSprat * 0.80;
        double sumScad = kgScad * priceScad;
        double sumMussels = kgMussels * 7.50;

        double sumAll = sumBonito + sumScad + sumMussels;
        System.out.printf("%.2f", sumAll);
    }
}

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double heritage = Double.parseDouble(scanner.nextLine());
        int yearToLive = Integer.parseInt(scanner.nextLine());
        int years = 18;

        for (int i = 1800; i <= yearToLive; i++) {
            if (i % 2 == 0) {
                heritage -= 12_000;
            }
            else {
                heritage -= (12_000 + 50 * years);
            }
            years++;
        }

        if (heritage < 0) {
            System.out.printf("He will need %.2f dollars to survive.", Math.abs(heritage));
        }
        else {
            System.out.printf("Yes! He will live a carefree life and will have %.2f dollars left.",
                heritage);
        }
    }
}

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int x = scanner.nextInt();
        double y = scanner.nextDouble();
        int z = scanner.nextInt();
        int workers = scanner.nextInt();

        int grapes = (int)(x * y);
        double wine = 0.4 * grapes / 2.5;

        double remain = wine - z;
        if (wine >= z) {
            System.out.printf("Good harvest this year! Total wine: %d liters.\n", (int)wine);
            System.out.printf("%.0f liters left -> %.0f liters per person.", Math.ceil((remain)), Math.ceil(remain / workers));
        }
        else {
            System.out.printf("It will be a tough winter! More %d liters wine needed.", (int)Math.floor(z - wine));
        }
    }
}

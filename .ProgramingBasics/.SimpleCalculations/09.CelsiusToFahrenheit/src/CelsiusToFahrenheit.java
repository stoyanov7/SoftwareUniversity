import java.util.Scanner;

public class CelsiusToFahrenheit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double gradus = Double.parseDouble(scanner.nextLine());
        double celsius = gradus * 1.80000 + 32;

        System.out.println(celsius);
    }
}
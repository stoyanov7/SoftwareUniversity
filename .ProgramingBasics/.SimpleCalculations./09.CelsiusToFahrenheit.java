import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double gradus = scanner.nextDouble();
        double celsius = gradus * 1.80000 + 32;

        System.out.println(celsius);
    }
}

import java.util.Scanner;

public class TrapeziodArea {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double a = scanner.nextDouble();
        double b = scanner.nextDouble();
        double h = scanner.nextDouble();

        double area = (a + b) * h / 2;
        System.out.println(area);
    }
}
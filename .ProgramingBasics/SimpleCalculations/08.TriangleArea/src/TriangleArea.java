import java.util.Scanner;

public class TriangleArea {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double a = scanner.nextDouble();
        double h = scanner.nextDouble();

        double area = a * h / 2;

        System.out.println("Triangle area = " + area);
    }
}
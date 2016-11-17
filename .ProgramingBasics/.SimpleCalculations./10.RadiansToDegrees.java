import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double radians = scanner.nextDouble();
        double celsius = radians * 180 / Math.PI;

        System.out.println(Math.round(celsius));
    }
}

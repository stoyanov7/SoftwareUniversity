import java.util.Scanner;

public class ComparingFloats {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double a = Double.parseDouble(scanner.nextLine());
        double b = Double.parseDouble(scanner.nextLine());
        double eps = 0.000001;

        System.out.println(Math.abs(a - b) < eps ? "True" : "False");
    }
}

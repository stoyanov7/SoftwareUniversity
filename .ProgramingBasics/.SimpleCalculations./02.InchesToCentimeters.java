import java.util.Scanner;

public class InchesТoCentimeters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("inches = ");
        double inches = scanner.nextDouble();
        System.out.println("centimeters = " + inches * 2.54);
    }
}

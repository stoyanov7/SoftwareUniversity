import java.text.MessageFormat;
import java.util.Scanner;

public class CenterPoint {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double x1 = Double.parseDouble(scanner.nextLine());
        double y1 = Double.parseDouble(scanner.nextLine());
        double x2 = Double.parseDouble(scanner.nextLine());
        double y2 = Double.parseDouble(scanner.nextLine());

        double distanceToCenterA = getDistanceBetweenTwoPoints(x1, y1, 0, 0);
        double distanceToCenterB = getDistanceBetweenTwoPoints(x2, y2, 0, 0);

        if (distanceToCenterA > distanceToCenterB) {
            System.out.println(MessageFormat.format("({0}, {1})", x2, y2));
        }
        else {
            System.out.println(MessageFormat.format("({0}, {1})", x1, y1));
        }
    }

    private static double getDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2) {
        return Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));
    }
}

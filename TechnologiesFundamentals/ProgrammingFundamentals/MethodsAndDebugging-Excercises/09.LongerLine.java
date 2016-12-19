import java.text.MessageFormat;
import java.util.Scanner;

public class LongerLine {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double x1 = Double.parseDouble(scanner.nextLine());
        double y1 = Double.parseDouble(scanner.nextLine());
        double x2 = Double.parseDouble(scanner.nextLine());
        double y2 = Double.parseDouble(scanner.nextLine());

        double x3 = Double.parseDouble(scanner.nextLine());
        double y3 = Double.parseDouble(scanner.nextLine());
        double x4 = Double.parseDouble(scanner.nextLine());
        double y4 = Double.parseDouble(scanner.nextLine());

        double fistLineLength = getDistanceBetweenTwoPoints(x1, y1, x2, y2);
        double secondLineLength = getDistanceBetweenTwoPoints(x3, y3, x4, y4);

        if (fistLineLength >= secondLineLength) {
            printLine(x1, y1, x2, y2);
        }
        else {
            printLine(x3, y3, x4, y4);
        }
    }

    private static void printLine(double x1, double y1, double x2, double y2) {
        double distanceToCenterA = getDistanceBetweenTwoPoints(x1, y1, 0, 0);
        double distanceToCenterB = getDistanceBetweenTwoPoints(x2, y2, 0, 0);

        if (distanceToCenterA <= distanceToCenterB) {
            System.out.println(MessageFormat.format("({0}, {1})({2}, {3})", x1, y1, x2, y2));
        }
        else {
            System.out.println(MessageFormat.format("({0}, {1})({2}, {3})", x2, y2, x1, y1));
        }
    }

    private static double getDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2) {
        return Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));
    }
}

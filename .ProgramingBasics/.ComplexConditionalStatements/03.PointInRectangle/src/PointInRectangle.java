import java.util.Scanner;

public class PointInRectangle {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double x1 = Double.parseDouble(scanner.nextLine());
        double y1 = Double.parseDouble(scanner.nextLine());

        double x2 = Double.parseDouble(scanner.nextLine());
        double y2 = Double.parseDouble(scanner.nextLine());

        double x = Double.parseDouble(scanner.nextLine());
        double y = Double.parseDouble(scanner.nextLine());

        boolean isInside = (x >= x1 && x <= x2) && (y >= y1 && y <= y2);

        if (isInside) {
            System.out.println("Inside");
        }
        else {
            System.out.println("Outside");
        }
    }
}
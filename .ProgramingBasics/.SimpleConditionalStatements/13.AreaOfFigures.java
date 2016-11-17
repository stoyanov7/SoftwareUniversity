import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        double area;

        if (input.equals("square")) {
            double side = scanner.nextDouble();
            area = Math.pow(side, 2);
            System.out.println(area);
        }
        else if (input.equals("rectangle")) {
            double sideA = scanner.nextDouble();
            double sideB = scanner.nextDouble();
            area = sideA * sideB;
            System.out.println(area);
        }
        else if (input.equals("circle")) {
            double radius = scanner.nextDouble();
            area = Math.PI * Math.pow(radius, 2);
            System.out.println(area);
        }
        else if (input.equals("triangle")) {
            double side = scanner.nextDouble();
            double height = scanner.nextDouble();
            area = (side * height) / 2.0;
            System.out.println(area);
        }
    }
}

import java.util.Scanner;

public class AreaOfFigures {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        double area;

        switch (input) {
            case "square": {
                double side = Double.parseDouble(scanner.nextLine());
                area = Math.pow(side, 2);
                System.out.println(area);
                break;
            }
            case "rectangle":
                double sideA = Double.parseDouble(scanner.nextLine());
                double sideB = Double.parseDouble(scanner.nextLine());
                area = sideA * sideB;
                System.out.println(area);
                break;
            case "circle":
                double radius = Double.parseDouble(scanner.nextLine());
                area = Math.PI * Math.pow(radius, 2);
                System.out.println(area);
                break;
            case "triangle": {
                double side = Double.parseDouble(scanner.nextLine());
                double height = Double.parseDouble(scanner.nextLine());
                area = (side * height) / 2.0;
                System.out.println(area);
                break;
            }
        }
    }
}
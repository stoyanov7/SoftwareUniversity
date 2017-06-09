import java.util.Scanner;

public class MetricConverter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double number = Double.parseDouble(scanner.nextLine());
        String sourceMetric = scanner.nextLine();
        String destMetric = scanner.nextLine();

        double baseMetricCoefficient = number;
        double coefficient = getCoefficient(sourceMetric);
        baseMetricCoefficient /= coefficient;

        coefficient = getCoefficient(destMetric);
        baseMetricCoefficient *= coefficient;

        System.out.println(baseMetricCoefficient + " " + destMetric);
    }

    private static double getCoefficient(String metric) {
        double result = 0;

        switch (metric) {
            case "m":
                result = 1;
                break;
            case "mm":
                result = 1000;
                break;
            case "cm":
                result = 100;
                break;
            case "mi":
                result = 0.000621371192;
                break;
            case "in":
                result = 39.3700787;
                break;
            case "km":
                result = 0.001;
                break;
            case "ft":
                result = 3.2808399;
                break;
            case "yd":
                result = 1.0936133;
                break;
        }

        return result;
    }
}

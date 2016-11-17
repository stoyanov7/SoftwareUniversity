import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double number = scanner.nextDouble();
        scanner.nextLine();
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

        if (metric.equals("m")) {
            result = 1;
        }
        else if (metric.equals("mm")) {
            result = 1000;
        }
        else if (metric.equals("cm")) {
            result = 100;
        }
        else if (metric.equals("mi")) {
            result = 0.000621371192;
        }
        else if (metric.equals("in")) {
            result = 39.3700787;
        }
        else if (metric.equals("km")) {
            result = 0.001;
        }
        else if (metric.equals("ft")) {
            result = 3.2808399;
        }
        else if (metric.equals("yd")) {
            result = 1.0936133;
        }

        return result;
    }
}

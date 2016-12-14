import java.util.Scanner;

public class DrawAFilledSquare {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        printHeaderRow(n);
        printMiddleRow(n);
        printHeaderRow(n);
    }

    private static void printHeaderRow(int n) {
        System.out.println(repeatString("-", 2 * n));
    }

    private static void printMiddleRow(int n) {
        for (int i = 0; i < n - 2; i++) {
            System.out.print("-");
            for (int j = 1; j < n; j++) {
                System.out.print("\\/");
            }
            System.out.printf("-%n");
        }
    }

    private static String repeatString(String s, int n) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++) {
            sb.append(s);
        }

        return sb.toString();
    }
}

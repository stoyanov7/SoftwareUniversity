import java.util.Scanner;

public class Pre-ActionsAndPost-Actions {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        printFigure(n);
    }

    private static void printFigure(int n) {
        if (n == 0) {
            return;
        }

        System.out.println(repeatString("*", n));
        printFigure(n - 1);
        System.out.println(repeatString("#", n));
    }

    private static String repeatString(String str, int count) {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < count; i++) {
            sb.append(str);
        }

        return sb.toString();
    }
}

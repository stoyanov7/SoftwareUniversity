import java.text.MessageFormat;
import java.util.Scanner;

public class Sunglasses {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            if (i == 0 || i == n - 1) {
                System.out.println(
                    MessageFormat.format("{0}{1}{0}",
                    repeatStr("*", n * 2), repeatStr(" ", n))
                );
            }
            else if (i == (n - 1) / 2) {
                System.out.println(
                    MessageFormat.format("*{0}*{1}*{0}*",
                    repeatStr("/", (n * 2) - 2), repeatStr("|", n))
                );
            }
            else {
                System.out.println(
                    MessageFormat.format("*{0}*{1}*{0}*",
                    repeatStr("/", (n * 2) - 2), repeatStr(" ", n))
                );
            }
        }
    }

    private static String repeatStr(String str, int count) {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < count; i++) {
            sb.append(str);
        }

        return sb.toString();
    }
}
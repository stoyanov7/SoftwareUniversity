import java.text.MessageFormat;
import java.util.Scanner;

public class House {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        int stars = 1;

        if (n % 2 == 0) {
            stars = 2;
        }
        int dashes = (n - stars) / 2;

        for (int i = 0; i < (n + 1) / 2; i++) {
            System.out.println(
                MessageFormat.format("{0}{1}{0}", repeatStr("-", dashes), repeatStr("*", stars))
            );
            stars += 2;
            dashes--;
        }

        for (int i = 0; i < n / 2; i++) {
            System.out.println(MessageFormat.format("|{0}|", repeatStr("*",n - 2)));
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

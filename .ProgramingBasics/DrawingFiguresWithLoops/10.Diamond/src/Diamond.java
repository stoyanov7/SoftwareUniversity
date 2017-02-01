import java.text.MessageFormat;
import java.util.Scanner;

public class Diamond {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        int dashes = (n - 1) / 2;
        int middleDashes = 1;
        int stars = 1;
        int oddOrEven = 1;

        if (n % 2 == 0) {
            stars = 2;
            middleDashes = 2;
            oddOrEven = 0;
        }

        if (n == 1) {
            System.out.println("*");
        }
        else if (n == 2) {
            System.out.println("**");
        }
        else {
            for (int i = 0; i < n / 2 + oddOrEven; i++) {
                if (i == 0) {
                    System.out.println(
                        MessageFormat.format("{0}{1}{0}",
                        repeatStr("-", (n - 1) / 2), repeatStr("*", stars))
                    );
                }
                else {
                    dashes--;
                    System.out.println(
                        MessageFormat.format("{0}*{1}*{0}",
                        repeatStr("-", dashes), repeatStr("-", middleDashes))
                    );
                    middleDashes += 2;
                }
            }
            dashes = 0;
            middleDashes -= 2;

            for (int i = 0; i < (n + 1) / 2 - 2; i++) {
                dashes++;
                middleDashes -= 2;
                System.out.println(
                    MessageFormat.format("{0}*{1}*{0}",
                    repeatStr("-", dashes), repeatStr("-", middleDashes))
                );
            }

            System.out.println(
                MessageFormat.format("{0}{1}{0}",
                    repeatStr("-", (n - 1) / 2), repeatStr("*", stars))
            );
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
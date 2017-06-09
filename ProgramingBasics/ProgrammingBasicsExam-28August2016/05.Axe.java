import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());

        int width = 5 * n;
        int leftDashes = 3 * n;
        int middleDashes = 0;
        int rightDashes = width - leftDashes - 2;

        for (int i = 0; i < n; i++) {
            System.out.printf("%s*%s*%s%n",
                repeatString("-", leftDashes),
                repeatString("-", middleDashes),
                repeatString("-", rightDashes)
            );

            middleDashes++;
            rightDashes--;
        }

        middleDashes--;
        rightDashes++;

        for (int i = 0; i < n / 2; i++) {
            System.out.printf("%s*%s*%s%n",
                    repeatString("*", leftDashes),
                    repeatString("-", middleDashes),
                    repeatString("-", rightDashes)
            );
        }

        for (int i = 0; i < n / 2 - 1; i++) {
            System.out.printf("%s*%s*%s%n",
                    repeatString("-", leftDashes),
                    repeatString("-", middleDashes),
                    repeatString("-", rightDashes)
            );

            leftDashes--;
            middleDashes += 2;
            rightDashes--;
        }

        System.out.printf("%s*%s*%s%n",
                repeatString("-", leftDashes),
                repeatString("*", middleDashes),
                repeatString("-", rightDashes)
        );
    }

    public static String repeatString(String str, int count) {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < count; i++) {
            sb.append(str);
        }

        return sb.toString();
    }
}

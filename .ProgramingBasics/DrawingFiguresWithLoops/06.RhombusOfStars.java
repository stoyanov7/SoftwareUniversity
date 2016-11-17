import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());

        int spaces = n - 1;
        for (int i = 0; i < n; i++) {
            System.out.print(repeatStr(" ", spaces - i));
            System.out.print(repeatStr("* ", i + 1));
            System.out.println();
        }

        for (int i = n - 2; i >= 0; i--) {
            System.out.print(repeatStr(" ", spaces - i));
            System.out.print(repeatStr("* ", i + 1));
            System.out.println();
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

import java.util.Scanner;

class DecimalNumber {
    private String number;

    public static void reverseNumber(String s) {
        String reverse = new StringBuilder(s).reverse().toString();
        System.out.println(reverse);
    }
}

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String n = scanner.nextLine();

        DecimalNumber.reverseNumber(n);
    }
}

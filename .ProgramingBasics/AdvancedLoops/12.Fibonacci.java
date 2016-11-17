import java.util.Scanner;

public class Main {
    public static long fibonacci (int n) {
        if ((n == 0) || (n == 1)) {
            return 1;
        }

        return fibonacci(n - 1) + fibonacci(n - 2);
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        System.out.println(fibonacci(n));
    }
}

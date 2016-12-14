import java.util.Scanner;

public class PrimeChecker {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long n = Long.parseLong(scanner.nextLine());

        if (isPrime(n)) {
            System.out.println("True");
        }
        else {
            System.out.println("False");
        }
    }

    private static boolean isPrime(long n) {
        if (n < 2) {
            return false;
        }
        else {
            for (int i = 2; i <= Math.sqrt(n); i++) {
                if (n % i == 0) {
                    return false;
                }
            }
        }
       return true;
    }
}

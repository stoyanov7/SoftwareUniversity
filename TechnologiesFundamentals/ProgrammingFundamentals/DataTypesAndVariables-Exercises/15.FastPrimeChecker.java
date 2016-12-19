import java.util.Scanner;

public class FastPrimeChecker {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        
        for (int i = 2; i <= n; i++) {
            boolean isPrime = true;
            for (int divisor = 2; divisor <= Math.sqrt(i); divisor++) {
                if (i % divisor == 0) {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime) {
                System.out.printf("%d -> True%n", i);
            }
            else {
                System.out.printf("%d -> False%n", i);
            }
        }
    }
}

import java.util.Scanner;

public class CheckPrime {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        boolean isPrime = true;

        if (n < 2) {
            isPrime = false;
        }
        else {
            for (int i = 2; i <= Math.sqrt(n); i++) {
                if (n % i == 0) {
                    isPrime = false;
                    break;
                }
            }
        }

        System.out.println(isPrime ? "Prime" : "Not prime");
    }
}

import java.util.Scanner;

public class SumDigits {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        int sum = 0;

        do {
            sum += (n % 10);
            n /= 10;
        } while (n > 0);

        System.out.println(sum);
    }
}

import java.math.BigDecimal;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        BigDecimal sum = new BigDecimal("0");

        for (int i = 0; i < n; i++) {
            BigDecimal value = new BigDecimal(scanner.nextLine());
            sum = sum.add(value);
        }

        System.out.println(sum);
    }
}

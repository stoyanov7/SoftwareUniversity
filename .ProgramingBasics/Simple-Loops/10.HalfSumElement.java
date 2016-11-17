import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int sum = 0;
        int max = 0;

        for (int i = 0; i < n; i++) {
            int num = scanner.nextInt();

            if (num > max) {
                max = num;
            }

            sum += num;
        }

        sum -= max;

        if (sum == max) {
            System.out.println("Yes");
            System.out.println("Sum = " + sum);
        }
        else {
            int diff = Math.abs(max - sum);
            System.out.println("No");
            System.out.println("Diff = " + diff);
        }
    }
}

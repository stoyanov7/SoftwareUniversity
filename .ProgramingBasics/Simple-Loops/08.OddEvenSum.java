import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int sumOdd = 0;
        int sumEven = 0;

        for (int i = 0; i < n; i++) {
            int num = scanner.nextInt();

            if (i % 2 == 0) {
                sumEven += num;
            }
            else if (i % 2 != 0) {
                sumOdd += num;
            }
        }

        int diff = Math.abs(sumEven - sumOdd);

        if (sumEven == sumOdd) {
            System.out.println("Yes");
            System.out.println("Sum = " + sumEven);
        }
        else {
            System.out.println("No");
            System.out.println("Diff " + diff);
        }
    }
}

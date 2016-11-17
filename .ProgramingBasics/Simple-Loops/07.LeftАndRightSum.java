import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int leftSum = 0, rightSum = 0;

        for (int i = 0; i < n; i++) {
            int leftInput = scanner.nextInt();
            leftSum += leftInput;
        }

        for (int j = 0; j < n; j++) {
            int rightInput = scanner.nextInt();
            rightSum += rightInput;
        }

        if (leftSum == rightSum) {
            System.out.println("Yes sum " + leftSum);
        }
        else {
            System.out.println("No diff " + Math.abs(leftSum - rightSum));
        }
    }
}

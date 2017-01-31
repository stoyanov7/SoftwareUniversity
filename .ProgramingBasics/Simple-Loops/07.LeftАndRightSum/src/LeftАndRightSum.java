import java.util.Scanner;

public class LeftАndRightSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        int leftSum = 0, rightSum = 0;

        for (int i = 0; i < n; i++) {
            int leftInput = Integer.parseInt(scanner.nextLine());
            leftSum += leftInput;
        }

        for (int j = 0; j < n; j++) {
            int rightInput = Integer.parseInt(scanner.nextLine());
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

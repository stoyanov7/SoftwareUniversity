import java.util.Arrays;
import java.util.Scanner;

public class LastKNumbersSums {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        int k = Integer.parseInt(scanner.nextLine());

        long[] numberArray = new long[n];
        numberArray[0] = 1;

        for (int i = 1; i < n; i++) {
            long sum = 0;

            for (int previous = i - k; previous <= i - 1; previous++) {
                if (previous >= 0) {
                    sum += numberArray[previous];
                }
            }
            numberArray[i] = sum;
        }

        Arrays.stream(numberArray).forEach(number -> System.out.print(number + " "));
    }
}

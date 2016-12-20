import java.text.MessageFormat;
import java.util.Scanner;

public class EqualPairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        int[] pairs = new int[n];
        int pairNumber = 0;

        for (int i = 1; i <= 2 * n; i++) {
            pairs[pairNumber] += Integer.parseInt(scanner.nextLine());
            if (i % 2 == 0 && i != 2 * n) {
                pairNumber++;
            }
        }
        boolean equal = false;
        int lastValue = pairs[0];
        int minValue = Integer.MAX_VALUE;
        int maxValue = Integer.MIN_VALUE;
        int maxDiff = 0;

        for (int i = 0; i < n; i++) {
            int diff = Math.abs(lastValue - pairs[i]);
            if (diff > maxDiff && i != 0) {
                maxDiff = diff;
            }
            if (pairs[i] == lastValue) {
                equal = true;
                lastValue = pairs[i];
            }
            else {
                equal = false;
                lastValue = pairs[i];
            }
            if (pairs[i] > maxValue) {
                maxValue = pairs[i];
            }
            if (pairs[i] < minValue) {
                minValue = pairs[i];
            }

        }

        System.out.println(equal ? 
            MessageFormat.format("Yes, value={0}", pairs[0]) :
            MessageFormat.format("No, maxdiff={0}", maxDiff)
        );
    }
}

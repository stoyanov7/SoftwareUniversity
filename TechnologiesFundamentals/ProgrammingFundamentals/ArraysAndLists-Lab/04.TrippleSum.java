import java.util.Arrays;
import java.util.Scanner;

public class TrippleSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int[] numbers = new int[input.length];
        boolean hasMatch = false;

        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(input[i]);
        }

        for (int i = 0; i < numbers.length; i++) {
            for (int j = i + 1; j < numbers.length; j++) {
                int sum = numbers[i] + numbers[j];

                if (contains(numbers, sum)) {
                    System.out.printf("%d + %d == %d%n", numbers[i], numbers[j], sum);
                    hasMatch = true;
                }
            }
        }

        if (!hasMatch) {
            System.out.println("No");
        }
    }

    private static boolean contains(final int[] arr, final int key) {
        return Arrays.stream(arr).anyMatch(i -> i == key);
    }
}

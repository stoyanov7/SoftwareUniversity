import java.util.Arrays;
import java.util.Scanner;

public class CondenseArrayToNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int[] numberArray = new int[input.length];

        for (int i = 0; i < numberArray.length; i++) {
            numberArray[i] = Integer.parseInt(input[i]);
        }

        while (numberArray.length > 1) {
            int[] condensed = new int[numberArray.length - 1];
            
            for (int j = 0; j < numberArray.length - 1; j++) {
                condensed[j] = numberArray[j] + numberArray[j + 1];
            }
            numberArray = condensed;
        }

        Arrays.stream(numberArray).forEach(System.out::println);
    }
}

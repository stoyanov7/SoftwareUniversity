import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> numbers = new ArrayList<>();
        String[] input = scanner.nextLine().split(" ");

        for (String anInput : input) {
            numbers.add(Integer.parseInt(anInput));
        }

        int maxNumbers = 0;
        int count = 1;
        int maxCount = 1;
        int pos = 0;

        while (pos < numbers.size() - 1) {
            if (numbers.get(pos).equals(numbers.get(pos + 1))) {
                count++;

                if (count > maxCount) {
                    maxCount = count;
                    maxNumbers = numbers.get(pos);
                }
            }
            else {
                count = 1;
            }

            pos++;

            if (maxCount == 1) {
                maxNumbers = numbers.get(0);
            }
        }

        for (int i = 0; i < maxCount; i++) {
            System.out.print(maxNumbers + " ");
        }
    }
}
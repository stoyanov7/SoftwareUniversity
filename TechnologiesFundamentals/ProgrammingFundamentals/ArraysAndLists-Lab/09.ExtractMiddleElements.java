import java.util.Scanner;

public class ExtractMiddleElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int[] numberArray = new int[input.length];

        for (int i = 0; i < numberArray.length; i++) {
            numberArray[i] = Integer.parseInt(input[i]);
        }

        if (numberArray.length == 1) {
            extractOne(numberArray);
        }
        else if (numberArray.length % 2 == 0) {
            extractEven(numberArray);
        }
        else {
            extractOdd(numberArray);
        }
    }

    private static void extractOne(final int[] arr) {
        System.out.printf("{ %d }", arr[0]);
    }

    private static void extractEven(final int[] arr) {
        System.out.printf("{ %d, %d }", arr[arr.length / 2 - 1], arr[arr.length / 2]);
    }

    private static void extractOdd(final int[] arr) {
        System.out.printf("{ %d, %d, %d }", arr[arr.length / 2 - 1], arr[arr.length / 2], arr[arr.length / 2 + 1]);
    }
}

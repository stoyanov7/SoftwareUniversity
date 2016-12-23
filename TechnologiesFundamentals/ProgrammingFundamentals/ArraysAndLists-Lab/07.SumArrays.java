import java.util.*;

public class SumArrays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] arrayInputOne = scanner.nextLine().split(" ");
        String[] arrayInputTwo = scanner.nextLine().split(" ");

        int[] arrayOne = new int[arrayInputOne.length];
        int[] arrayTwo = new int[arrayInputTwo.length];

        for (int i = 0; i < arrayOne.length; i++) {
            arrayOne[i] = Integer.parseInt(arrayInputOne[i]);
        }

        for (int j = 0; j < arrayTwo.length; j++) {
            arrayTwo[j] = Integer.parseInt(arrayInputTwo[j]);
        }

        int[] sumArray = new int[Math.max(arrayOne.length, arrayTwo.length)];

        for (int i = 0; i < sumArray.length; i++) {
            sumArray[i] = arrayOne[i % arrayOne.length] + arrayTwo[i % arrayTwo.length];
        }

        Arrays.stream(sumArray).forEach(e -> System.out.print(e + " "));
    }
}

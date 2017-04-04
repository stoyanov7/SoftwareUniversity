import java.util.Scanner;

public class MaxSequenceOfIncreasingElements {
    public static  void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int[] numbers = new int[input.length];

        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(input[i]);
        }

        int length = numbers.length;

        MaxIncSequence(numbers, length);
    }

    private static void MaxIncSequence(int[] numbers, int length) {
        int cntCurrSeq = 0;
        int startCurrSeq = 0;
        int cntMaxSeq = 0;
        int startMaxSeq = 0;

        for (int i = 1; i < length; i++) {
            if (numbers[i] - numbers[i - 1] >= 1) {
                cntCurrSeq++;
                startCurrSeq = i - cntCurrSeq;

                if (cntCurrSeq > cntMaxSeq) {
                    cntMaxSeq = cntCurrSeq;
                    startMaxSeq = startCurrSeq;
                }
            }
            else {
                cntCurrSeq = 0;
            }
        }

        for (int iWrite = startMaxSeq; iWrite <= (startMaxSeq + cntMaxSeq); iWrite++) {
            System.out.print(numbers[iWrite] + " ");
        }

        System.out.println();
    }
}
import java.util.Scanner;

public class MultiplyEvensByOdds {
    private static int getMultipleOfEvensAndOdds(int n) {
        int sumEvens = getSumOfEvenDigits(n);
        int sumOdds = getSumOfOddDigits(n);

        return sumEvens * sumOdds;
    }

    private static int getSumOfEvenDigits(int n) {
        int sum = 0;
        while (n > 0) {
            int lastDigit = n % 10;
            if (lastDigit % 2 != 0) {
                sum += lastDigit;
            }
            n /= 10;
        }

        return sum;

    }

    private static int getSumOfOddDigits(int n) {
        int sum = 0;
        while (n > 0) {
            int lastDigit = n % 10;
            if (lastDigit % 2 == 0) {
                sum += lastDigit;
            }
            n /= 10;
        }

        return sum;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num = Math.abs(Integer.parseInt(scanner.nextLine()));
        System.out.println(getMultipleOfEvensAndOdds(num));
    }
}

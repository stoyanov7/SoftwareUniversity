import java.text.MessageFormat;
import java.util.Scanner;

public class OddEvenPosition {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double n = Double.parseDouble(scanner.nextLine());
        double oddSum = 0;
        double oddMin = 1000000000.0;
        double oddMax = -1000000000.0;
        double evenSum = 0;
        double evenMin = 1000000000.0;
        double evenMax = -1000000000.0;

        for (int i = 1; i <= n; i++) {
            double num = Double.parseDouble(scanner.nextLine());

            if (i % 2 == 0) {
                evenSum += num;
                evenMin = Math.min(evenMin, num);
                evenMax = Math.max(evenMax, num);
            }
            else {
                oddSum += num;
                oddMin = Math.min(oddMin, num);
                oddMax = Math.max(oddMax, num);
            }
        }

        System.out.println(MessageFormat.format("OddSum={0}",oddSum));

        if (oddMin == 1000000000.0) {
            System.out.println("OddMin=No");
        }
        else {
            System.out.println(MessageFormat.format("OddMin={0}",oddMin));
        }

        if (oddMax == -1000000000.0) {
            System.out.println("OddMax=No");
        }
        else {
            System.out.println(MessageFormat.format("OddMax={0}", oddMax));
        }

        System.out.println(MessageFormat.format("EvenSum={0}", evenSum));

        if (evenMin == 1000000000.0) {
            System.out.println("evenMin=No");
        }
        else {
            System.out.println(MessageFormat.format("evenMin={0}", evenMin));
        }

        if (evenMax == -1000000000.0) {
            System.out.println("evenMax=No");
        }
        else {
            System.out.println(MessageFormat.format("evenMax={0}", evenMax));
        }
    }
}
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num = scanner.nextInt();
        double bonusScore = 0.;

        if (num <= 100) {
            bonusScore = 5;
        }
        else if (num > 1000) {
            bonusScore = 0.1 * num;
        }
        else if (num > 100) {
            bonusScore = 0.2 * num;
        }

        if (num % 2 == 0) {
            bonusScore += 1;
        }
        else if (num % 10 == 5) {
            bonusScore += 2;
        }

        System.out.println(bonusScore);
        System.out.println(num + bonusScore);
    }
}

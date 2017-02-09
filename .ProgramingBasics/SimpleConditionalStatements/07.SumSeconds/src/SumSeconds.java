import java.util.Scanner;

public class SumSeconds {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num1 = Integer.parseInt(scanner.nextLine());
        int num2 = Integer.parseInt(scanner.nextLine());
        int num3 = Integer.parseInt(scanner.nextLine());

        int seconds = num1 + num2 + num3;
        int minutes = seconds / 60;
        seconds = seconds % 60;

        if (seconds < 10) {
            System.out.printf("%d:0%d\n", minutes, seconds);
        }
        else {
            System.out.printf("%d:%d", minutes, seconds);
        }
    }
}

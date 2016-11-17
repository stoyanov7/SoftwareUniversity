import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num1 = scanner.nextInt();
        int num2 = scanner.nextInt();
        int num3 = scanner.nextInt();

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

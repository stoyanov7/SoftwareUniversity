import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int min = Integer.MAX_VALUE;
        for (int i = 0; i < n; i++) {
            int num = scanner.nextInt();
            
            if (num < min) {
                min = num;
            }
        }

        System.out.println(min);
    }
}

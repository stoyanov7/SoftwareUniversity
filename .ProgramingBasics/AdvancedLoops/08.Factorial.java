import java.util.Scanner;

public class Main {
    public static long factorial(int n) {
        if (n == 0)
            return 1;

        return  n * factorial(n - 1);
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        System.out.println(factorial(n));
    }
}

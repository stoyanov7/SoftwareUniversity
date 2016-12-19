import java.util.Scanner;

public class MaxMethod {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int ab = getMax(Integer.parseInt(scanner.nextLine()), Integer.parseInt(scanner.nextLine()));
        int biggest = getMax(ab, Integer.parseInt(scanner.nextLine()));

        System.out.println(biggest);

    }
    private static int getMax(int a, int b) {
        return a >= b ? a : b;
    }
}

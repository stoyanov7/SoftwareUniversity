import java.util.Scanner;

public class IntegerТoHexАndBinary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int input = scanner.nextInt();

        System.out.println(Integer.toHexString(input).toUpperCase());
        System.out.println(Integer.toBinaryString(input));
    }
}

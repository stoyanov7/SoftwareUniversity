import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String hex = scanner.nextLine();
        int decimal = Integer.parseInt(hex, 16);
        System.out.println(decimal);
    }
}

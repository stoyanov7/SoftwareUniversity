import java.util.Scanner;

public class USDToBGN {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double BGN = Double.parseDouble(scanner.nextLine());
        double rate = 1.79549;
        double USD = BGN * rate;

        System.out.println(USD + " BGN");
    }
}
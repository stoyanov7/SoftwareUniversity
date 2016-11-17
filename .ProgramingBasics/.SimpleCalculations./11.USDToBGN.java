import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double BGN = scanner.nextDouble();
        double rate = 1.79549;
        double USD = BGN * rate;

        System.out.println(USD + " BGN");
    }
}

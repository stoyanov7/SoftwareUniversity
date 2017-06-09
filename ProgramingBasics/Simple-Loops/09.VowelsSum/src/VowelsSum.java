import java.util.Objects;
import java.util.Scanner;

public class VowelsSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().toLowerCase().split("");
        int sum = 0;

        for (String anInput : input) {
            if (Objects.equals(anInput, "a")) {
                sum += 1;
            }
            else if (Objects.equals(anInput, "e")) {
                sum += 2;
            }
            else if (Objects.equals(anInput, "i")) {
                sum += 3;
            }
            else if (Objects.equals(anInput, "o")) {
                sum += 4;
            }
            else if (Objects.equals(anInput, "u")) {
                sum += 5;
            }
        }

        System.out.println(sum);
    }
}

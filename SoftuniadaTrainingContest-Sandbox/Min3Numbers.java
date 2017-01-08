import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class MinNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        List<Integer> numbers = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            numbers.add(Integer.parseInt(scanner.nextLine()));
        }

        Collections.sort(numbers);

        for (int i = 0; i < Math.min(n, 3); i++) {
            System.out.println(numbers.get(i));
        }
    }
}

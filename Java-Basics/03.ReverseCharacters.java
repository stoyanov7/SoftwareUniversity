import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input1 = scanner.nextLine();
        String input2 = scanner.nextLine();
        String input3 = scanner.nextLine();

        List<String> list = new ArrayList<>();
        list.add(input1);
        list.add(input2);
        list.add(input3);

        Collections.reverse(list);
        list.forEach(System.out::print);
    }
}

import java.util.Scanner;

public class EqualWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input1 = scanner.nextLine().toLowerCase();
        String input2 = scanner.nextLine().toLowerCase();

        if (input1.equals(input2)) {
            System.out.println("yes");
        }
        else {
            System.out.println("no");
        }
    }
}
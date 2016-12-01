import java.util.Scanner;

public class ReversedChars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input1 = scanner.nextLine();
        String input2 = scanner.nextLine();
        String input3 = scanner.nextLine();
        String inputAll = input1 + input2 + input3;
        inputAll = new StringBuilder(inputAll).reverse().toString();

        System.out.println(inputAll);
   }
}

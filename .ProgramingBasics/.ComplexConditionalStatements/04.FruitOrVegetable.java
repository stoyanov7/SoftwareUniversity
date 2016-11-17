import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        if (input.equals("banana") || input.equals("apple") || input.equals("kiwi") ||
                input.equals("cherry") || input.equals("lemon") || input.equals("grapes")) {
            System.out.println("fruit");
        }
        else if (input.equals("tomato") || input.equals("cucumber") || input.equals("pepper")
                || input.equals("carrot")) {
            System.out.println("vegetable");
        }
        else {
            System.out.println("unknown");
        }
    }
}

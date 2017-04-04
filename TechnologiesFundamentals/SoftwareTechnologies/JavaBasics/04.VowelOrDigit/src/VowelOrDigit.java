import java.util.Scanner;

public class VowelOrDigit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        boolean isVowel = input.equals("a") || input.equals("e") || input.equals("i") ||
                input.equals("o") || input.equals("u");

        boolean isDigit = input.equals("1") || input.equals("2") || input.equals("3") || input.equals("4") || input.equals("5")
                || input.equals("6") || input.equals("7") || input.equals("8") || input.equals("9");

        if (isVowel) {
            System.out.println("vowel");
        }
        else if (isDigit) {
            System.out.println("digit");
        }
        else {
            System.out.println("other");
        }
    }
}

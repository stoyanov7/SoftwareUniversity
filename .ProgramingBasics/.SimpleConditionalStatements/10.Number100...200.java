import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int input = scanner.nextInt();

        if (input < 100) {
            System.out.println("Less than 100");
        }
        else if (input >= 100 && input <= 200) {
            System.out.println("Between 100 and 200");
        }
        else if (input > 200) {
            System.out.println("Greater than 200");
        }
    }
}
import java.util.Scanner;

public class DayOfWeek {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        int n = Integer.parseInt(scanner.nextLine());

        System.out.println(n > 0 && n < 8 ? daysOfWeek[n - 1] : "Invalid day!");
    }
}

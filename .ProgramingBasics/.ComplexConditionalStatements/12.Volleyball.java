import java.util.Scanner;

public class Volleyball {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String year = scanner.nextLine();
        int p = Integer.parseInt(scanner.nextLine());
        int homeVisits = Integer.parseInt(scanner.nextLine());
        double weekends = 48 - homeVisits;

        double volleyballDays = weekends * 0.75;
        volleyballDays += homeVisits;
        double holidays = p * (2.0 / 3);
        volleyballDays = volleyballDays + holidays;

        if (year.equals("leap")) {
            volleyballDays = volleyballDays * 1.15;
        }
        System.out.println(truncateDouble(volleyballDays, 0));
    }

    private static double truncateDouble(double number, int numDigits) {
        double result = number;
        String arg = "" + number;
        int idx = arg.indexOf('.');
        if (idx != -1) {
            if (arg.length() > idx + numDigits) {
                arg = arg.substring(0, idx + numDigits + 1);
                result  = Double.parseDouble(arg);
            }
        }
        return result ;
    }
}

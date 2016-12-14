import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int day = Integer.parseInt(scanner.nextLine());
        int month = Integer.parseInt(scanner.nextLine());

        switch(month) {
            case 2:
                if (day + 5 > 28) {
                    month++;
                    day = day + 5 - 28;
                }
                else {
                    day += 5;
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                if (day + 5 > 30) {
                    month++;
                    day = day + 5 - 30;
                }
                else {
                    day += 5;
                }
                break;
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
                if (day + 5 > 31) {
                    month++;
                    day = day + 5 - 31;
                }
                else {
                    day += 5;
                }
                break;
            case 12:
                if (day + 5 > 31) {
                    month = 1;
                    day = day + 5 - 31;
                }
                else {
                    day += 5;
                }
                break;
            default:
                break;
        }

        System.out.print(day + ".");
        if (month < 10) {
            System.out.print("0");
        }
        System.out.print(month);
    }
}

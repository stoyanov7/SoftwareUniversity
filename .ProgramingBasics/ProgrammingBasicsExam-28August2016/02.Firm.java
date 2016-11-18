import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int neededHours = Integer.parseInt(scanner.nextLine());
        int days = Integer.parseInt(scanner.nextLine());
        int overtimeWorkers = Integer.parseInt(scanner.nextLine());

        double daysToWork = days - (days * 0.1);
        double workingTime = daysToWork * 8;
        double overtimeWork = overtimeWorkers * 2 * days;

        double totalWorkingTime = Math.floor(workingTime + overtimeWork);

        int remainingTime = (int)Math.abs(totalWorkingTime - neededHours);
        if (totalWorkingTime > neededHours) {
            System.out.printf("Yes!%d hours left.", remainingTime);
        }
        else {
            System.out.printf("Not enough time!%d hours needed.", remainingTime);
        }
    }
}

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int workDays = scanner.nextInt();
        double earnMoney = scanner.nextDouble();
        double dollar = scanner.nextDouble();

        double monthSalary = workDays * earnMoney;
        double yearSalary = monthSalary * 12 + monthSalary * 2.5;
        double percent = yearSalary * 0.25;
        double revenue = (yearSalary - percent) * dollar;
        double averageSalary = revenue / 365;

        System.out.printf("%.2f", averageSalary);
    }
}

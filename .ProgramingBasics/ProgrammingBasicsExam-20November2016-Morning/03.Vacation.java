import java.util.Scanner;

public class Vacation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numAdults = Integer.parseInt(scanner.nextLine());
        int numStudents = Integer.parseInt(scanner.nextLine());
        int numNights = Integer.parseInt(scanner.nextLine());
        String transport = scanner.nextLine();

        double expenses = 0;
        double hotel = 0;
        double commission = 0;
        double sumAll = 0;
        
        switch (transport) {
            case "airplane":
                expenses = ((numAdults * 70.00) + (numStudents * 50.00)) * 2;
                hotel = numNights * 82.99;
                commission = (expenses + hotel) * 0.10;
                sumAll = expenses + hotel + commission;
                System.out.printf("%.2f", sumAll);
                break;

            case "train":
                if ( numAdults + numStudents > 50) {
                    expenses = ((numAdults * 24.99 * 0.50) + (numStudents * 14.99 * 0.50)) * 2;
                }
                else {
                    expenses = ((numAdults * 24.99) + (numStudents * 14.99)) * 2;
                }
                hotel = numNights * 82.99;
                commission = (expenses + hotel) * 0.10;
                sumAll = expenses + hotel + commission;
                System.out.printf("%.2f", sumAll);
                break;

            case "bus":
                expenses = ((numAdults * 32.50) + (numStudents * 28.50)) * 2;
                hotel = numNights * 82.99;
                commission = (expenses + hotel) * 0.10;
                sumAll = expenses + hotel + commission;
                System.out.printf("%.2f", sumAll);
                break;

            case "boat":
                expenses = ((numAdults * 42.99) + (numStudents * 39.99)) * 2;
                hotel = numNights * 82.99;
                commission = (expenses + hotel) * 0.10;
                sumAll = expenses + hotel + commission;
                System.out.printf("%.2f", sumAll);
                break;
        }
    }
}

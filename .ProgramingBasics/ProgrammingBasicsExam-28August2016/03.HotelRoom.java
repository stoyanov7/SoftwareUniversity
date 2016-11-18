import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String month = scanner.nextLine();
        int numNight = scanner.nextInt();

        double studioPrice = 0.0;
        double apartmentPrice = 0.0;

        switch (month) {
            case "May":
            case "October":
                studioPrice = 50;
                apartmentPrice = 65;

                if (numNight > 14) {
                    studioPrice -= studioPrice * 0.3;
                    apartmentPrice -= apartmentPrice * 0.1;
                } 
                else if (numNight > 7) {
                    studioPrice -= studioPrice * 0.05;
                }
                break;

            case "June":
            case "September":
                studioPrice = 75.20;
                apartmentPrice = 68.70;

                if (numNight > 14) {
                    studioPrice -= studioPrice * 0.2;
                    apartmentPrice -= apartmentPrice * 0.1;
                }
                break;

            case "July":
            case "August":
                studioPrice = 76;
                apartmentPrice = 77;

                if (numNight > 14)
                {
                    apartmentPrice -= apartmentPrice * 0.1;
                }
                break;
        }

        double totalPriceApartment = apartmentPrice * numNight;
        double totalPriceStudio = studioPrice * numNight;

        System.out.printf("Apartment: %.2f lv.%n", totalPriceApartment);
        System.out.printf("Studio: %.2f lv.", totalPriceStudio);
    }
}

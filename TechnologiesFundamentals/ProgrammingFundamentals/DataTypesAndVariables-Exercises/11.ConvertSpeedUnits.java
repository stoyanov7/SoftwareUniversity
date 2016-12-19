import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int distanceM = Integer.parseInt(scanner.nextLine());
        int hours = Integer.parseInt(scanner.nextLine());
        int minutes = Integer.parseInt(scanner.nextLine());
        int seconds = Integer.parseInt(scanner.nextLine());

        int secondsConverted = (((hours * 60) * 60) + minutes * 60 + seconds);
        float mPs = ((float) distanceM / (float) secondsConverted);
        double hoursConverted = (hours + ((double) minutes / 60) + ((double) seconds / 60) / 60);
        float kmH = (((float) distanceM / 1000) / (float) hoursConverted);
        float mpH = (float) ((double) distanceM / (double) 1609) / (float) hoursConverted;

        System.out.printf("%f%n%f%n%f", mPs, kmH, mpH);
    }
}

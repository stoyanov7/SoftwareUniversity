import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numOfDays = Integer.parseInt(scanner.nextLine());
        double leftFoodKG = Double.parseDouble(scanner.nextLine());
        double foodForDogKG = Double.parseDouble(scanner.nextLine());
        double foodForCatKG = Double.parseDouble(scanner.nextLine());
        double foodForTurtleGR = Double.parseDouble(scanner.nextLine());

        double foodForDogDay = numOfDays * foodForDogKG;
        double foodForCatDay = numOfDays * foodForCatKG;
        double foodForTurtleDay = numOfDays * foodForTurtleGR / 1000.0;
        double totalFood = foodForDogDay + foodForCatDay + foodForTurtleDay;

        double left = 0;
        if (totalFood <= leftFoodKG) {
            left = leftFoodKG - totalFood;
            System.out.println((int)(Math.floor(left)) + " kilos of food left.");
        }
        else {
            left = totalFood - leftFoodKG;
            System.out.println((int)(Math.ceil(left)) + " more kilos of food are needed.");
        }
    }
}

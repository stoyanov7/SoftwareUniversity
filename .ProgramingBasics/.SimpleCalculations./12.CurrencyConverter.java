import java.util.Scanner;

public class Solution {
    private static final double BGN_TO_USD = 1.79549;
    private static final double BGN_TO_EUR = 1.95583;
    private static final double BGN_TO_GBP = 2.53405;

    public static void main(String args[]){
        Scanner scanner = new Scanner(System.in);
        double inputValue = scanner.nextDouble();
        scanner.nextLine();
        String inputCurrency = scanner.nextLine().toUpperCase();
        String outputCurrency = scanner.nextLine().toUpperCase();

        double inputValueInBGN = 0;
        switch (inputCurrency) {
            case "USD":
                inputValueInBGN = inputValue * BGN_TO_USD;
                break;

            case "EUR":
                inputValueInBGN = inputValue * BGN_TO_EUR;
                break;

            case "GBP":
                inputValueInBGN = inputValue * BGN_TO_GBP;
                break;

            default:
                inputValueInBGN = inputValue;
                break;
        }

        double outputValue = 0;
        switch (outputCurrency) {
            case "BGN":
                System.out.printf("%.2f %s", inputValueInBGN, outputCurrency);
                break;

            case "USD":
                outputValue = inputValueInBGN / BGN_TO_USD;
                System.out.printf("%.2f %s", outputValue, outputCurrency);
                break;

            case "EUR":
                outputValue = inputValueInBGN / BGN_TO_EUR;
                System.out.printf("%.2f %s", outputValue, outputCurrency);
                break;

            case "GBP":
                outputValue = inputValueInBGN / BGN_TO_GBP;
                System.out.printf("%.2f %s", outputValue, outputCurrency);
                break;
        }
    }
}

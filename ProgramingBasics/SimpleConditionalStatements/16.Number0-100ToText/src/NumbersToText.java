import java.util.Scanner;

public class NumbersToText {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());
        String posDec = "";
        String posOne = "";
        String posTeen = "";
        String numWord = "";

        if (number == 100) {
            System.out.println("one hundred");
            return;
        }
        else if (number < 0 || number > 100) {
            System.out.println("invalid number");
            return;
        }

        if (number >= 0 || number < 99) {
            int digitDEC = number / 10;
            int digitONE = number % 10;

            //region zero to nine
            switch(digitONE) {
                case 0:
                    posOne = "zero";
                    break;
                case 1:
                    posOne = "one";
                    break;
                case 2:
                    posOne = "two";
                    break;
                case 3:
                    posOne = "three";
                    break;
                case 4:
                    posOne = "four";
                    break;
                case 5:
                    posOne = "five";
                    break;
                case 6:
                    posOne = "six";
                    break;
                case 7:
                    posOne = "seven";
                    break;
                case 8:
                    posOne = "eight";
                    break;
                case 9:
                    posOne = "nine";
                    break;
                default:
                    break;
            }
            //endregion

            //region ten to ninety
            switch(digitDEC) {
                case 1: {
                    switch(number) {
                        case 10:
                            posTeen = "ten";
                            break;
                        case 11:
                            posTeen = "eleven";
                            break;
                        case 12:
                            posTeen = "twelve";
                            break;
                        case 13:
                            posTeen = "thirteen";
                            break;
                        case 14:
                            posTeen = "fourteen";
                            break;
                        case 15:
                            posTeen = "fifteen";
                            break;
                        case 16:
                            posTeen = "sixteen";
                            break;
                        case 17:
                            posTeen = "seventeen";
                            break;
                        case 18:
                            posTeen = "eighteen";
                            break;
                        case 19:
                            posTeen = "nineteen";
                            break;
                        default:
                            break;
                    }
                }
                break;

                case 2:
                    posDec = "twenty";
                    break;
                case 3:
                    posDec = "thirty";
                    break;
                case 4:
                    posDec = "fourty";
                    break;
                case 5:
                    posDec = "fifty";
                    break;
                case 6:
                    posDec = "sixty";
                    break;
                case 7:
                    posDec = "seventy";
                    break;
                case 8:
                    posDec = "eighty";
                    break;
                case 9:
                    posDec = "ninety";
                    break;
                default:
                    break;
            }

            //endregion

            if(number == 0) {
                numWord = posOne;
            }
            else if(digitDEC == 1) {
                numWord = posTeen;
            }
            else if(number > 19) {
                switch(digitONE) {
                    case 0:
                        numWord = posDec;
                        break;
                    default:
                        numWord = posDec + " " + posOne;
                        break;
                }
            }
            else if(digitDEC == 0) {
                numWord = posOne;
            }

            System.out.println(numWord);
        }
    }
}
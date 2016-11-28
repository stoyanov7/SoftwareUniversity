import java.util.Scanner;

public class Main {
    public static void printStar(char c, int n) throws NegativeNumberException {
        if(n < 0)
            throw new NegativeNumberException();

        for (int i = 0; i < n; i++) {
            System.out.print(c + " ");
        }
        System.out.println();
    }

    public static void printFigure(char c, int n)
            throws NegativeNumberException {
        if(n == 0)
            return;

        if(n == 1) {
            System.out.println(c);
            return;
        }

        printStar(c,n);
        printFigure(c, n - 1);
        printStar(c, n);
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        boolean wrongInput = true;

        while(wrongInput) {
            System.out.print("Enter symbol: ");
            char inputSymbol = scanner.next().charAt(0);

            System.out.print("Enter size: ");
            int size = Integer.parseInt(scanner.nextLine());

            try {
                printFigure(inputSymbol, size);
                wrongInput = false;
            }
            catch (NegativeNumberException nne) {
                nne.what();
            }
        }
    }
}

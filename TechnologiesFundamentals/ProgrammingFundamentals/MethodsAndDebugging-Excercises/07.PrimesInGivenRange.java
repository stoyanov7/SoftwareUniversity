import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class PrimesInGivenRange {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int startNumber = Integer.parseInt(scanner.nextLine());
        int endNumber = Integer.parseInt(scanner.nextLine());
        List<Integer> primeList = findPrimesInRange(startNumber, endNumber);

        for (int i = 0; i < primeList.size(); i++) {
            System.out.print(primeList.get(i));
            if (i != primeList.size() - 1) {
                System.out.print(", ");
            }
        }
    }

    private static List<Integer> findPrimesInRange(int startNum, int endNum) {
        List<Integer> primesList = new ArrayList<>();
        for (int i = startNum; i <= endNum; i++) {
            boolean primeCheck = true;

            if (i == 0 || i == 1) {
                primeCheck = false;
            }
            else {
                for (int j = 2; j <= Math.sqrt(i); j++) {
                    if (i % j == 0) {
                        primeCheck = false;
                    }
                }
            }

            if (primeCheck) {
                primesList.add(i);
            }
        }

        return primesList;
    }
}

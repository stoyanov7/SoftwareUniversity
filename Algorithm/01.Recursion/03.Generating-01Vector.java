import java.util.Scanner;

public class Main {
    private static int counter = 0;

    private static void printVector(int[] v) {
        for(int i : v)
            System.out.print(i + " ");
        System.out.println();
    }

    private static void gen01(int[] vector, int index) {
        if (index == -1) {
            printVector(vector);
            return;
        }

        counter++;
        for (int i = 0; i <= 1; i++) {
            vector[index] = i;
            gen01(vector, index - 1);
        }

    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter size for a vector: ");
        int size = Integer.parseInt(scanner.nextLine());
        int[] vector = new int[size];
        gen01(vector, size - 1);
        System.out.println(counter);
    }
}

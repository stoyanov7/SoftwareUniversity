import java.util.Scanner;

public class Main {
   private static void printVector(int[] v) {
       for(int i : v)
           System.out.print(i + " ");
       System.out.println();
   }

   public static void gen01(int[] vector, int index) {
       if (index < 0)
           printVector(vector);

       else {
           for (int i = 0; i <= 1; i++) {
               vector[index] = i;
               gen01(vector, index - 1);
           }
       }
   }

   public static void main(String[] args) {
       Scanner scanner = new Scanner(System.in);
       System.out.print("Enter size for a vector: ");
       int size = Integer.parseInt(scanner.nextInt());
       int[] vector = new int[size];
       gen01(vector, size - 1);
   }
}

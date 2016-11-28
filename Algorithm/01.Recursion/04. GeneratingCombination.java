import java.util.Scanner;

public class Main {
   private static final String ANSI_RED = "\u001B[31m";
   private static final String RESET = "\u001B[0m";

   private static void printVector(int[] arr) {
       System.out.print("{ ");
       for(int i : arr) {
           System.out.print(i + " ");
       }
       System.out.print("}");
       System.out.println();
   }

   private static void genCombs(int[] arr, int index, int startNum, int endNum) {
       if(arr.length == index)
           printVector(arr);

       else {
           for (int i = startNum; i <= endNum; i++) {
               arr[index] = i;
               genCombs(arr, index + 1, i + 1, endNum);
           }
       }
   }

   public static void main(String[] args) throws NegativeArraySizeException {
       Scanner scanner = new Scanner(System.in);
       boolean wrongInput = true;

       while (wrongInput) {
           try {
               System.out.print("Enter size: ");
               int n = Integer.parseInt(scanner.nextLine());
               int[] arr = new int[n];

               System.out.print("Enter start number: ");
               int startNum = Integer.parseInt(scanner.nextLine());

               System.out.print("Enter end number: ");
               int endNum = Integer.parseInt(scanner.nextLine());
               scanner.close();

               genCombs(arr, 0, startNum, endNum);
               wrongInput = false;
           }
           catch (NegativeArraySizeException e) {
               System.out.println(ANSI_RED + "Array cannot be with negative size!" + RESET);
           }
       }
   }
}

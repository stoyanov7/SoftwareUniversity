import java.util.Scanner;

public class Factorial {
   private static long factorial(int num) throws NegativeNumberException {
       if (num < 0)
           throw new NegativeNumberException();
           
       if(num == 0)
           return 1;

       else
           return num * factorial(num - 1);
   }

   public static void main(String[] args) {
       Scanner scanner = new Scanner(System.in);
       boolean wrongInput = true;

       while (wrongInput) {
           System.out.print("Enter n = ");
           int input = Integer.parseInt(scanner.nextLine());
           try {
               long result = factorial(input);
               System.out.print("n! = " + result);
               wrongInput = false;
           } catch (NegativeNumberException nne) {
               nne.what();
           }
       }
   }
}

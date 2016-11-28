public class NegativeNumberException extends Throwable {
   private static final String ANSI_RED = "\u001B[31m";
   private static final String RESET = "\u001B[0m";

   public void what() {
       System.out.println(ANSI_RED + "Cannot use negative number!" + RESET);
   }
}

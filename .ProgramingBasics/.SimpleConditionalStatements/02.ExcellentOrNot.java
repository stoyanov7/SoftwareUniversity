import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double grade = scanner.nextDouble();

        if (grade >= 5.50) 
            System.out.println("Excellent!");
        else
            System.out.println("Not excellent.");
    }
}

public class TriangleOfStars {
    public static void main(String[] args) {
        for (int i=1; i<=10; i++) {
            for (int j=0; j<i; j++) {
                System.out.print("*");
            }
            System.out.println("");
        }
    }
}
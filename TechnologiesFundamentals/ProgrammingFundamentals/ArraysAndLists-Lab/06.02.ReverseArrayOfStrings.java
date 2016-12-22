import java.util.*;

public class ReverseArrayOfStrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<String> stringList = Arrays.asList(scanner.nextLine().split(" "));
        Collections.reverse(stringList);
        stringList.forEach(e -> System.out.print(e + " "));
    }
}

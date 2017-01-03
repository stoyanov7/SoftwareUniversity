import java.util.*;

public class RemoveNegativesAndReverse {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        List<Integer> integerList = new ArrayList<>();

        for (String anInput : input) {
            integerList.add(Integer.parseInt(anInput));
        }

        List<Integer> result = new ArrayList<>();

        for (Integer anIntegerList : integerList) {
            if (anIntegerList >= 0) {
                result.add(anIntegerList);
            }
        }

        Collections.reverse(result);

        if (result.size() == 0) {
            System.out.println("empty");
        }
        else {
            result.forEach(e -> System.out.print(e + " "));
        }
    }
}

import java.time.Duration;
import java.time.LocalTime;

public class FactorialPerformance {
    public static void main(String[] args) {
        //region Recursive Factorial
        LocalTime startTime = LocalTime.now();
        for (int i = 0; i < 1_000_000; i++) {
            long f = recursiveFactorial(15);
        }
        LocalTime endTime = LocalTime.now();
        long elapsedMinutes = Duration.between(startTime, endTime).toMillis();
        System.out.println("Recursive factorial time: " + elapsedMinutes);
        //endregion

        //region Iteractive Factorial
        LocalTime startTimeI = LocalTime.now();
        for (int i = 0; i < 1_000_000; i++) {
            long f = iteractiveFactorial(15);
        }
        LocalTime endTimeI = LocalTime.now();
        long elapsedMinutesI = Duration.between(startTimeI, endTimeI).toMillis();
        System.out.println("Iteractive factorial time: " + elapsedMinutesI);
        //endregion
    }

    private static long recursiveFactorial(int num)  {
        if(num == 0)
            return 1;

        else
            return num * recursiveFactorial(num - 1);
    }

    private static long iteractiveFactorial(int num) {
        long result = 1;
        for (int i = 1; i <= num; i++) {
            result *= i;
        }

        return result;
    }
}

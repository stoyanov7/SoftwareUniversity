import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;
import java.util.TreeSet;

class Employee implements Comparable<Employee> {
    private String name;
    private double salary;
    private String position;
    private String department;
    private String email;
    private int age;

    public Employee(String name, double salary, String position, String department, String email, int age) {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }

    public Employee(String name, double salary, String position, String department) {
        this(name, salary, position, department, "n/a", -1);
    }

    public Employee(String name, double salary, String position, String department, String email) {
        this(name, salary, position, department, email, -1);
    }

    public Employee(String name, double salary, String position, String department, int age) {
        this(name, salary, position, department, "n/a", age);
    }

    @Override
    public String toString() {
        return String.format("%s %.2f %s %d", this.name, this.salary, this.email, this.age);
    }

    @Override
    public int compareTo(Employee employee) {
        return Double.compare(employee.salary, this.salary);
    }
}

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        HashMap<String, Double> departmentsWithSalary = new HashMap<>();
        HashMap<String, TreeSet<Employee>> departmentsWithEmployees = new HashMap<>();
        Employee employee;

        int n = Integer.parseInt(reader.readLine());

        for (int i = 0; i < n; i++) {
            String[] input = reader.readLine().split("\\s+");
            String name = input[0];
            double salary = Double.parseDouble(input[1]);
            String position = input[2];
            String department = input[3];

            if (input.length == 4) {
                employee = new Employee(name, salary, position, department);
            }
            else if (input.length == 5) {
                if (isNumber(input[4])) {
                    int age = Integer.parseInt(input[4]);
                    employee = new Employee(name, salary, position, department, age);
                }
                else {
                    String email = input[4];
                    employee = new Employee(name, salary, position, department, email);
                }
            }
            else {
                String email = input[4];
                int age = Integer.parseInt(input[5]);
                employee = new Employee(name, salary, position, department, email, age);
            }

            if (!departmentsWithEmployees.containsKey(department)) {
                departmentsWithEmployees.put(department, new TreeSet<>());
                departmentsWithSalary.put(department, 0.0);
            }

            departmentsWithEmployees.get(department).add(employee);
            departmentsWithSalary.put(department, departmentsWithSalary.get(department) + salary);
        }

        Map.Entry<String, TreeSet<Employee>> best =
            departmentsWithEmployees.entrySet().stream().sorted((e1, e2) ->
                Double.compare(departmentsWithSalary.get(e2.getKey()),
                departmentsWithSalary.get(e1.getKey()))).findFirst().get();

        System.out.printf("Highest Average Salary: %s%n", best.getKey());
        for (Employee employee1 : best.getValue()) {
            System.out.println(employee1);
        }
    }

    private static boolean isNumber(String input) {
        try {
            Integer.parseInt(input);
            return true;
        }
        catch (NumberFormatException nfe) {
            return false;
        }
    }
}

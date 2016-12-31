import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedList;

class Car {
    private String model;
    private Engine engine;
    private String weight;
    private String color;

    public Car(String model, Engine engine, String weight, String color) {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    public Car(String model, Engine engine) {
        this(model,engine,"n/a","n/a");
        this.model = model;
        this.engine = engine;
    }

    public String getModel() {
        return this.model;
    }

    public Engine getEngine() {
        return this.engine;
    }

    public String getWeight() {
        return this.weight;
    }

    public String getColor() {
        return this.color;
    }

    @Override
    public String toString() {
        Engine eng = this.getEngine();
        return String.format("%s:%n  %s:%n    Power: %s%n    Displacement: %s%n    Efficiency: %s%n  Weight: %s%n  Color: %s",
                this.getModel(), eng.getModel(), eng.getPower(), eng.getDisplacement(),
                eng.getEfficiency(), this.getWeight(), this.getColor());
    }
}

class Engine {
    private String model;
    private int power;
    private String displacement;
    private String efficiency;

    public Engine(String model, int power, String displacement, String efficiency) {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public Engine(String model, int power) {
        this(model,power,"n/a","n/a");
        this.model = model;
        this.power = power;
    }

    public String getModel() {
        return this.model;
    }

    public int getPower() {
        return this.power;
    }

    public String getDisplacement() {
        return this.displacement;
    }

    public String getEfficiency() {
        return this.efficiency;
    }
}

public class CarSalesman {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        Engine engine = null;
        Car car = null;
        LinkedList<Engine>engines = new LinkedList<>();
        LinkedList<Car>cars = new LinkedList<>();

        int n = Integer.parseInt(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] inputEngine = reader.readLine().split("\\s+");
            String model = inputEngine[0];
            int power = Integer.parseInt(inputEngine[1]);

            if (inputEngine.length == 4) {
                String displacement = inputEngine[2];
                String efficiency = inputEngine[3];
                engine = new Engine(model,power,displacement,efficiency);
            }
            else if(inputEngine.length == 3) {
                if (isNumber(inputEngine[2])) {
                    engine = new Engine(model,power,inputEngine[2],"n/a");
                }
                else {
                    engine = new Engine(model,power,"n/a",inputEngine[2]);
                }
            }else{
                engine = new Engine(model,power);
            }
            engines.add(engine);
        }

        int m = Integer.parseInt(reader.readLine());
        for (int i = 0; i < m; i++) {
            String[]carsInput = reader.readLine().split("\\s+");
            String model = carsInput[0];
            String engineName = carsInput[1];

            for (Engine engine1 : engines) {
                if (engine1.getModel().equals(engineName)){
                    engine=engine1;
                    break;
                }
            }
            if (carsInput.length == 4) {
                String weight = carsInput[2];
                String color = carsInput[3];
                car = new Car(model,engine,weight,color);
            }
            else if(carsInput.length == 3) {
                if (isNumber(carsInput[2])){
                    String weight = carsInput[2];
                    car = new Car(model,engine,weight,"n/a");
                }
                else {
                    String color = carsInput[2];
                    car = new Car(model,engine,"n/a",color);
                }
            }
            else {
                car = new Car(model,engine);
            }
            cars.add(car);
        }

        cars.forEach(c -> System.out.println(c.toString()));
    }

    private static boolean isNumber(String s) {
        try{
            Integer.parseInt(s);
            return true;
        }
        catch (NumberFormatException nfe) {
            return false;
        }
    }
}

function solve(name, age, weight, height) {
     let person = {
          name: name,
          personalInfo: {
               age: age,
               weight: weight,
               height: height,
          },
          BMI: Math.round(weight / Math.pow(height / 100, 2))
     };

     person['status'] = (() => {
          if (person.BMI < 18.5) {
               return 'underweight';
          }

          if (person.BMI < 25) {
               return 'normal';
          }

          if (person.BMI < 30) {
               return 'overweight';
          }

          if (person.BMI >= 30) {
               return 'obese';
          }
     })();

     if (person.status === 'obese') {
          person['recommendation'] = 'admission required';
     }

     return person;
}
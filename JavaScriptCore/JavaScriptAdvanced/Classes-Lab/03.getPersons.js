function getPersons() {
     class Person {
          constructor(firstName, lastName, age, email) {
               this._firstName = firstName;
               this._lastName = lastName;
               this._age = age;
               this._email = email;
          }

          toString() {
               return `${this._firstName} ${this._lastName} (age: ${this._age}, email: ${this._email})`;
          }
     }

     return [
          new Person('Maria', 'Petrova', 22, 'mp@yahoo.com'),
          new Person('SoftUni'),
          new Person('Stephan', 'Nikolov', 25),
          new Person('Peter', 'Kolev', 24, 'ptr@gmail.com')
     ];
}
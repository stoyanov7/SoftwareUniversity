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
const { v4 } = require('uuid');
const fs = require('fs');
const path = require('path');

const databaseFile = path.join(__dirname, "..", "config/database.json");

class Cube {
   constructor(name, description, imageUr, difficulty) {
      this.id = v4();
      this.name = name || "No name";
      this.description = description;
      this.imageUr = imageUr || "placeholder";
      this.difficulty = difficulty || 0;
   }

   save() {
      const newCube = {
         id: this.id,
         name: this.name,
         description: this.description,
         imageUr: this.imageUr,
         difficulty: this.difficulty
      };

      fs.readFile(databaseFile, (err, data) => {
         if (err) {
            console.log(err);
            return;
         }

         const db = JSON.parse(data);
         db.push(newCube);

         fs.writeFile(databaseFile, JSON.stringify(db), (err) => {
            if (err) {
               console.log(err);
               return;
            }

            console.log("new cube is successfully stored to database!");
         });
      });     
   }
}

module.exports = Cube;
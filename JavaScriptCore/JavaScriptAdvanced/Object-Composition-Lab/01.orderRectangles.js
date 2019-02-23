function solve(args) {
     let rectangles = [];

     for (let tokens of args) {
         let rectangle = {
             width: +tokens[0],
             height: +tokens[1],
             area: function () {
                 return this.width * this.height;
             },
             compareTo: function (otherRectangle) {
                 if(this.area() === otherRectangle.area()){
                     return otherRectangle.width - this.width;
                 }
 
                 return otherRectangle.area() - this.area();
             }
         };
 
         rectangles.push(rectangle);
     }
 
     let sortedRectangles = rectangles.sort((a,b) => a.compareTo(b));
     return sortedRectangles;
 }
 
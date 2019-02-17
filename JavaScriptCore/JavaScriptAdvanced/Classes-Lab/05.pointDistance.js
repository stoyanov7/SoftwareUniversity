class Point {
     constructor(x, y) {
          this.x = x;
          this.y = y;
     }

     static distance(firstPoint, secondPoint) {
          let result = Math.sqrt(((secondPoint.x - firstPoint.x) * (secondPoint.x - firstPoint.x)) +
               ((secondPoint.y - firstPoint.y) * (secondPoint.y - firstPoint.y)));

          return result;
     }
}
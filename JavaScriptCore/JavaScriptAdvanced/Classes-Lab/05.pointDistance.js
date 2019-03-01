class Point {
     constructor(x, y) {
          this._x = x;
          this._y = y;
     }

     static distance(firstPoint, secondPoint) {
          let result = Math.sqrt(((secondPoint.x - firstPoint.x) * (secondPoint.x - firstPoint.x)) +
               ((secondPoint.y - firstPoint.y) * (secondPoint.y - firstPoint.y)));

          return result;
     }
}
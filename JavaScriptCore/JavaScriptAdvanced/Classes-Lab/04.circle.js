class Circle {
     constructor(raduis) {
          this._radius = raduis;
     }

     set diameter(diameter) {
          this._radius = diameter / 2;
     }

     get diameter() {
          return this._radius * 2;
     }

     get area() {
          return Math.PI * this._radius * this._radius;
     }
}
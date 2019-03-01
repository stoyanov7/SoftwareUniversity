class Rectngle {
     constructor(width, height, color) {
          this._width = width;
          this._height = height;
          this._color = color;
     }

     calcArea() {
          let area = this._width * this._height;
          return area;
     }
}
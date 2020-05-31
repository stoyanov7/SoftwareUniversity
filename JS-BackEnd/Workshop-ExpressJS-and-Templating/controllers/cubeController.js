const Cube = require('../models/cube');

const newCube = new Cube("First", "First cube", "https://google.com", 1);

newCube.save();
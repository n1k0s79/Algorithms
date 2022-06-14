import { isPalindrome } from "./palindrome.js";
import { getMaxProduct } from "./adjacentElementsProduct.js";
import { getShapeArea, getShapeArea2 } from "./shapeArea.js";
import { consecutive } from "./consecutive.js";
import { strictlyIncreasing } from "./strictlyIncreasing.js";
import { getMatrixElementsSum } from "./matrixElementsSum.js";

for(var i =1; i < 15; i++) {
    var a = getShapeArea(i);
    var b = getShapeArea2(i);
    var c = 1 + (i -1) * 4
    if (a != b || a != c) {
        var j = 1;
    }
}
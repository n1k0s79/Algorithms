export function getMaxProduct(inputArray) {
    var max = -Number.MAX_VALUE;
    for (var i = 0; i < inputArray.length - 1; i++) 
    {
        var prod = inputArray[i] * inputArray[i + 1];
        if (prod > max) max = prod;
    }
    return max;
}
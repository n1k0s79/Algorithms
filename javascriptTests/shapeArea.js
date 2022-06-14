export function getShapeArea(n) {
    return n * n + (n-1) * (n-1);
}

var result = getShapeArea2(4);

export function getShapeArea2(n){
    var top = n * 2 - 1;
    var total = 0;
    var current = top;
    for (var i = n - 1; i > 0; i--) {
        current = current -2;
        if (i !== 1) {
            total = total + current;
        } else total = total + 1;
    }

    total = total * 2 + top
    return total;
}
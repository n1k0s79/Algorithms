export function getMatrixElementsSum(matrix) {
    const rows = matrix.length;
    const columns = matrix[0].length;
    var sum = 0;
    for (var column = 0; column < columns; column++) {
        for (var row = 0; row < rows; row++) {        
            const a = matrix[row][column];
            if (a == 0) break;
            sum += a;
        }
    }
    return sum;
}

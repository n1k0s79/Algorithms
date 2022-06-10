export function consecutive(statues) {
    var max = getMax(statues);
    var min = getMin(statues);
    var expectedCount = max - min + 1;
    var missingCount = expectedCount - statues.length;  
    return missingCount;
  }
  
  function getMax(a) {
      var max = -Number.MAX_VALUE;
      for(var i = 0; i < a.length; i++) {
          if (a[i]> max) max = a[i];
      }
      return max;
  }
  
  function getMin(a) {
      var min = Number.MAX_VALUE;
      for(var i = 0; i < a.length -1; i++) {
          if (a[i]< min) min = a[i];
      }
      return min;
  }
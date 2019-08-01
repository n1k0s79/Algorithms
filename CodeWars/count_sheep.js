// Task:
// Given a non-negative integer, 3 for example, return a string with a murmur: "1 sheep...2 sheep...3 sheep...". Input will always be valid, i.e. no negative integers.

var countSheep = function (num){
    var ret = '';
    for(i = 1; i <= num; i++) {
      ret += i + ' sheep...';
    }
    return ret;
  }

  countSheep(3);
export function isPalindrome(inputString) {
    var reversed = "";
    for (var i = inputString.length -1; i >=0; i --) 
    {
        reversed += inputString[i];
    }
    return inputString == reversed;
}
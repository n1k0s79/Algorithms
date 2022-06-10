export function strictlyIncreasing(sequence) {
    var diff = getDiff(sequence);
    var indexes = getNegativeIndexes(diff);
    if (indexes.length == 0) return true;
    for (var i = 0; i < indexes.length; i++) {
        var removed = getRemoved(sequence, indexes[i]);
        var newDiff = getDiff(removed);
        var newNegative = getNegativeIndexes(newDiff);        
        if (newNegative.length == 0) return true;
    }
    return false;
}

function getRemoved(sequence, indexToRemove) {
    var newArray = [];
    for(var i = 0; i < sequence.length; i ++) {
        if (i != indexToRemove) newArray.push(sequence[i]);        
    }
    return newArray;
}

function getDiff(sequence) {
    var diff = [];
    for(var i = 1; i < sequence.length; i++) {
        diff.push(sequence[i] - sequence[i-1]);
    }
    return diff;
}

function getNegativeIndexes(diff) {
    var indexes = [];
    for(var i = 0; i < diff.length; i++) {
        if (diff[i] < 1) {
            indexes.push(i);
            indexes.push(i + 1); // μόλις έβαλα αυτή τη γραμμή πέρασαν όλα τα τεστ
                                 // χωρίς αυτή πέρναγαν 16/19
        }
    }
    return indexes;
}

/*
Αυτό με δυσκόλεψε
Δεν ήθελα να κάνω brute force
Στην αρχή ξεκίνησα να παίρνω τα στοιχεία ανά τρια αλλά δεν έβρισκα συνθήκες που να με οδηγήσουν στη λύση
μετά έφτιαξα τον πίνακα diff
ο οποίος έχει μέγεθος ν-1
κάθε στοιχείο του δείχνει τη διαφορά με τον προηγούμενο αριθμό
αν ένα στοιχείο είναι αρνητικό τότε σημαίνει ότι στον αρχικό πίνακα τα στοιχεία μικραίνουν αντί να μεγαλώνουν
το στοιχείο που μικραίνει είναι υποψήφιο να φύγει
ο αλγόριθμος δούλευε για τα 16 από τα 19 τεστ
η προσθήκη της γραμμής 35 τον έκανε να δουλέψει για όλα
*/
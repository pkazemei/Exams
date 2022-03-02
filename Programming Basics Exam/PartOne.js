//1 print1to255()
//Print all the integers from 1 to 255

//Using for loop within a function
function print1To255() {
    for (var i = 1; i <= 255; i++) {
        console.log(i);
    }
}

print1To255();


//2 printOdds1To255()
//Print all odd integers from 1 to 255

//Using modulo operator
function printOdds1To255() {
    for (var i = 1; i <= 255; i++) {
        if (i % 2 == 1) {
            console.log(i)
        }
    }
}
printOdds1To255();


//3 printIntsAndSum0To255
//Print integers from 0 to 255, with the sum of each integer

//Using sum to add integers together
function printIntsAndSum0To255() {
    var sum = 0;
    for (var i = 0; i <= 255; i++) {
        sum += i;
        console.log(i, sum);
    }
}
printIntsAndSum0To255();


//4 printArrayVals(arr)
//Iterate through a given array, printing each value

//Using console.log(i)
function printArrayVals(arr) {
    for (var i = 0; i <= arr.length; i++) {
        console.log(arr[i]);
    }
}
printArrayVals([1, 2, 3, 4, 5, 7]);


//5 printMaxOfArray(arr)
//Given an array, find and print its largest element
//arr[i] means current value in the array

//Find and print max
function printMaxOfArray(arr) {
    var max = arr[0];
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] > max) {
            max = arr[i];
        }
    }
    console.log(max);
    return max;
}
printMaxOfArray([0, 1, 2, 10, 4, 5, 6]);


//6 printAverageOfArray(arr)
//Analyze an array's values and print the average

//Print average using avg / arr.length
function printAverageOfArray(arr) {
    var avg = 0;
    for (var i = 0; i < arr.length; i++) {
        avg += arr[i] / arr.length;
    }
    console.log(avg);
    return avg;
}

printAverageOfArray([1, 2, 3, 4]);


//7 returnOddsArray1To255()
//Create an array with all the odd integers between 1 and 255

//Using the push function
function returnOddsArray1To255(arr) {
    var arr = [];
    for (var i = 1; i <= 255; i++) {
        if (i % 2 == 1) {
            arr.push(i);
        }
    }
    return arr;
}
odds = returnOddsArray1To255();
console.log(odds);


//8 squareArrayVals(arr)
//Square each value in a given array, returning that same array with changed values

//Multiplying arr[i] by itself
function squareArrayVals(arr) {
    for (var i = 0; i < arr.length; i++) {
        arr[i] *= arr[i];
    }
    return arr;
}

ans = squareArrayVals([2, 4, 6, 8, 10]);
console.log(ans);


//10 zeroOutArrayNegativeVals(arr)
//Return the given array, after setting any negative values to zero

//Using if conditional to swap negative values with zero
function zeroOutNegativeValues(arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] < 0) {
            arr[i] = 0;
        }
    }
    return arr;
}
console.log(zeroOutNegativeValues([-3, -2, -1, 1, 2, 3]));


//13 swapStringForArrayNegativeVals(arr)
//Given an array of numbers, replace any negative values with the string 'Dojo'.

//Using if conditional to swap negative values with the word Dojo
function swapStringForArrayNegativeVals(arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] < 0) {
            arr[i] = "Dojo";
        }
    }
    return arr;
}
console.log(swapStringForArrayNegativeVals([-1, 3, -2, 6, -3]));
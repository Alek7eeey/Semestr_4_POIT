//ex1
function createrNumber(numberArr: number[]) : string 
{
    if(numberArr.length != 10)
    {
        return "Error";
    }
 var phoneNumber;
 phoneNumber = String('(' + numberArr[0] + numberArr[1] + numberArr[2] + ") " + numberArr[3] + numberArr[4] + numberArr[5] + '-' + numberArr[6] + numberArr[7] + numberArr[8] + numberArr[9]); 
 return phoneNumber;
}

let num_arr: number[] = [4,4,8,9,4,6,3,1,6,7];

console.log("phone number: " + createrNumber(num_arr));

//ex2
class Challenge
{
    static solution(number:number) : number
    {
        if(number < 0)
        {
            return 0;
        }

        else
        {
           let sum:number = 0;

            for(let i = 1; i<number; i++)
            {
                    if(i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}

console.log("sum /5 and /3: "+ Challenge.solution(10));

//ex3
function swapArr(arr:number[], k:number) :number[] | null
{
    if(k==0)
    {
        return arr;
    }

    if(arr.length == 0)
    {
        return null;    
    }

    let newArr:number[] = [];
    for(let i = 0; i<k; i++)
    {
        newArr[i] = arr[arr.length-(k-i)];
    }

    for(let i = 0; i<arr.length - k; i++)
    {
        newArr[k+i] = arr[i];
    }

    return newArr;
}

console.log("swap array: " + swapArr([1,2,3,4,5,6,7], 3));

//ex4
function GetMedian(arrnum1:number[], arrnum2:number[]) : number | null
{
    if(arrnum1.length == 0 && arrnum2.length == 0)
    {
        return null;
    }

    let concatTwoArr: number[] = [];
    for(let i = 0; i < arrnum1.length; i++)
    {
        concatTwoArr[i] = arrnum1[i];
    }

    let j: number = 0;
    for(let i = arrnum1.length; i < arrnum1.length + arrnum2.length; i++, j++)
    {
        concatTwoArr[i] = arrnum2[j];
    }
    //можно arrnum1.concat(arrnum2).sort

    concatTwoArr.sort();
    if(concatTwoArr.length % 2 == 0)
    {
        return (concatTwoArr[(concatTwoArr.length / 2)-1] + concatTwoArr[concatTwoArr.length / 2])/2;
    }

    else
    {
        return concatTwoArr[Math.floor(concatTwoArr.length / 2)];
    }
}

console.log("Median of array: " + GetMedian([1,3], [2,7,8]));

//ex5
function sudoku(matrix:number[][]) : string
{
    for(let i = 0; i < 9; i++)
    {
        for(let j = 0; j < 9; j++)
        {
            if(matrix[i][j] > 9 || matrix[i][j] < -1 || matrix[i][j] == 0)
            {
                return "Enter values out of range";
            }
        }
    }

    for(let i = 0; i<9; i++)
    {
        if(!RowChecking(matrix, i) || !ColChecking(matrix, i))
        {
            return "Incorrect board!";
        }
    }

    return "Correct board!";
}

function RowChecking(matrix:number[][], k: number) : boolean
{
    let set = new Set<number>();

    for(let i = 0; i < 9; i++)
    {
        if(matrix[k][i] == null)
        {
            continue;
        }

        if(set.has(matrix[k][i]))
        {
            return false;
        }

        set.add(matrix[k][i]);
    }
    return true;
}

function ColChecking(matrix:number[][], k:number) : boolean
{
    let set = new Set<number>();

    for(let i = 0; i < 9; i++)
    {
        if(matrix[i][k] == null)
        {
            continue;
        }

        if(set.has(matrix[i][k]))
        {
            return false;
        }

        set.add(matrix[i][k]);
    }
    return true;
}

let sud: number[][] = [
    [5,6,4, 1,3,2, 7,9,8],
    [1,9,7, 8,6,4, 5,3,2],
    [2,3,8, 5,7,9, 4,6,1],

    [8,2,1, 9,4,7, 3,5,6],
    [3,7,9, 6,5,8, 2,1,4],
    [6,4,5, 2,1,3, 8,7,9],

    [4,5,2, 7,9,6, 1,8,3],
    [7,8,6, 3,2,1, 9,4,5],
    [9,1,3, 4,8,5, 6,2,7],
]

console.log(sudoku(sud));
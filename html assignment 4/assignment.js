//problem 1
let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
}

let sum = 0;
for(const salary in salaries){
    sum += salaries[salary]
}

//console.log(sum)

//problem 2
let menu = {
    width: 200,
    height: 300,
    title: "My menu"
}

multiplyNumeric(menu);

//console.log(menu);

function multiplyNumeric(obj){
    for(const item in obj){
        if(typeof obj[item] == 'number')
            obj[item] *= 2;
    }
}

//problem 3
let emails = ['dude@email.com', 'dude@email', 'dude.com','dude.com@email', 'dude'];


function checkEmailid(str){
    let pattern = /[a-z0-9]+@[a-z]+\.[a-z]{2,3}/;
    return pattern.test(str);
}

/*
for (const email of emails) {
    console.log(email + " : " + checkEmailid(email))
}
*/

//problem 4
let word1 = "What I'd like to tell on this topic is:";
let word2 = "Hi everyone!"

function truncate(str, maxlength) {
  if (str.length > maxlength) 
    return str.substring(0, maxlength-1) + "...";
    
    return str;
}

//console.log(truncate(word1, 20));
//console.log(truncate(word2, 20));

//problem 5
let arr = ["James", "Brennie"]
console.log(arr)

arr.push("Robert")
console.log(arr)

arr[Math.round(arr.length / 2)-1] = "Calvin"
console.log(arr)

console.log("Removed " + arr.splice(0,1))
console.log(arr)

arr = ["Rose","Regal"].concat(arr)
console.log(arr)

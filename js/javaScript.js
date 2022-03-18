//#region 12h format to 24h format
function formatTime(input) {
    const [time, modifier] = input.split(' ');
  
    let [hours, minutes, seconds] = time.split(':');
  
    if (hours === '12') {
      hours = '00';
    }
  
    if (modifier === 'PM') {
      hours = parseInt(hours, 10) + 12;
    }
  
    const result = `${hours}:${minutes}:${seconds}`;

    return result;
};

console.log(formatTime("06:15:30 PM"));
//#endregion

//#region get ratio
function getRatio(numbers) {

    const len = numbers.length;

    let positiveCount = 0;
    let negativeCount = 0;
    let zeroCount = 0;
 
    for(let i = 0; i < len; i++)
    {
        if (numbers[i] > 0)
        {
            positiveCount++;
        }
        else if (numbers[i] < 0)
        {
            negativeCount++;
        }
        else if (numbers[i] == 0)
        {
            zeroCount++;
        }
    }

    const result = [(positiveCount / len).toFixed(6), (negativeCount / len).toFixed(6), (zeroCount / len).toFixed(6)]

    return result;
};

console.log(getRatio([1, 1, 0, -1, -1]));
//#endregion

//#region order people
function reorder(people) {

    let list = [];

    for(let i = 0; i < people.length; i++) {

        var name = people[i].name;
        var scores = [];

        for(let j = 0; j < people[i].scores.length; j++) {
            let score = people[i].scores[j];
            let newScore = parseInt(score) || 0;
            scores.push(newScore);
        };

        let person = { name: name, scores: scores }
        list.push(person);
    }

    var result = list.sort(scores_and_names);

    return result;
};

function scores_and_names( a, b )
{
  if ( a.scores < b.scores){
    return 1;
  }
  else if ( a.scores > b.scores){
    return -1;
  }
  
  if ( a.name.toLowerCase() < b.name.toLowerCase()){
    return -1;
  }
  else if ( a.name.toLowerCase() > b.name.toLowerCase()){
    return 1;
  }

  return 0;
}

const people = 
[
	{ name: 'Bob', scores: [1, 2, 1] },
	{ name: 'Alice', scores: [3, 2, 3] },
    { name: 'George', scores: [4, 5, 3] },
    { name: 'Julianna', scores: [6, 5, 6] },
    { name: 'Andrew', scores: [2, 6, 5] },
    { name: 'Fancy', scores: [4, 4, 3] },
    { name: 'Ancy', scores: [4, 4, 3] },
    { name: 'Joe', scores: [1, 2, "4.1"] },
	{ name: 'Jane', scores: [1, null, 3] },

]

let res = reorder(people);

res.forEach(x => console.log('name: ' + x.name + ' scores: ' + x.scores));
//#endregion


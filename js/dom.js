// Your task is to create a utility function that allows us to execute another function after a given delay, but fails randomly about 50% of the time.

function delay(cb, delayTime) {
    setTimeout(function() {

        // Gets a random boolean value (50%)
        const result = Math.random() < 0.5;

        cb(result);

    }, delayTime);
}

function callBack(err) {
    if (err) {
            console.log('Whoops! Something went wrong');
    } else {
            console.log('🎉');
    }
}

/* Logic for calling function repeatedly

let interval = setInterval(callDelay, 1000);

function callDelay() {
    delay(callBack, 1000);
}

*/
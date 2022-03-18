// Your second task is to create the same utility function which uses promises instead of a callback.

function delay(delayTime) {

    let p = new Promise(function (resolve, reject) {
        setTimeout(function () {
            const result = Math.random() < 0.5;

            if (result) {
                resolve();
            }
            else {
                reject();
            }

        }, delayTime)
    });

    return p;
}


const prom = delay(1000);

prom.then(() => {
    console.log('🎉');
})
    .catch(() => {
        console.log('Whoops! Something went wrong');
    });

    
/* Logic for calling function repeatedly

let interval = setInterval(callDelay, 1000);

function callDelay() {
    const prom = delay(1000);

    prom.then(() => {
        console.log('🎉');
    })
        .catch(() => {
            console.log('Whoops! Something went wrong');
        });
}

*/


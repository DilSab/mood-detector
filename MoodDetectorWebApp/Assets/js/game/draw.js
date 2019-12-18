const canvas = document.querySelector(".canvas");
const ctx = canvas.getContext("2d");

var maxEnemies = 100;
var enemy_interval = 30;
var hero;
var enemiesInQ = [];
var enemiesOnStage = [];

var score = 0;
var cnt = 0;
var interval;

function setup() {
    hero = new Hero();    
    interval = setInterval(update, 1000 / 60);
}
function update(){
    ctx.clearRect(0, 0, canvas.width, canvas.height);


    if (enemiesOnStage.length < maxEnemies && cnt == enemy_interval) {
        if (enemiesInQ.length == 0) {
            enemiesInQ.push(new Enemy());
        }
        enemiesInQ[0].reset();
        enemiesOnStage.push(enemiesInQ[0]);
        enemiesInQ.shift();
    }
    for (i = 0; i < enemiesOnStage.length; i++) {
        let ret = enemiesOnStage[i].update(hero.x, hero.y, hero.radius);
        if (ret == 0) {
            enemiesOnStage[i].draw();
            continue;
        }
        console.log(enemiesOnStage[i].radius);
        if (ret == 2) {
            hero.increaseRadius(enemiesOnStage[i].radius);
        }
        enemiesInQ.push(enemiesOnStage[i]);
        enemiesOnStage.splice(i, 1);
        i--;
    }

    hero.setSpeed(rightVal - leftVal);
    hero.update();
    hero.draw();

    if (cnt++ == enemy_interval) {
        score++;
        document.getElementById('score').innerHTML = '<b>Score: </b>' + score;
        cnt = 0;
    }

}
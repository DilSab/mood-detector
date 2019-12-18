function Hero() {
    this.radius = canvas.width / 9;
    this.x = canvas.width / 2 ;
    this.y = canvas.height - this.radius - canvas.width / 20;
    this.xSpeed = 0;

    this.draw = function () {
        ctx.fillStyle = "#FF0000";
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.radius, 0, 2 * Math.PI, false);
        ctx.fill();
    }
    this.update = function () {
        this.x += this.xSpeed;
        if (this.x > canvas.width-this.radius) {
            this.x = canvas.width - this.radius;
        }
        if (this.x < this.radius) {
            this.x = this.radius;
        }
        if (this.y > canvas.height - this.radius) {
            this.y = canvas.height - this.radius;
        }
        
    }
    this.increaseRadius = function (enemyRadius) {
        let area = this.radius * this.radius;
        area += enemyRadius * enemyRadius;
        this.radius = Math.sqrt(area);
        if (this.radius >= canvas.width / 2) {
            clearInterval(interval);
        }
    }
    this.setSpeed = function (dx) {
        this.xSpeed = dx;
    }

}
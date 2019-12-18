function Enemy() {
    this.reset = function () {
        this.radius = (canvas.width / 15 - 20) * Math.random() + 20;
        this.x = (canvas.width - this.radius * 2) * Math.random() + this.radius;
        this.y = -this.radius;
        this.xSpeed = 0;
        this.ySpeed = 2;
    }

    this.draw = function () {
        ctx.fillStyle = "#00FF00";
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.radius, 0, 2 * Math.PI, false);
        ctx.fill();
    }
    this.update = function (heroX, heroY, heroRadius) {
        this.x += this.xSpeed;
        this.y += this.ySpeed;
        let ret = 0;
        if (this.x > canvas.width + this.radius ||
            this.x < -this.radius ||
            this.y > canvas.height + this.radius) {
            ret = 1;
        }
        let dist = (this.y - heroY) * (this.y - heroY);
        dist += (this.x - heroX) * (this.x - heroX);
        dist = Math.sqrt(dist);
        if (dist < heroRadius - this.radius) {
            ret = 2;
        }

        return ret;
    }

}
let facevideo_node = document.getElementById("facevideo-node");
//Construct a CameraDetector and specify the image width / height and face detector mode.
var detector = new affdex.CameraDetector(facevideo_node);

//Enable detection of all Expressions, Emotions and Emojis classifiers.
detector.detectAllEmotions();

detector.start();
var leftVal = 0;
var rightVal = 0;
var init = false;

detector.addEventListener("onInitializeSuccess", function () {
    console.log('The detector reports initialized');
    setup();
    init = true;
});

detector.addEventListener("onImageResultsSuccess", function (faces, image, timestamp) {
    if (faces.length > 0) {
        leftVal = (faces[0].emotions["anger"]+ faces[0].emotions["disgust"] - faces[0].emotions["valence"]) / 50;
        rightVal = (faces[0].emotions["joy"] / 2 + faces[0].emotions["valence"]) / 40;
        leftVal *= faces[0].emotions["engagement"] / 100;
        rightVal *= faces[0].emotions["engagement"] / 100;
        console.log(JSON.stringify(faces[0].emotions, function (key, val) {
            return val.toFixed ? Number(val.toFixed(0)) : val;
        }));
    }
    else {
        leftVal = 0;
        rightVal = 0;
    }

});
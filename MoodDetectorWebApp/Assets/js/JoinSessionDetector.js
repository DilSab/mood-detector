// https://github.com/wbkd/d3-extended
d3.selection.prototype.moveToFront = function () {
    return this.each(function () {
        this.parentNode.appendChild(this);
    });
};

let joinSessionDetector = null;
$(document).ready(() => {
    joinSessionDetector = new JoinSessionDetector();
    joinSessionDetector.start();
});


function JoinSessionDetector() {
    const self = this;  
        
    this.States = {
        LOADING: "LOADING",
        SEARCHING: "SEARCHING",
        RECORDING: "RECORDING",
      
    };

    let state = self.States.LOADING; 
    
    let initial_videos = [];   
  
    let video_resumed = false;

    let time_buffering_ms = 0;
    let frames_since_last_face = 0;
    const face_alert_threshold = 20;
    const alert_transition_delay_in = 300;
    const alert_transition_delay_out = 175;
    let face_visible = true;
    let detector = null;
   
    let API_KEY = "AIzaSyCju791bC9hkCE8thtQZB25LePTpvBCoWc";

    let player = AsyncPlayer();
    let graph = new Graph("#svg-curve");
    let video_ids = [video];

/*  ==============================================================
  *  ============================================================== */

    this.state = () => state;
   
    this.start = () => {
        return Promise
            .all([loadYTPlayer(), loadDetector(), loadExamples(video_ids)])
            .then(() => {
                transitionToSearching();
            })
            .catch((message) => {
                showMessage(message);
            });
    };

    this.createAlert = () => {
        $("#lightbox").fadeIn(alert_transition_delay_in);      
    };

/*  ==============================================================
 *  ============================================================== */

    const loadYTPlayer = () => {
        return new Promise((resolve, reject) => {
            player("load", null, (message, data) => {
                if (message === "loaded") {
                    resolve();
                } else {
                    reject(message);
                }
            });
        });
    };    

    const loadDetector = () => {
        return new Promise((resolve, reject) => {
            let facevideo_node = document.getElementById("facevideo-node");
            detector = new affdex.CameraDetector(facevideo_node);
            detector.detectAllEmotions();

            if (detector && !detector.isRunning) {
                detector.start();
            }           
          
            detector.addEventListener("onInitializeSuccess", () => {
                resolve();
            });

            detector.addEventListener("onImageResultsSuccess", (faces, img, timestamp) => {
                if (state === self.States.RECORDING && video_resumed) {
                    // account for time spent buffering
                    const fake_timestamp = getCurrentTimeAdjusted();

                    if (frames_since_last_face > face_alert_threshold && face_visible) {
                        face_visible = false;
                        self.createAlert("no-face", "No face was detected. Please re-position your face and/or webcam.");
                    }
                    if (faces.length > 0) {
                        if (!face_visible) {
                            face_visible = true;
                            fadeAndRemove("#no-face");
                        }
                        frames_since_last_face = 0;
                        graph.updatePlot(faces[0].emotions, fake_timestamp);
                    } else {
                        frames_since_last_face++;
                        graph.noData(fake_timestamp);
                    }
                }
            });

            const face_video = $("#facevideo-node video")[0];
            face_video.addEventListener("playing", () => {               
                $("#facevideo-node").hide();
            });
        });
    };
    
    const loadExamples = (video_ids) => {
        let promises = [];
        video_ids.forEach((value) => {
            const url = "https://www.googleapis.com/youtube/v3/videos?part=snippet&id=" + value + "&key=" + API_KEY;
            promises.push(
                httpGetAsync(url)
                    .then(addVideoToSuggested(value))
                    .catch(ignore)
            );
        });

        return Promise.all(promises);
    };

    const addVideoToSuggested = (value) => (results) => {
        if (results.items.length > 0) {
            const title = results.items[0].snippet.title;           
            initial_videos.push({
                title: title,
                id: value
            });
        }
    };

/*  ==============================================================
 *  ============================================================== */

    const transitionToSearching = () => {
        
        stopLoading();
        startSearch();

        state = self.States.SEARCHING;
    };
  
    const stopLoading = () => {
        $("#loading-row").addClass("d-none").removeClass("d-flex");
    };

    const startSearch = () => {
        $("#demo-setup").addClass("d-flex").removeClass("d-none");    
        showMessage("instructions");        
        populateExamples();
    };

    const sortVideos = () => {
        let ordering = [];
      
        video_ids.forEach((value) => {
            initial_videos.forEach((video) => {
                if (video.id === value) {
                    ordering.push(video);
                }
            });
        });

        initial_videos = ordering;

    };

    const populateExamples = () => {

        sortVideos();

        const example_container = $("#example-container");

        // list of lists for how we want to orient the examples, depending on the # of examples we have
        // We will have breakpoints in the order xs, sm, md, lg, xl
        const breakpoints = [
            [12, 6, 6, 4, 4], // < 4
            [12, 6, 6, 6, 6], // = 4 (We want a special behavior for this sweet spot),
            [12, 6, 6, 4, 4]  // > 4
        ];

        const bp = (initial_videos.length > 4) ? breakpoints[2] : ((initial_videos.length === 4) ? breakpoints[1] : breakpoints[0]);

        initial_videos.forEach((video, index) => {
            const thumbnail_url = "https://i.ytimg.com/vi/" + video.id + "/mqdefault.jpg";

            let JQVideoColumn = $(`<div class='col-${bp[0]} col-sm-${bp[1]} col-md-${bp[2]} col-lg-${bp[3]} col-xl-${bp[4]}'></div>`);
            let JQVideoNode = $("<div class='example card m-1'></div>");

            JQVideoColumn.appendTo(example_container);
            JQVideoNode.appendTo(JQVideoColumn);

            JQVideoNode[0].style.backgroundImage = "url(" + thumbnail_url + ")";
            // Give it the click handler
            JQVideoNode.click({ id: video.id }, onVideoClick);

            JQVideoNode.hover(() => {
                JQVideoNode[0].style.backgroundBlendMode = "overlay";
                JQVideoNode.html("<p class='video-text'>" + video.title + "</p>");
            }, () => {
                JQVideoNode[0].style.backgroundBlendMode = "initial";
                JQVideoNode.html("");
            });

        });
    };
    
    const onVideoClick = (event) => {
        if (state === self.States.SEARCHING) {
            const video_id = event.data.id;
            if (typeof video_id !== "undefined") {
                transitionToRecording(video_id);
            }
        }
    };        
       

    /*  ==============================================================
     *  ============================================================== */
   
     
    const transitionToRecording = (video_id) => {
       
        $(".demo-message").hide();


        // start the detector ("The detector only starts graphing when in the RECORDING phase")
        player("play", video_id, (message, data) => {
            if (message === "video start") {
                loadGraphButtons();
                state = self.States.RECORDING;
                showGraph(data.start_time, data.video_duration_ms, data.video_duration_sec);
                video_resumed = true;

            } else if (message === "short video") {
                showMessage("msg-short-video");

            } else if (message === "buffer finished") {              
                video_resumed = true;
                time_buffering_ms += data;

            } else if (message === "buffer started") {
               
                video_resumed = false;

            } else if (message === "ended") {
                video_resumed = false;
                if (state === self.States.PLAYBACK) {
                    graph.translateCursor(0);
                } else {
                    transitionToPlayback();
                }
                player("seek", 0);
                player("pause");
            }
            
        });
    };
 
    const showGraph = (start_time, video_duration_ms, video_duration_sec) => {      
        $("#demo-setup").removeClass("d-flex");
        $("#demo-setup").fadeOut("fast", () => {
            $("#video-container").addClass("d-flex");
            graph
                .initPlot()
                .setXScale(start_time, video_duration_ms)
                .updatePlot({
                    "joy": 0,
                    "anger": 0,
                    "disgust": 0,
                    "contempt": 0,
                    "surprise": 0
                }, start_time)
                .configureForPlayback(video_duration_sec);
        });
    };
    
    const loadGraphButtons = () => {       
        $("#all").click(graph.allButtonClickHandler);
        graph.emotions.forEach((val) => {
            $("#" + val).click(graph.EmotionButtonClickHandler(val));
        });
    };   
    
         

/*  ==============================================================
  *  ============================================================== */
    
    const ignore = () => { };
   
    const httpGetAsync = (urlString) => {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: urlString,
                method: "GET",
                success: (data, textStatus, jqXHR) => { resolve(data); },
                failure: (jqXHR, textStatus, errorThrown) => { reject(errorThrown); }
            });
        });
    };    

    const showMessage = (id) => {       
        $(document.getElementById(id)).fadeIn("fast");
    };
    
    const getCurrentTimeAdjusted = () => {
        return Date.now() - time_buffering_ms;
    };

    const fadeAndRemove = () => {              
        $("#lightbox").fadeOut(alert_transition_delay_out);
    };

    const transitionToPlayback = () => {

        detector.stop(); 

        var svgNode = d3.select('svg').node();
        var svg = new XMLSerializer().serializeToString(svgNode);
        var svgbtoa = btoa(svg);      
      
        //  var imgsrc = 'data:image/svg+xml;base64,' + btoa(html);
        //  var img = '<img src="' + imgsrc + '">';   
        
        //  d3.select("#console322").html(atob(testsvg));

        $.ajax({

            type: "POST",
            url: "/JoinSession/AddSVG",
            data: { joinSessionId: joinSessionId, svg: svgbtoa },
            
        });     
    };
}

function Graph(id) {
    
    let self = this;

    
    const curveBox = d3.select(id);
    let cursor = null;
    let cursor_text = null;
    const colors = ["#2ee65d", "#fc4627", "#ffd000", "#2bb3f7", "#ff69bf"];
    let selected_emotion = "all";
    let svg_width = 720;
    let x_scale = d3.scaleLinear().domain([0, 0]).range([0, svg_width]);
    let y_scale = d3.scaleLinear().domain([100, 0]).range([2, 248]);
    let time_scale = null;
    let video_cutoff_sec = 0;
    let video_duration_sec = 0;
    const path = d3.line()
        .curve(d3.curveBasis)
        .x((d, i) => x_scale(d[0]))
        .y((d, i) => y_scale(d[1]));

    let processed_frames = [[[], [], [], [], []]];
    let currentCurvesIdx = 0;
    let wasNil = false;
    let gray_boxes = [[]]; 
    let last_box = null;


    this.emotions = ["joy", "anger", "disgust", "contempt", "surprise"];
   
    
    const textTime = (time_sec) => {
        return Math.floor(time_sec / 60) + ":" + ((time_sec % 60 < 10) ? ("0" + time_sec % 60) : time_sec % 60);
    };

  

    this.setXScale = (start_time, video_duration_ms) => {
        x_scale = d3.scaleLinear().domain([start_time, start_time + video_duration_ms]).range([0, svg_width]);

        return self;
    };
    
    this.getCurveBox = () => {
        return curveBox;
    };
    
    this.getCurves = () => {
        return curveBox.selectAll("path.curve");
    };


    this.resetSelectedEmotionButton = (emotion) => {
        
        if (selected_emotion !== emotion) {

            $("#" + selected_emotion).removeClass("selected");
            $("#" + emotion).addClass("selected");
            selected_emotion = emotion;
        }


        return self;
    };
     
    this.allButtonClickHandler = () => {
        self
            .resetSelectedEmotionButton("all")
            .getCurves()
            .transition()
            .duration(400)
            .attr("stroke-opacity", 1.0);
    };

    /* Button Handler Generator for the rest of the emotions */
    this.EmotionButtonClickHandler = (emotion) => {
        return () => {
            self
                .resetSelectedEmotionButton(emotion)
                .getCurves()
                .transition()
                .duration(400)
                .attr("stroke-opacity", function (d, i) {
                    if (this.id === emotion) {
                        return 1.0;
                    } else {
                        return 0.2;
                    }
                });
        };
    };

    /* Adds a singular datum to the graph. */
    this.addDataPoint = (emotionTable, timestamp) => {
        self.emotions.forEach((val, idx) => {
            processed_frames[currentCurvesIdx][idx].push([timestamp, emotionTable[val]]);
        });
        return self;
    };

    /* Tells graph that there is no data to plot. It will resolve this by finishing the current svg, and creating a new svg */
    this.noData = (timestamp) => {
        if (!wasNil) {
            //Increment current curvesIdx, and initialize some new curves.
            currentCurvesIdx++;

            processed_frames.push([[], [], [], [], []]);
            gray_boxes.push([x_scale(timestamp)]); // First element is the timestamp that was lost.

            last_box = self
                .getCurveBox()
                .append("rect");
            initLastVoid();

        } else {
            plotLastVoid(timestamp);
        }
        wasNil = true;
    };

    /* updates the plot to have up to date information */

    this.updatePlot = (emotionTable, timestamp) => {
        if (wasNil) {
            var initial_data = [
                [[timestamp, emotionTable["joy"]]],
                [[timestamp, emotionTable["anger"]]],
                [[timestamp, emotionTable["disgust"]]],
                [[timestamp, emotionTable["contempt"]]],
                [[timestamp, emotionTable["surprise"]]]
            ];
            self
                .getCurves()
                .filter(".c" + currentCurvesIdx.toString())
                .data(initial_data)
                .enter()
                .append("svg:path")
                .attr("class", "curve c" + currentCurvesIdx.toString()) // append c1 c2 c3 whatever, depending on the current svg.
                .attr("id", function (d, i) { return self.emotions[i]; })
                .attr("d", path)
                .attr("stroke", function (d, i) { return colors[i]; })
                .attr("fill", "transparent")
                .attr("stroke-width", "2px")
                .attr("stroke-opacity", "1");


            gray_boxes[currentCurvesIdx].push(x_scale(timestamp));
            plotLastVoid(timestamp);
            last_box.moveToFront();
            wasNil = false;
        } else {
            self
                .addDataPoint(emotionTable, timestamp)
                .getCurves()
                .filter(".c" + currentCurvesIdx.toString())
                .data(processed_frames[currentCurvesIdx])   // curves are assigned in index order, this is how d3 works.
                .attr("d", path);

        }
        return self;
    };

    var initLastVoid = () => {
        last_box
            .attr("x", gray_boxes[currentCurvesIdx][0])
            .attr("y", 0)
            .attr("width", 0)
            .attr("height", 250)
            .attr("fill", "#404040");
    };

    var plotLastVoid = (timestamp) => {
        let x1 = gray_boxes[currentCurvesIdx][0];
        let x2 = x_scale(timestamp);
        last_box.attr("width", x2 - x1);
    };

    /** Instantiate the plot. zero the data, and set attributes of curves. */
    this.initPlot = () => {

        var initial_data = [
            [[0, 0]], // joy
            [[0, 0]], // anger
            [[0, 0]], // disgust
            [[0, 0]], // contempt
            [[0, 0]]  // surprise
        ];

        self
            .getCurves()
            .data(initial_data)
            .enter()
            .append("svg:path")
            .attr("class", "curve c" + currentCurvesIdx.toString()) // append c1 c2 c3 whatever, depending on the current svg.
            .attr("id", function (d, i) { return self.emotions[i]; })
            .attr("d", path)
            .attr("stroke", function (d, i) { return colors[i]; })
            .attr("fill", "transparent")
            .attr("stroke-width", "2px")
            .attr("stroke-opacity", "1");


        svg_width = $(id).width();

        return self;
    };

    /* Move the cursor (line) to the relevant x coordinate and render the time location of the cursor */
    this.translateCursor = (x_coord) => {
        
        cursor.attr("transform", "translate(" + x_coord + ", 0)");

        // render time
        const time_sec = Math.floor(x_coord / svg_width * video_duration_sec);
        const text = textTime(time_sec);
        cursor_text.text(text);

        // figure out if flip is necessary
        $("#text-width")[0].innerHTML = text;
        const text_width = $("#text-width")[0].clientWidth;
        const flip_at = svg_width - text_width - 5;

        if (x_coord > flip_at) {
            cursor_text.attr("transform", "translate(" + (x_coord - text_width - 10) + ", 0)");
        } else {
            cursor_text.attr("transform", "translate(" + x_coord + ", 0)");
        }

        return self;
    };

    /* returns the time value from the x coordinate. */
    this.playbackFromX = (x_coord) => {
        return time_scale.invert(x_coord);
    };

    /* returns the x coordinate from the time value. */
    this.playbackToX = (time) => {
        return time_scale(time);
    };

    /* clips the X coordinate to the correct x. */
    this.clipX = (x_coord) => {
        var playback_time = time_scale.invert(x_coord);
        if (playback_time < 0) {
            return 0;
        } else if (playback_time >= video_cutoff_sec) {
            return time_scale(video_cutoff_sec);
        } else {
            return x_coord;
        }
    };

    /** Sets the mouse pointer to a dragging state */
    this.setMousePointerDragging = () => {
        $("html, .draggable-rect, line.cursor-wide").css({ "cursor": "-webkit-grabbing" });
        $("html, .draggable-rect, line.cursor-wide").css({ "cursor": "-moz-grabbing" });
        $("html, .draggable-rect, line.cursor-wide").css({ "cursor": "grabbing" });
        return self;
    };
    /** Sets the mouse pointer to it's original state */
    this.setMousePointerUndragging = () => {
        $("html").css({ "cursor": "default" });
        $(".draggable-rect, line.cursor-wide").css("cursor", "pointer");
        return self;
    };
    /* Initializes the cursor and returns it. */
    this.initializeCursor = () => {
        // Initialize Cursor
        cursor = curveBox.append("svg:g").attr("y1", 0).attr("y2", 250).attr("x1", 0).attr("x2", 10).attr("class", "draggable-group");
        cursor.append("svg:rect").attr("x", -5).attr("y", 0).attr("width", 10).attr("height", 250).attr("class", "draggable-rect");
        cursor.append("svg:line").attr("class", "cursor cursor-wide").attr("y1", 0).attr("y2", 250).attr("x1", 0).attr("x2", 0);
        // Initialize cursor text box for current time
        cursor_text = curveBox.append("svg:text").attr("class", "time video_current_time").attr("y", 20).attr("x", 5).text("0:00");

        return cursor;
    };

    /* Should be called from onPlayerStateChange in the player callback closure. This sets the necesary variables to enable the timestep and scale */
    this.configureForPlayback = (video_duration_seconds) => {
        video_duration_sec = video_duration_seconds;
        video_cutoff_sec = Math.floor(video_duration_seconds);
        time_scale = d3.scaleLinear().domain([0, video_duration_seconds]).range([0, svg_width]);
    };
}

function AsyncPlayer() {
    let player = null;
    const VIDEO_VOLUME = 0;
    const VIDEO_LENGTH_THRESHOLD = 5;

    let invokerState = (e) => current_state_change_handle(e);
    let invokerError = (e) => current_error_handle(e);
 
    let current_state_change_handle = (e) => { };
    let current_error_handle = (e) => { };

    let buffer_start_time_ms = 0;
    let video_duration_sec = 0;
    let video_duration_ms = 0;
    let start_time = 0;
    let playing = false;

    let buffer_lock = false;
    let has_ended = false;
    let video_started = false;

    const initializeYouTubePlayer = (cb) => () => {
        player = new YT.Player("player", {
            playerVars: {
                "controls": 0,
                "iv_load_policy": 3,
                "rel": 0,
                "showinfo": 0
            },
            events: {
                "onError": invokerError,
                "onStateChange": invokerState
            }
        });
        cb("loaded");
    };

    const onPlayerError = (cb) => (e) => {
        player.stopVideo();
        start_time = 0;
        cb("error", null);
    };

    const onPlayerStateChange = (cb) => (event) => {
        const status = event.data;

        if (status === YT.PlayerState.PLAYING) {
            playing = true;
        } else {
            playing = false;
        }

        if (status === YT.PlayerState.PLAYING) {
            
            const video_duration_seconds = player.getDuration();
            // Check if the video matches length:
            if (video_duration_seconds < VIDEO_LENGTH_THRESHOLD) {
                player.stopVideo();
                cb("short video", null);
                return;
            } else if (buffer_lock && video_started) {
                // Just came from a buffer. return time difference
                var buffer_time = Date.now() - buffer_start_time_ms;
                buffer_lock = false;
                cb("buffer finished", buffer_time);
                return;
            } else if (!video_started) {
                // There is a valid video started signal
                video_started = true;
                start_time = Date.now();
                player.setVolume(VIDEO_VOLUME);
                video_duration_ms = video_duration_seconds * 1000;
                video_duration_sec = video_duration_seconds;
                cb("video start", {
                    video_duration_ms: video_duration_ms,
                    start_time: start_time,
                    video_duration_sec: video_duration_sec
                });
            } else {
                cb("resume", null);
            }
        } else if (status === YT.PlayerState.ENDED) {
            
            has_ended = true;
            cb("ended", null);
        } else if (status === YT.PlayerState.PAUSED) {
            if (!has_ended) {
                cb("error", "Tried to pause video when video hadn't ended.");
            } else {
                cb("paused", null);
            }
        } else if (status === YT.PlayerState.CUED) {
            if (video_started && !has_ended) {
                cb("network fail", null);
                player.stopVideo();
            } else if (!video_started) {
                cb("video cued w/out starting", null);
            }
        } else if (status === -1) {
            return;
        } else if (status === YT.PlayerState.BUFFERING) {
            if (video_started) {
                buffer_start_time_ms = Date.now();
                buffer_lock = true;
                cb("buffer started", null);
            }
        } else {
            cb("error", "Unknown Player status: " + status);
        }
    };

    return (message, data = null, cb = (message, data) => { }) => {
        //Handle Asynchronous messages
        if (message === "load") {
            // Do the asynchronous loading, and notify the cb when finished
            new Promise((resolve, reject) => {
                var tag = document.createElement("script");
                tag.src = "https://www.youtube.com/iframe_api";
                var firstScriptTag = document.getElementsByTagName("script")[0];
                firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
                resolve();
            });
            // Defer the resolution of this promise to the initialize callback of the youtube player
            window.onYouTubeIframeAPIReady = initializeYouTubePlayer(cb);
        } else if (message === "play") {

            current_state_change_handle = onPlayerStateChange(cb);
            current_error_handle = onPlayerError(cb);
            player.loadVideoById(data); // assume that data is a video id

        } else if (message === "seek") {
            player.seekTo(data);        // assume that data is a time
            cb("seeked", null);
        } else if (message === "pause") {
            player.pauseVideo();
            cb("paused", null);
        } else if (message === "resume") {
            player.playVideo();
            cb("playing", null);
        }
       
        if (message === "getVideoDurationSec") {
            return video_duration_sec;
        } else if (message === "getVideoDurationMs") {
            return video_duration_ms;
        } else if (message === "getStartTime") {
            return start_time;
        } else if (message === "getPlayingState") {
            return playing;
        } else if (message === "getCurrentTime") {
            return player.getCurrentTime();
        } else if (message === "setPlayingState") {
            playing = data;
        }
    };
}
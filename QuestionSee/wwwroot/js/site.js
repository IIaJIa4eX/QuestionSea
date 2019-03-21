

var questionarray = $(".Questions .QuestionCard");

var left_last = 0;
/*
for (var i = 0; i < questionarray.length; i++) {
    var el = jQuery(questionarray[i]);

    el.css({ position: "absolute", top: 0, left: left_last });
    left_last += el.width();
}


    var l = jQuery(questionarray[questionarray.length - 1]);

    l.css("left", 0 - l.width());

    var arr = Array();
    arr.push(l[0]);

    for (var i = 0; i < questionarray.length - 1; i++) {
        arr.push(questionarray[i]);
    }

    questionarray = jQuery(arr);

    questionarray.animate({ left: "+=" + l.width() });
*/
var questionarray = $(".Questions .QuestionCard");

var left_last = 0;
for (var i = 0; i < questionarray.length; i++) {
    var el = jQuery(questionarray[i]);

    el.css({ position: "absolute", top: 0, left: left_last });
    left_last += el.width();
}

function SliderBack() {
    questionarray.animate({ left: "-=" + $(questionarray[0]).width() });


    var l = jQuery(questionarray[0]);

    var arr = Array();
    

    for (var i = 1; i < questionarray.length; i++) {
        arr.push(questionarray[i]);
    }
    arr.push(l[0]);

    questionarray = jQuery(arr);
}

function SliderForward() {
    


    var l = jQuery(questionarray[questionarray.length - 1]);

    l.css("left", 0 - l.width());

    var arr = Array();
    arr.push(l[0]);

    for (var i = 0; i < questionarray.length - 1; i++) {
        arr.push(questionarray[i]);
    }

    questionarray = jQuery(arr);

    questionarray.animate({ left: "+=" + l.width() });
}
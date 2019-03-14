

var questionarray = $(".Questions .QuestionCard");

var left_last = 0;
for (var i = 0; i < questionarray.length; i++) {
    var el = jQuery(questionarray[i]);

    el.css({ position: "absolute", top: 0, left: left_last });
    left_last += el.width();
}

setInterval(function () {
    var l = jQuery(questionarray[questionarray.length - 1]);

    l.css("left", 0 - l.width());

    var arr = Array();
    arr.push(l[0]);

    for (var i = 0; i < questionarray.length - 1; i++) {
        arr.push(questionarray[i]);
    }

    questionarray = jQuery(arr);

    questionarray.animate({ left: "+=" + l.width() });

}, 1000);
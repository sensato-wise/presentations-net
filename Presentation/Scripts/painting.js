function loadSlides() {
    var presentId = $('#presentationId').attr("value");

    $.ajax({
        type: 'GET',
        url: "/Slide/GetSlides",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        traditional: true,
        data: { id: presentId },
        success: function (data) {
            //alert('in student');
            createLoadedSlides(data);

        },
        error: function (data) {
            alert("Error");
        }
    });
}

function createLoadedSlides(data) {
    for (var i = 0; i < data.length; ++i) {
        createNewSlide(data[i], "real");
    }
    if (slideCount == 0)
        createStandartSlides();
    else {
        for (var j = 0; j < 2; ++j)
            createNewSlide(newSlide, "temp");
    }
    update();
    var target = document.getElementById('PaintWebTarget');
    pw = new PaintWeb();
    var imgUrl = document.getElementById("img1");
    var img = document.createElement('img');
    img.setAttribute("src", imgUrl.getAttribute("src"));
    pw.config.guiPlaceholder = target;
    pw.config.imageLoad = img;
    pw.config.configFile = 'config-example.json';
    pw.init();
    pw.events.add('imageSave', saveHandler);

}


function update() {
    //jCarousel Plugin
    $('#carousel').jcarousel({
        vertical: true, //display vertical carousel
        scroll: 1,  //auto scroll
        auto: 0,    //the speed of scrolling
        wrap: 'last',   //go back to top when reach last item
        initCallback: mycarousel_initCallback   //extra called back function
    });

    //Front page Carousel - Initial Setup
    //set all the item to full opacity
    $('div#slideshow-carousel a img').css({ 'opacity': '1.0' });

    //readjust the first item to 50% opacity
    $('div#slideshow-carousel a img:first').css({ 'opacity': '1.0' });

    //append the arrow to the first item
    $('div#slideshow-carousel li a:first').append('<span class="arrow"></span>')


    //Add hover and click event to each of the item in the carousel
    $('div#slideshow-carousel li a').hover(
        function () {

            //check to make sure the item is not selected
            if (!$(this).has('span').length) {
                //reset all the item's opacity to 50%
                $('div#slideshow-carousel li a img').stop(true, true).css({ 'opacity': '0.9' });

                //adust the current selected item to full opacity
                $(this).stop(true, true).children('img').css({ 'opacity': '1.0' });
            }
        },
        function () {

            //on mouse out, reset all the item back to 50% opacity
            $('div#slideshow-carousel li a img').stop(true, true).css({ 'opacity': '0.9' });

            //reactivate the selected item by loop through them and look for the one
            //that has the span arrow
            $('div#slideshow-carousel li a').each(function () {
                //found the span and reset the opacity back to full opacity
                if ($(this).has('span').length) $(this).children('img').css({ 'opacity': '1.0' });

            });

        }
    ).click(function () {

        //remove the span.arrow
        $('span.arrow').remove();

        //append it to the current item        
        $(this).append('<span class="arrow"></span>');

        //alert("I here");
        var slideNumber = $(this).attr("id");

        saveSlide();
        // check on temp
        var type = $(this).parent('li').attr("id");
        var imgUrl = document.getElementById("img" + slideNumber);
        if (type == "temp") {
            imgUrl.setAttribute("src", tempImage);
            $(this).parent('li').attr("id", "real");

            //            if (slideNumber == slideCount) {
            //                createNewSlide();
            //            }
        }
        var img = document.createElement('img');
        img.setAttribute("src", imgUrl.getAttribute("src"));
        currentSlide = slideNumber;
        pw.imageLoad(img);
        return false;
    });

}

function createNewSlide(image, type) {
    var startList = document.getElementById("carousel");
    slideCount++;
    var list = document.createElement("li");
    var link = document.createElement("a");
    link.setAttribute("id", slideCount);
    link.setAttribute("href", "");
    link.setAttribute("rel", "");
    var img = document.createElement("img");
    img.setAttribute("width", 206);
    img.setAttribute("height", 95);
    img.setAttribute("id", "img" + slideCount);
    img.setAttribute("src", image);
    list.setAttribute("id", type);
    link.appendChild(img);
    list.appendChild(link);
    startList.appendChild(list);
}

function createStandartSlides() {
    slideCount = 4;
    var startList = document.getElementById("carousel");
    for (var i = 1; i <= slideCount; i++) {
        var list = document.createElement("li");

        var link = document.createElement("a");
        link.setAttribute("id", i);
        link.setAttribute("href", "");
        link.setAttribute("rel", "");
        var img = document.createElement("img");
        img.setAttribute("width", 206);
        img.setAttribute("height", 95);
        img.setAttribute("id", "img" + i);
        if (i < 2) {
            img.setAttribute("src", tempImage);
            list.setAttribute("id", "real");
        }
        else {
            img.setAttribute("src", newSlide);
            list.setAttribute("id", "temp");
        }
        link.appendChild(img);
        list.appendChild(link);
        startList.appendChild(list);
    }
}

function mycarousel_initCallback(carousel) {
}

function saveSlide() {
    pw.imageSave('image/jpeg');
}

function saveHandler(ev) {
    // Cancel the default action of the event.
    ev.preventDefault();
    var slide = document.getElementById("img" + currentSlide);
    slide.setAttribute("src", ev.dataURL);
}



function trySave() {
    saveSlide();
    var list = document.getElementById("carousel");
    var imageArray = new Array();

    for (var i = 1; i <= slideCount; i++) {
        var j = list.childNodes[i];

        if (j.getAttribute("id") == "real") {
            var index = j.childNodes[0].getAttribute("id");
            var source = document.getElementById("img" + index);
            imageArray[i] = source.getAttribute("src");
        }
    }
    $.ajax({
        type: 'POST',
        url: "/Slide/Save",
        data: { images: imageArray },
        traditional: true,
        success: function (data) {
            alert('in student');
        },
        error: function (data) {
            alert("not in student");
        }
    });
}
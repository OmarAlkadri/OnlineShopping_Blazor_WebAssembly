function showTopAndBottom() {
    var elements = document.getElementsByClassName("ForAll");
    if (elements) {
        for (var i = 0; i < elements.length; i++) {
            var element = elements[i];
            element.style.cssText += 'display:unset;';
        }
    }
}

function hideTopAndBottom() {
    var elements = document.getElementsByClassName("ForAll");
    if (elements) {
        for (var i = 0; i < elements.length; i++) {
            var element = elements[i];
            element.style.cssText += 'display:none;';
        }
    }
}

function showBottom() {
    var element = document.getElementById("Bottom");
    if (element)
        element.style.cssText += 'display:unset;';
}

function hideBottom() {
    var element = document.getElementById("Bottom");
    if (element)
        element.style.cssText += 'display:none;';
}

/*function addProduct(productId) {
     jQuery(document).ready(function ($) {
        $('#' + productId).on('click', function (e) {
            e.preventDefault();
            $('#' + productId).addClass('expanded');
            setTimeout(() => $('#' + productId).removeClass('expanded'), 1000);
        })
    });
}*/


/*
 
 function addProduct(productId) {
    //jQuery(document).ready(function ($) {
    //$('#' + productId).on('click', function (e) {
    //    e.preventDefault();
    var element = document.getElementById('#' + productId);
    if (element) {

    element.classList.add('expanded');
    //$('#' + productId).addClass('expanded');

    setTimeout(() => element.classList.remove('expanded'), 1000);
    }
    //})
    //});
}
 */
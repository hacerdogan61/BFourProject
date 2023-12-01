$(window).on('load', function () {
    setTimeout(function () {
        $(".loading-full").removeClass("loading-show");
    }, 500);
});

$(document).ready(function () {
    function n() {
        var n = $(".menu-inner").find("ul"),
            i = $(".menu-inner").find(".indicator"),
            t = n.find("li").first().children().outerWidth();
        i.css("width", t + "px"),
            n.find("a").on("mouseover", function () {
                var n = $(this).outerWidth(),
                    t = 0;
                $(this).parent().prevAll().each(function () {
                    t += parseInt($(this).find("a").outerWidth())
                }), i.css({
                    width: n + "px",
                    transform: "translate3d(" + t + "px, 0, 0)"
                });
            })
    }
    n()
});
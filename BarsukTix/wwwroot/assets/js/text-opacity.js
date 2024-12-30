
// =========Text-Opacity=========>>>>>
    $(".text-opacity").each(function () {
        var words = $(this).text().split(" ");
        var total = words.length;
        $(this).empty();
        for (index = 0; index < total; index++) {
        $(this).append($("<span /> ").text(words[index] + " "));
        }
    });

    var TextOpacity = gsap.utils.toArray(".text-opacity");    
    TextOpacity.forEach(function (TextOpacity) {
        var spanOpacity = TextOpacity.querySelectorAll("span");
        gsap.to(spanOpacity, {
            scrollTrigger: {
                trigger: TextOpacity,
                start: "top 85%",
                end: () => `+=${TextOpacity.offsetHeight}`,
                scrub: 1
            },
            duration: 1,
            opacity: 1,
            stagger: 0.5,
            ease: Linear.easeNone
        });
    });  
// =========Text-Opacity=========>>>>>

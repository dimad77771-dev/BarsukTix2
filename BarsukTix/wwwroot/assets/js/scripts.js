(function ($) {
  "use strict";

  $(window).on("load", function () {
    $(".preloader").delay(350).fadeOut("slow");
  });



  // =======Blog-gradient-border========>>>>>
  $(document).ready(function() {
    $('.blog-content').hover(
      function() {
        if ($('html').attr('data-bs-theme') === 'dark') {
          $(this).addClass('blog-gradient-border');
        }
      },
      function() {
        $(this).removeClass('blog-gradient-border');
      }
    );
  });
  // =======Blog-gradient-border========>>>>>


  // =======Sticky-header========>>>>>
  $(window).on('scroll', function () {
    var scroll = $(window).scrollTop();
    if (scroll < 50) {
        $(".sticky-navbar").removeClass("sticky");
        $('.back-to-top').hide();
    } else {
        $(".sticky-navbar").addClass("sticky");
        $('.back-to-top').show();
    }
  });
  // =======Sticky-header========>>>>>



    // =======Social share========>>>>>
    if($('.share-link').length > 0){
      $('.share-link').on('click', function(event){
        event.preventDefault();
        let iconList = $('.social-icons-list');
        iconList.toggleClass('social-icons-toggle');
      });
    }
    // =======Social share========>>>>>


    // =======CounterUp JS-Odometer========>>>>>   
    if($('.odometer').length > 0){
      $(window).on('scroll', function () {
        let preloaderTimeout = 2500;
        function winScrollPosition() {
            var scrollPos = $(window).scrollTop(),
                winHeight = $(window).height();
            var scrollPosition = Math.round(scrollPos + (winHeight / .07));
            return scrollPosition;
        }
        var elemOffset = $('.odometer').offset().top;
        if (elemOffset < winScrollPosition()) {

          setTimeout(function () {
            $('.odometer').each(function () {
              $(this).html($(this).data('count-to'));
            });
          }, preloaderTimeout + 200);          
        }
    });
  }

  // =======CounterUp JS-Odometer========>>>>>


  // =======Circle========>>>>>
  const text = document.querySelector ('.rotate-text p');
  if(text){
  text.innerHTML = text.innerText.split("").map(
      (char, i)=>
      `<span style="transform:rotate(${i*9.6}deg)">${char}</span>`
  ).join("");
  }

  const text2 = document.querySelector ('.rotate-text2 p');
  if(text2){
  text2.innerHTML = text2.innerText.split("").map(
      (char, i)=>
      `<span style="transform:rotate(${i*9.6}deg)">${char}</span>`
  ).join("");
  }

  const text3 = document.querySelector ('.rotate-text3 p');
  if(text3){
    text3.innerHTML = text3.innerText.split("").map(
        (char, i)=>
        `<span style="transform:rotate(${i*9.6}deg)">${char}</span>`
    ).join("");
  }
  
  // =======Circle========>>>>>
  

    // =======Swiper .ticket-swiper========>>>>>
    if($('.ticket-swiper').length > 0){
      new Swiper(".ticket-swiper", {
        loop: true,    
        grabCursor: true,
        slidesPerView: 1, 
        autoplay: {   
          delay: 5000,
        },                      
        pagination: {
          el: ".ticket-swiper-pagination",
          clickable: true,    
        },            
      });
    }
    // =======Swiper .ticket-swiper========>>>>>



    // =======Swiper .swiper_gallery========>>>>>
    if ($('.swiper_gallery').length > 0) {
      new Swiper(".swiper_gallery", {
        autoplay: {
          delay: 0,
        },
        slidesPerView: 'auto',
        pauseOnMouseEnter: true,
        speed: 6000,
        spaceBetween: 30,
        loop: true,
        pagination: false,
        navigation: false,
      });
    }
    if ($('.swiper_gallery2').length > 0) {
      new Swiper(".swiper_gallery2", {
        autoplay: {
          delay: 0,
        },
        slidesPerView: 'auto',
        pauseOnMouseEnter: true,
        speed: 7000,
        spaceBetween: 30,
        loop: true,
        pagination: false,
        navigation: false,
      });
    }
    // =======Swiper .swiper_gallery========>>>>>



    // =======Swiper .lineup-swiper========>>>>>
    if($('.lineup-swiper').length > 0){
      new Swiper(".lineup-swiper", {
        loop: true,    
        grabCursor: true,
        spaceBetween: 20,
        breakpoints: {   
          380: {
            slidesPerView: 1,
            slidesPerGroup: 1,   
          },        
          430: {
            slidesPerView: 2,
            slidesPerGroup: 2,
          },      
          900: {
            slidesPerView: 3,
          }
        },     
        
        pagination: {
          el: ".lineup-swiper-pagination",
          type: "progressbar",      
        },
        navigation: {
          nextEl: ".swiper-button-next",
          prevEl: ".swiper-button-prev",
        },
        
      });
    } 
    // =======Swiper .lineup-swiper========>>>>>
    

    // =======Swiper .highlight-swiper========>>>>>
      new Swiper(".highlight-swiper", {
        loop: true,    
        grabCursor: true,
        spaceBetween: 20,
        breakpoints: {                  
          430: {
            slidesPerView: 1,
            slidesPerGroup: 1,
            spaceBetween: 20
          },      
          768: {
            slidesPerView: 2,
            slidesPerGroup: 1,
            spaceBetween: 20
          },
          1100: {
            slidesPerView: 3,
            slidesPerGroup: 1,
            spaceBetween: 20
          }
        },           
        pagination: {
          el: ".swiper-pagination",
          type: "progressbar",      
        },      
      });


      //highlight-swiper-overflow========>>>>> 
      new Swiper(".highlight-swiper-overflow", { 
        loop: false,        
        grabCursor: true,
        spaceBetween: 20,
        breakpoints: {                  
          430: {
            slidesPerView: 1,
            slidesPerGroup: 1,
            spaceBetween: 20
          },      
          768: {
            slidesPerView: 2,
            slidesPerGroup: 1,
            spaceBetween: 20
          },
          1100: {
            slidesPerView: 3,
            slidesPerGroup: 1,
            spaceBetween: 20
          }
        },    
        pagination: {
          el: ".swiper-pagination",
          type: "progressbar",      
        },      
      });
      //highlight-swiper-overflow========>>>>


    // =======Swiper .highlight-2-swiper========>>>>>
    new Swiper(".highlight-2-swiper", {
      loop: true,    
      grabCursor: true,
      spaceBetween: 20,
      breakpoints: {                      
        430: {
          slidesPerView: 1,
          slidesPerGroup: 1,
          spaceBetween: 20
        },      
        993: {
          slidesPerView: 2,
          slidesPerGroup: 1,
          spaceBetween: 20
        },
        1400: {
          slidesPerView: 3,
          slidesPerGroup: 1,
          spaceBetween: 20
        }
      },
      pagination: {
        el: ".swiper-pagination",
        type: "progressbar",      
      },      
    });
    // =======Swiper .highlight-2-swiper========>>>>>


  // =======Swiper .brand-swiper========>>>>>
  new Swiper(".brand-swiper", {
    loop: true,    
    grabCursor: true,  
    spaceBetween: 20,
    breakpoints: {                
      300: {
        slidesPerView: 2,
        slidesPerGroup: 2, 
        spaceBetween: 20,
      },      
      490: {
        slidesPerView: 3,
        slidesPerGroup: 2,
        spaceBetween: 20
      },
      720: {
        slidesPerView: 3,
        slidesPerGroup: 2,
        spaceBetween: 40
      },
      900: {
        slidesPerView: 4,
        slidesPerGroup: 2,
        spaceBetween: 60
      },
      1200: {
        slidesPerView: 5,
        slidesPerGroup: 2,
        spaceBetween: 90
      }
    },     
    
    pagination: {
      el: ".swiper-pagination",
      type: "progressbar",      
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
    
  });
  // =======Swiper .brand-swiper========>>>>>


    // =======Swiper .blog-swiper========>>>>>
    new Swiper(".blog-swiper", {
      loop: false,    
      // grabCursor: true,
      spaceBetween: 20,

      breakpoints: { 
        420: {
          slidesPerView: 1,
          slidesPerGroup: 1,
          spaceBetween: 20
        },      
        768: {
          slidesPerView: 2,
          slidesPerGroup: 1,
          spaceBetween: 30
        },
      },     
      
      pagination: {
        el: ".swiper-pagination",
        type: "progressbar",      
      },
      navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
      },
      
    });
    // =======Swiper .blog-swiper========>>>>>


    // =======Swiper .blog-swiper-2========>>>>>
    new Swiper(".blog-swiper-2 ", {
      loop: true,    
      grabCursor: true,
      spaceBetween: 20,
      breakpoints: {  
                
        330: {
          slidesPerView: 1,
          slidesPerGroup: 1,
          spaceBetween: 20
        },      
        540: {
          slidesPerView: 2,
          slidesPerGroup: 1,
          spaceBetween: 20
        },
        1100: {
          slidesPerView: 3,
          slidesPerGroup: 1,
          spaceBetween: 30
        }
      },     
      
      pagination: {
        el: ".swiper-pagination",
        type: "progressbar",      
      },      
    });
    // =======Swiper .blog-swiper-2========>>>>>


    // =======Swiper .blog-swiper-3========>>>>>
    new Swiper(".blog-swiper-3 ", {
      loop: true,    
      grabCursor: true,
      spaceBetween: 30,
      breakpoints: {  
                
        430: {
          slidesPerView: 1,
          slidesPerGroup: 1,
          spaceBetween: 30
        },      
        700: {
          slidesPerView: 2,
          slidesPerGroup: 1,
          spaceBetween: 30
        },        
      },     
      
      pagination: {
        el: ".swiper-pagination",
        type: "progressbar",      
      },      
    });
    // =======Swiper .blog-swiper-3========>>>>>


    // =======Swiper .merchandise-swiper========>>>>>
    new Swiper(".merchandise-swiper", {
      loop: true,    
      grabCursor: true,
      spaceBetween: 30,
      breakpoints: { 
        420: {
          slidesPerView: 1,
          slidesPerGroup: 1,
          spaceBetween: 30
        },      
        768: {
          slidesPerView: 2,
          slidesPerGroup: 1,
          spaceBetween: 30
        },
        1100: {
          slidesPerView: 3,
          slidesPerGroup: 1,
          spaceBetween: 20
        },
        1500: {
          slidesPerView: 4,
          slidesPerGroup: 1,
          spaceBetween: 20
        },
      },     
      
      pagination: {
        el: ".swiper-pagination",
        type: "progressbar",      
      },
      navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
      },
      
    });
    // =======Swiper .merchandise-swiper========>>>>>


    // =======Swiper .blog-2-swiper========>>>>>
    new Swiper(".blog-2-swiper", {
      loop: true,    
      // grabCursor: true,
      spaceBetween: 30,
      breakpoints: { 
        769: {
          slidesPerView: 1,
          slidesPerGroup: 1,
          spaceBetween: 30
        },      
        770: {
          slidesPerView: 2,
          slidesPerGroup: 1,
          spaceBetween: 30
        },
        1100: {
          slidesPerView: 3,
          slidesPerGroup: 1,
          spaceBetween: 30
        }
      },           
      pagination: {
        el: ".swiper-pagination",
        type: "progressbar",      
      },
      navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
      },      
    });
    // =======Swiper .blog-2-swiper========>>>>>


    // =======Swiper .pricing-swiper========>>>>>
    new Swiper(".pricing-swiper", {
      loop: true,    
      grabCursor: true,
      spaceBetween: 30,
      breakpoints: { 
        500: {
          slidesPerView: 1,
          slidesPerGroup: 1,
        },      
        769: {
          slidesPerView: 2,
          slidesPerGroup: 1,
          spaceBetween: 30
        },

        1200: {
          slidesPerView: 3,
          slidesPerGroup: 1,
          spaceBetween: 30
        }
      },     
      
      pagination: {
        el: ".swiper-pagination",
        type: "progressbar",      
      },
                
    });
    // =======Swiper .pricing-swiper========>>>>>


  // =========Button(Increse-Decrese)=========>>>>>
  var buttonPlus  = $(".plus-icon");
  var buttonMinus = $(".dash-icon");

  var incrementPlus = buttonPlus.click(function() {
    var $n = $(this)
    .parent(".ticket-amounts")
    .find(".input-number");
    $n.val(Number($n.val())+1 );
  });

  var incrementMinus = buttonMinus.click(function() {
    var $n = $(this)
    .parent(".ticket-amounts")
    .find(".input-number");
    var amount = Number($n.val());
    if (amount > 1) {
      $n.val(amount-1);
    }
  });
  // =========Button(Increse-Decrese)=========>>>>>


  // =========Ticket-Section Radio-Input=========>>>>>
      $('input:radio:checked').parent().addClass("radio-checked-bg border-transparent");
      $('input:radio').click(function () {
        $('input:not(:checked)').parent().removeClass("radio-checked-bg border-transparent");
        $('input:checked').parent().addClass("radio-checked-bg border-transparent");
      });
  // =========Ticket-Section Radio-Input=========>>>>>
  

  // =======Magnific-PopUp========>>>>>    
  $('.image-link').magnificPopup({
    type: 'image',
    gallery:{
      enabled:true
    },
    zoom: {
      enabled: true,
      duration: 300, // don't foget to change the duration also in CSS
      opener: function(element) {
          return element.find('img');
      }
    }  
  });


  // Video popup
	$('.video-popup-link').magnificPopup({
    disableOn: 200,
    type: 'iframe',
    mainClass: 'mfp-fade',
    removalDelay: 160,
    preloader: false,
    fixedContentPos: false
  });
  // =======Magnific-PopUp========>>>>>

  if($('.hover-area').length > 0){
    var ball = document.querySelector(".ball");
    var cursorText = document.querySelector(".cursor-text");
  
    var hoverAreas = document.querySelectorAll('.hover-area');
  
    var lastHoveredElement = null;
  
    function updateCursor(e) {
      var x = e.clientX;
      var y = e.clientY;
  
      var scrollX = window.pageXOffset || document.documentElement.scrollLeft;
      var scrollY = window.pageYOffset || document.documentElement.scrollTop;
  
      ball.style.left = x + scrollX + "px";
      ball.style.top = y + scrollY + "px";
      cursorText.style.left = x + scrollX + "px";
      cursorText.style.top = y + scrollY + "px";
  
      if (lastHoveredElement === null) {
        ball.style.display = 'block';
        ball.style.height = "10px";
        ball.style.width = "10px";
        cursorText.style.opacity = '0';
      }
    }
  
    function handleHoverEnter(e) {
      cursorText.innerHTML = e.target.getAttribute('data-cursor-text');
      cursorText.style.opacity = '1';
      ball.style.height = "50px";
      ball.style.width = "130px";
  
      lastHoveredElement = e.target;
    }
  
    function handleHoverLeave(_e) {
      cursorText.style.opacity = '0';
      ball.style.display = 'block';
  
      lastHoveredElement = null;
    }
  
    document.addEventListener('mousemove', updateCursor);
  
    hoverAreas.forEach(function(elem) {
      elem.addEventListener('mouseenter', handleHoverEnter);
      elem.addEventListener('mouseleave', handleHoverLeave);
    });
  }


})(jQuery);

document.addEventListener("DOMContentLoaded", function () {
  // menu dynamic active class js
  function eventiva_dynamicCurrentMenuClass(selector) {
    let currentPath = window.location.href.split("/").reverse()[0];
    console.log(currentPath)
    Array.from(selector.querySelectorAll("li")).forEach(function (li) {
      let anchor = li.querySelector("a");
      if (anchor.getAttribute("href") === currentPath) {
        console.log(anchor.getAttribute("href"))
        anchor.classList.add("active");
      }
    });
    Array.from(selector.children).forEach(function (li) {
      let anchor = li.querySelector("a");
      if (li.querySelector(".active")) {
        anchor.classList.add("active");
      }
    });
    if (currentPath === "") {
      selector.querySelector("li a").classList.add("active");
    }
  }

  let navUL = document.querySelector(".menu-list");
  if (navUL) {
    eventiva_dynamicCurrentMenuClass(navUL);
  }

  // make it as accordion for smaller screens
  if (window.innerWidth > 992) {
      document.querySelectorAll('.hover-menu .nav-item.dropdown').forEach(function (everyitem) {
          everyitem.addEventListener('mouseover', function (_e) {
              let el_link = this.querySelector('a[data-bs-toggle]');
              if (el_link !== null) {
                  let nextEl = el_link.nextElementSibling;
                  el_link.classList.add('show');
                  if (nextEl !== null && this.contains(nextEl)) {
                      nextEl.classList.add('show');
                  }
              }
          }.bind(everyitem)); // Explicitly bind the context to the current element
          everyitem.addEventListener('mouseleave', function (_e) {
              let el_link = this.querySelector('a[data-bs-toggle]');
              if (el_link !== null) {
                  let nextEl = el_link.nextElementSibling;
                  if (nextEl !== null && this.contains(nextEl)) {
                      el_link.classList.remove('show');
                      nextEl.classList.remove('show');
                  }
              }
          }.bind(everyitem)); // Explicitly bind the context to the current element
      });
  }
  // end if innerWidth

  // toggle tooltip js
  const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
  if(tooltipTriggerList){
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));
  }
});
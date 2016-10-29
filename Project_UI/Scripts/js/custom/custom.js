function javalar() {
$('.section.ilan-detay .box.info .item.info-list > .row:last-child').css({'margin-bottom':'0'});
$('.section.ilan-ara .filter .item .content:last-child').css('border','0');
$('.section.ilan-ara .list table tr td:first-child').css('border-left','0');
$('.section.ilan-ara .list table tr td:last-child').css('border-right','0');

$('table tr').click(function(){
  window.location = $(this).data('href');
  return false;
});
    
$('.section.ilan-ara .filter .item').click(function() {
  setTimeout(function(){
    var yukseklik = $('.section.ilan-ara .filter').height();
    $('.section.ilan-ara').css('min-height',yukseklik);
  }, 500);
});
$('.filtre-btn').click(function() {
  $('.section.ilan-ara .filter').fadeIn();
  $('.section.ilan-ara .wrapper').fadeOut();
  var yukseklik = $('.section.ilan-ara .filter').height();
  $('.section.ilan-ara').css('min-height',yukseklik);
});
$('.section.ilan-ara .filter .head-title .closex').click(function() {
  $('.section.ilan-ara .filter').fadeOut();
  $('.section.ilan-ara .wrapper').fadeIn();
});


$('.section.ilan-ara .filter .item').eq(0).addClass('on');
$('.section.ilan-ara .filter .item').eq(0).find('.content').show();
$('.section.ilan-ara .filter .item').eq(1).addClass('on');
$('.section.ilan-ara .filter .item').eq(1).find('.content').show();
$('.section.ilan-ara .filter .item .title').click(function() {
  if ($(this).parent().find('.content').length > 0) {
    $(this).parent().find('.content').slideToggle();
    $(this).parent().toggleClass('on');
  }
});

$('.section.list .item').mouseenter(function() {
  $(this).find('.over').stop().fadeIn();
}).mouseleave(function() {
  $(this).find('.over').stop().fadeOut();
});
$('.section.ilan-list .item').mouseenter(function() {
  $(this).find('.over').stop().fadeIn();
}).mouseleave(function() {
  $(this).find('.over').stop().fadeOut();
});
$('.section.ilan-ara .list .item').mouseenter(function() {
  $(this).find('.over').stop().fadeIn();
}).mouseleave(function() {
  $(this).find('.over').stop().fadeOut();
});

$('.header a.mobile-menu').click(function() {
  $('.header ul.menu, .overlay').fadeIn();
  $('.search-wrapper').slideUp();
});
$('.header ul.menu .title a.menu-close').click(function() {
  $('.header ul.menu, .overlay').fadeOut();
});

$('.header a.search-btn').click(function() {
  $('.search-wrapper').slideToggle();
});
$('.search-wrapper a.search-close').click(function() {
  $('.search-wrapper').slideUp();
});

// search tabs
  $(".ev-ara .tab_content").hide();
  var onMenuTab = $(".ev-ara .tab-menu ul li.active").attr('rel');
  $("#"+onMenuTab).fadeIn(); 

  $(".ev-ara .tab-menu ul li").click(function() {
    $(".ev-ara .tab-menu ul li").removeClass("active");
    $(this).addClass("active");
    $(".ev-ara .tab_content").hide();
    var activeTab = $(this).attr("rel"); 
    $("#"+activeTab).fadeIn(); 
  });
// search tabs end

// proje tabs
  $(".section.ilan-ara .list").hide();
  var onMenuTab = $(".view ul li.active").attr('rel');
  $("#"+onMenuTab).fadeIn(); 

  $(".view ul li").click(function() {
    $(".view ul li").removeClass("active");
    $(this).addClass("active");
    $(".section.ilan-ara .list").hide();
    var activeTab = $(this).attr("rel"); 
    $("#"+activeTab).fadeIn(); 
  });
// proje tabs end

// ilan tabs
  $(".proje-tab .tab_content").hide();
  var onMenuTab = $(".proje-tab .tab-menu ul li.active").attr('rel');
  $("#"+onMenuTab).fadeIn(); 

  $(".proje-tab .tab-menu ul li").click(function() {
    $(".proje-tab .tab-menu ul li").removeClass("active");
    $(this).addClass("active");
    $(".proje-tab .tab_content").hide();
    var activeTab = $(this).attr("rel"); 
    $("#"+activeTab).fadeIn(); 
  });
// ilan tabs end

  $('body a').each(function(){
    var link = $(this).attr('href');
    if (link == "#") {
      $(this).attr('href',"javascript:void(0);");
    } else {
    }
  });
}

function mobileClass() {
  var wWidth = $(window).width();
  if (wWidth < 751) {
    $('.section.list .container > .list-owl').addClass('mobile-list');
  } else {
    $('.section.list .container > .list-owl').removeClass('mobile-list');
  }
}

$(window).resize(function(){
  mobileClass();
});

$(window).load(function(){
});

$(document).ready(function() {
  javalar();
  mobileClass();
  var yukseklik = $('.section.ilan-ara .filter').height();
  $('.section.ilan-ara').css('min-height',yukseklik);

  $(".mobile-list").owlCarousel({
    navigation : false,
    items : 2,
    autoPlay : true,
    itemsDesktop : [1199,2],
    itemsDesktopSmall : [980,2],
    itemsTablet: [768,2],
    itemsMobile : [479,2],
  });
  $(".proje-owl").owlCarousel({
    navigation : false,
    items : 3,
    autoPlay : true,
    itemsDesktop : [1199,3],
    itemsDesktopSmall : [980,2],
    itemsTablet: [768,2],
    itemsMobile : [479,2],
  });
$('.galleryBig').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows: false,
  fade: true,
  dots: true,
  asNavFor: '.gallerySmall'
});
$('.gallerySmall').slick({
  slidesToShow: 6,
  slidesToScroll: 1,
  asNavFor: '.galleryBig',
  dots: false,
  centerMode: false,
  focusOnSelect: true
});

lightbox.option({
      'resizeDuration': 200,
      'wrapAround': true
});

  
});


jQuery(function() {
     var input = document.createElement("input");
     if (('placeholder' in input) == false) {
          jQuery('[placeholder]').focus(function() {
               var i = jQuery(this);
               if (i.val() == i.attr('placeholder')) {
                    i.val('').removeClass('placeholder');
                    if (i.hasClass('password')) {
                         i.removeClass('password');
                         this.type = 'password';
                    }
               }
          }).blur(function() {
               var i = jQuery(this);
               if (i.val() == '' || i.val() == i.attr('placeholder')) {
                    if (this.type == 'password') {
                         i.addClass('password');
                         this.type = 'text';
                    }
                    i.addClass('placeholder').val(i.attr('placeholder'));
               }
          }).blur().parents('form').submit(function() {
               jQuery(this).find('[placeholder]').each(function() {
                    var i = jQuery(this);
                    if (i.val() == i.attr('placeholder'))
                         i.val('');
               })
          });
     }
});
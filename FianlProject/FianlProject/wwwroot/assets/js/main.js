// AOS 

AOS.init();

// accordian AllCategories

var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function() {
    this.classList.toggle("active");
    var dropdown = this.nextElementSibling;
    if (dropdown.style.display === "block") {
      dropdown.style.display = "none";
    } else {
      dropdown.style.display = "block";
    }
    console.log(dropdown);
  });
  
}

// checkout click d-block

// function myFunction() {
//   document.getElementById('form-login-hidden').style.display = 'block';
// }

function myFunction() {
  let x = document.getElementById("form-login-hidden");
  if (x.style.display === "none") {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}


//SideBar menu

let menu = document.getElementById('menu');
let sidebar = document.getElementById('sidebar');
let close = document.getElementById('close')

close.addEventListener('click', function(){
    sidebar.classList.remove('menu-active')
})

menu.addEventListener('click', function(){
    sidebar.classList.add('menu-active');
})

// pageYOFFset
window.addEventListener('scroll', function(){
	let well = document.querySelector(".headerbottom");

	if(window.pageYOffset>200){
		well.classList.add('sticky');
	}else{
    well.classList.remove('sticky');  
    }
})


// Recently Added tab
$(function () {
  var tab = $(".nav-item"),
    content = $(".content_tab");

  tab.filter(":first").addClass("active");

  content.filter(":not(:first)").hide();

  tab.click(function () {
    var indeks = $(this).index();
    tab.removeClass("active").eq(indeks).addClass("active");
    console.log(indeks);
    content.hide().eq(indeks).fadeIn(500);
    // console.log(content);
    return false;
  });
});

// New Arrivals tab
$(function () {
  var tab = $(".nav_tab"),
    content = $(".arrival_content");

  tab.filter(":first").addClass("active");

  content.filter(":not(:first)").hide();

  tab.click(function () {
    var indeks = $(this).index();
    tab.removeClass("active").eq(indeks).addClass("active");
    console.log(indeks);
    content.hide().eq(indeks).fadeIn(500);
    // console.log(content);
    return false;
  });
});

// Product Details tab
$(function () {
  var tab = $(".tab_one"),
    content = $(".tab_body");

  tab.filter(":first").addClass("active");

  content.filter(":not(:first)").hide();

  tab.click(function () {
    var indeks = $(this).index();
    tab.removeClass("active").eq(indeks).addClass("active");
    console.log(indeks);
    content.hide().eq(indeks).fadeIn(500);
    // console.log(content);
    return false;
  });
});

// in shop view tab
$(function () {
  var tab = $(".nav-item"),
  content = $(".shop_content");

  tab.filter(":first").addClass("active");

  content.filter(":not(:first)").hide();

  tab.click(function () {
      var indeks = $(this).index();
      tab.removeClass("active").eq(indeks).addClass("active");
      console.log(indeks);
      content.hide().eq(indeks).fadeIn(500);
    // console.log(content);
      return false;
  });
});


// shop tab
const left = document.getElementById("tab1");
const right = document.getElementById("tab2");

const content1 = document.querySelector(".shop_content");
const content2 = document.querySelector(".shop_content2");

// left.addEventListener('click', () => {
//   // console.log(left);
//   content2.classList.remove('dblk');
//   content1.classList.add("dblk");
//   content2.classList.add("secondAnimation");
// });
// right.addEventListener('click', () => {
//   // console.log(right);
//   content1.classList.remove("dblk");
//   content2.classList.add("dblk");
//   content1.classList.add("firstAnimation");
// });

// Back to top button

      //   $(window).scroll(function () {
      //     if ($(this).scrollTop() > 100) {
      //         $('.back-to-top').fadeIn('slow');
      //     } else {
      //         $('.back-to-top').fadeOut('slow');
      //     }
      // });
      // $('.back-to-top').click(function () {
      //     $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
      //     return false;
      // });
      
// account

// let $id = (id) => document.getElementById(id);
// var [login, register, form] = ['login', 'register', 'form'].map(id => $id(id));

// [login, register].map(element => {
//     element.onclick = function () {
//         [login, register].map($ele => {
//             $ele.classList.remove("active");
//         });
//         this.classList.add("active");
//         this.getAttribute("id") === "register"?  form.classList.add("active") : form.classList.remove("active");
//     }
// });
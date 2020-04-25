//collapse
document.getElementById('collapseBtn').onclick = function () {
    this.classList.toggle('btn-light');
    document.getElementById('collapseIcon').classList.toggle('fa-times');
    document.getElementById('wrapper').classList.toggle('slide-down');
}
//scroll
var btn = document.getElementById('btn-to-top');
window.onscroll = function () {
    document.documentElement.scrollTop > 20 ? btn.classList.remove('hidden') : btn.classList.add('hidden');
}
//slide trangloaitin
var slideImg = document.getElementsByClassName('slide-img');
var slideTitle = document.getElementsByClassName('slide-title');
var slideDots = document.getElementsByClassName('dots');
var slideLink = document.getElementById('slide-link');
var links = document.getElementsByName('new-link');
var curentSlide = 0;
function prevSlide() {
    curentSlide = curentSlide > 0 ? curentSlide - 1 : slideImg.length - 1;
    showSlide(curentSlide);
}
function nextSlide() {
    curentSlide = curentSlide < slideImg.length - 1 ? curentSlide + 1 : 0;
    showSlide(curentSlide);
}
function showSlide(that) {
    for (var i = 0; i < slideImg.length; i++) {
        if (i == that) {
            slideImg[i].classList.remove('hidden');
            slideTitle[i].classList.remove('hidden');
            slideLink.setAttribute('href', links[i].value);
            slideDots[i].classList.remove('far');
            slideDots[i].classList.add('fas');
        }
        else {
            slideImg[i].classList.add('hidden');
            slideTitle[i].classList.add('hidden');
            slideDots[i].classList.remove('fas');
            slideDots[i].classList.add('far');
        }
    }
}
setInterval(nextSlide, 3000);

//cookie
var bvdd = document.getElementById('bvdd');
var linkbvdd = document.getElementById('bvddlink');
if (document.cookie != "") {
    var name = "current_read_name=";
    var ca = document.cookie.split(';');
    var c = ca[0];
    var namevalue = c.substr(name.length);
    linkbvdd.innerHTML = namevalue;
    console.log(namevalue);
    name = " current_read_id=";
    c = ca[1];
    var id = c.substr(name.length);
    linkbvdd.setAttribute('href', '/Home/News?bai-viet=' + id);
}
else {
    bvdd.remove();
    console.log(123);
}

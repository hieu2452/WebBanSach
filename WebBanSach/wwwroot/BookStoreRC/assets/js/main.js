const images = ["../BookStoreRC/assets/images/slider1.jpg", "../BookStoreRC/assets/images/slider2.jpg", "../BookStoreRC/assets/images/slider3.jpg"];
const slider = document.querySelector('#slider img');
var i = 0; 
function runSlide(){
    slider.src = images[i];
    i++
    if(i >= images.length){
        i = 0;
    }
} 

setInterval(runSlide, 1500);

const filterBtn = document.querySelector('.filter-btn');
const filterModal = document.querySelector('.filter-modal');
const handleClickFilter = () =>{
    filterModal.style.display = 'block';
    filterModal.style.scroll = 'none';
}
filterBtn.addEventListener('click', handleClickFilter)

window.onkeydown = function(e) {
    if ( e.keyCode == 27 ) {
        filterModal.style.display = 'none';
    }
};

const closeModalBtn = document.querySelector('.close-modal-btn i');
const closeModal = () =>{
    filterModal.style.display = 'none';
}
closeModalBtn.addEventListener('click', closeModal)

const subListBtn = document.querySelectorAll('.title-sidebar');
const subLists = document.querySelectorAll('.item');

//Xử lí sự kiện onClick vào sidebar
subListBtn.forEach(function(list, index){
    var subList = subLists[index];
    list.addEventListener('click', function(){
        subList.classList.toggle('show');
    })
})

//Xử lý nút menu khi dùng trên điện thoại
const menuBtn = document.querySelector('.menu-btn');
const nav = document.querySelector('.nav');

menuBtn.addEventListener('click', ()=>{
    nav.classList.toggle('show');
})

//Xử lí nút scroll top
const searchBtn = document.querySelector('.item-search-btn');
const goToTopBtn = document.querySelector('.btn-scroll-top');

function scrollShow(){
    goToTopBtn.addEventListener('click', ()=>{
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    })

    window.addEventListener('scroll', ()=>{
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            goToTopBtn.style.display = "block";
          } else {
            goToTopBtn.style.display = "none";
          }
    })
}
scrollShow();
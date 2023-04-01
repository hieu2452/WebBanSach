//Xử lí hình ảnh trong infoProduct
const images = [
    './assets/images/empty_cart.png', 
    './assets/images/item1.jpg', 
    './assets/images/empty_cart.png', 
    './assets/images/item1.jpg'
]

const prevBtn = document.querySelector('.bx-chevron-left');
const nextBtn = document.querySelector('.bx-chevron-right');
const imgMain = document.querySelector('.img-main img');

var i = 0;
//Hàm next
function nextImage(){
    imgMain.src = images[i];
    i++;
    if(i >= images.length){
        i=0;
    }
}

var j = images.length - 1;

//Hàm prev
function prevImage(){
    imgMain.src = images[j];
    j--;
    if(j <= - 1){
        j=images.length - 1;
    }
}
//Khi click vào nút next thì ảnh sẽ chuyển tiếp
nextBtn.addEventListener('click', nextImage);
//Khi click vào nút prev thì ảnh sẽ quay lại
prevBtn.addEventListener('click', prevImage);

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
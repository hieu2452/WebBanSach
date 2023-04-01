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
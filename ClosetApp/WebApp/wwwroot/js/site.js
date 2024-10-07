// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const body = document.querySelector('body');

if (body.classList.contains('home-page')) {

    let slideIndex = 1;
    showSlides(slideIndex);

    // Next/previous controls
    function plusSlides(n) {
        showSlides(slideIndex += n);
    }

    // Thumbnail image controls
    function currentSlide(n) {
        showSlides(slideIndex = n);
    }

    function showSlides(n) {
        let i;
        let slides = document.getElementsByClassName("mySlides");
        if (n > slides.length) { slideIndex = 1 }
        if (n < 1) { slideIndex = slides.length }
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slides[slideIndex - 1].style.display = "block";
    }

    let slideIndex1 = 1;
    showSlides1(slideIndex1);

    // Next/previous controls
    function plusSlides1(n1) {
        showSlides1(slideIndex1 += n1);
    }

    // Thumbnail image controls
    function currentSlide1(n1) {
        showSlides1(slideIndex1 = n1);
    }

    function showSlides1(n1) {
        let i1;
        let slides1 = document.getElementsByClassName("mySlides1");
        if (n1 > slides1.length) { slideIndex1 = 1 }
        if (n1 < 1) { slideIndex1 = slides1.length }
        for (i1 = 0; i1 < slides1.length; i1++) {
            slides1[i1].style.display = "none";
        }
        slides1[slideIndex1 - 1].style.display = "block";
    }
}


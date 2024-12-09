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

    function CSharpFunction1() {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/Index?handler=CSharpFunction1", true);  // Adjust the URL as necessary
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        // Send the request
        xhr.send();

        xhr.onload = function () {
            if (xhr.status == 200) {
                alert("C# function called successfully!");
            } else {
                alert("Error calling C# function");
            }
        };
    }

    function CSharpFunction2() {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/Index?handler=CSharpFunction2", true);  // Adjust the URL as necessary
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        // Send the request
        xhr.send();

        xhr.onload = function () {
            if (xhr.status == 200) {
                alert("C# function called successfully!");
            } else {
                alert("Error calling C# function");
            }
        };
    }

    function CSharpFunction3() {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/Index?handler=CSharpFunction3", true);  // Adjust the URL as necessary
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        // Send the request
        xhr.send();

        xhr.onload = function () {
            if (xhr.status == 200) {
                alert("C# function called successfully!");
            } else {
                alert("Error calling C# function");
            }
        };
    }

    function CSharpFunction4() {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/Index?handler=CSharpFunction4", true);  // Adjust the URL as necessary
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        // Send the request
        xhr.send();

        xhr.onload = function () {
            if (xhr.status == 200) {
                alert("C# function called successfully!");
            } else {
                alert("Error calling C# function");
            }
        };
    }

    document.getElementById('outfitButton').addEventListener('click', function (event) {
        event.preventDefault();
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/Index?handler=MakeOutfit", true);
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onload = function () {
            if (xhr.status >= 200 && xhr.status < 300) {
                alert('Success: ' + xhr.responseText);
            } else {
                alert('Error: ' + xhr.status + ' ' + xhr.statusText);
            }
        };
        xhr.onerror = function () {
            alert('Request failed');
        };

        xhr.send();
    });
    

    function onClickHandler1() {
        plusSlides(-1);  // Calling the JavaScript function
        CSharpFunction1();    // Calling the C# function by submitting the form
    }
    function onClickHandler2() {
        plusSlides(1);  // Calling the JavaScript function
        CSharpFunction2();    // Calling the C# function by submitting the form
    }
    function onClickHandler3() {
        plusSlides1(-1);  // Calling the JavaScript function
        CSharpFunction3();    // Calling the C# function by submitting the form
    }
    function onClickHandler4() {
        plusSlides1(1);  // Calling the JavaScript function
        CSharpFunction4();    // Calling the C# function by submitting the form
    }
}
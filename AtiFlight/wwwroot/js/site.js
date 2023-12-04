$(document).ready(function () {
    // Seçenekler arasında geçiş yapılınca
    $("#option1").click(function () {
        $("#option1").addClass("ActiveOption");
        $("#option2").removeClass("ActiveOption");
        $("#content1").removeClass("NonActiveContent");
        $("#content1").addClass("ActiveContent");
        $("#content2").removeClass("ActiveContent");
        $("#content2").addClass("NonActiveContent");
    });

    $("#option2").click(function () {
        $("#option2").addClass("ActiveOption");
        $("#option1").removeClass("ActiveOption");
        $("#content1").removeClass("ActiveContent");
        $("#content2").removeClass("NonActiveContent");
        $("#content1").addClass("NonActiveContent");

        $("#content2").addClass("ActiveContent");
    });
});


    let menuToggle = document.querySelector('.toggle');
    let navigation = document.querySelector('.navigation');
    menuToggle.onclick = function () {
        menuToggle.classList.toggle('Active');
    navigation.classList.toggle('Active');



        }
    let list = document.querySelectorAll('.list');
    for (let i = 0; i < list.length; i++) {
        list[i].onclick = function () {

            let j = 0;
            while (j < list.length) {

                list[j++].className = 'list';



            }
            list[i].className = 'list active';
        }

    }


    
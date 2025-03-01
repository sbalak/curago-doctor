$(document).ready(function () {
    $("#registerInterestSuccess").hide();
    $("#registerInterestFailure").hide();

    $('#registerInterest').click(function () {
        $('#registerInterest').addClass('disabled');
        $.ajax({
            url: '/account/register/',
            type: 'POST',
            dataType: 'json',
            data: { 'firstName': $("#firstName").val(), 'lastName': $("#lastName").val(), 'phone': $("#phone").val(), 'primarySpecialityId': $("#secondarySpecialityId").val(), 'secondarySpecialityId': $("#secondarySpecialityId").val(), 'experience': $("#experience").val() },
            success: function (result) {
                if (result) {
                    $("#registerInterestSuccess").show();

                    $("#firstName").val('');
                    $("#lastName").val('');
                    $("#phone").val('');
                    $("#primarySpecialityId").val('');
                    $("#secondarySpecialityId").val('');
                    $("#experience").val('');

                    setTimeout(() => {
                        $("#registerInterestSuccess").hide();
                    }, 5000);

                    $('#registerInterest').removeClass('disabled');
                }
                else {
                    $("#registerInterestFailure").show();

                    setTimeout(() => {
                        $("#registerInterestFailure").hide();
                    }, 5000);

                    $('#registerInterest').removeClass('disabled');
                }
            },
            error: function (err) {
                $("#registerInterestFailure").show();

                setTimeout(() => {
                    $("#registerInterestFailure").hide();
                }, 5000);

                $('#registerInterest').removeClass('disabled');
            }
        });
    });
});
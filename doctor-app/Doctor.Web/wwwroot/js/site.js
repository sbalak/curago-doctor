$(document).ready(function () {
    $("#registerInterestSuccess").hide();
    $("#registerInterestFailure").hide();

    $('#signUpBtn').click(function () {
        $('#signUpBtn').addClass('disabled');
        $.ajax({
            url: '/account/register/',
            type: 'POST',
            dataType: 'json',
            data: { 'firstName': $("#firstName").val(), 'lastName': $("#lastName").val(), 'phone': $("#phone").val(), 'specialityId': $("#specialityId").val(), 'postCode': $("#postCode").val(), 'experience': $("#experience").val(), 'registerInterest': $("#registerInterest").val() },
            success: function (result) {
                if (result) {
                    $("#registerInterestSuccess").show();

                    $("#firstName").val('');
                    $("#lastName").val('');
                    $("#phone").val('');
                    $("#specialityId").val('');
                    $("#postCode").val('');
                    $("#experience").val('');
                    $("#registerInterest").val('');

                    setTimeout(() => {
                        $("#registerInterestSuccess").hide();
                    }, 5000);

                    $('#signUpBtn').removeClass('disabled');
                }
                else {
                    $("#registerInterestFailure").show();

                    setTimeout(() => {
                        $("#registerInterestFailure").hide();
                    }, 5000);

                    $('#signUpBtn').removeClass('disabled');
                }
            },
            error: function (err) {
                $("#registerInterestFailure").show();

                setTimeout(() => {
                    $("#registerInterestFailure").hide();
                }, 5000);

                $('#signUpBtn').removeClass('disabled');
            }
        });
    });
});
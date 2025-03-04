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
                if (result.status == "success") {
                    $("#registerInterestFailure").hide();
                    $("#registerInterestSuccess").html(result.message);
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
                    }, 7500);

                    $('#signUpBtn').removeClass('disabled');
                }
                else if (result.status == "failure") {
                    $("#registerInterestSuccess").hide();
                    $("#registerInterestFailure").html(result.message);
                    $("#registerInterestFailure").show();

                    setTimeout(() => {
                        $("#registerInterestFailure").hide();
                    }, 7500);

                    $('#signUpBtn').removeClass('disabled');
                }
            },
            error: function (err) {
                $("#registerInterestSuccess").hide();
                $("#registerInterestFailure").html('Error! Something went wrong. Please try again later.');
                $("#registerInterestFailure").show();

                setTimeout(() => {
                    $("#registerInterestFailure").hide();
                }, 7500);

                $('#signUpBtn').removeClass('disabled');
            }
        });
    });
});
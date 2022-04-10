
var RegistrationInputs = ["ConfirmPassword", "Password", "Email", "gender", "LastName", "FirstName"];

$(function () {
    $("#SubmitRegistrationData").click(function (evt) {
        evt.preventDefault();
        RegisterUser();
    });

    $("form[name='registration']").validate({
        errorContainer: "#ErrorBox",
        errorLabelContainer: "#ErrorBox ul",
        wrapper: "li",
        errorClass: "is-invalid",
        validClass: "is-valid",
        // Specify validation rules
        rules: {
            FirstName: "required",
            Email: {
                required: true,

                email: true
            },
            Password: {
                required: true,
                minlength: 5
            },
            ConfirmPassword: {
                equalTo: "#Password",
                required: true,
                minlength: 5
            }
        },
        // Specify validation error messages
        messages: {
            FirstName: "Please enter your FistName",
            Password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            },
            ConfirmPassword: {
                required: "Password confirmation Required",
                minlength: "Your password must be at least 5 characters long",
                equalTo: "Passwords Do not match",
            },
            Email: "Please enter a valid email address"
        },

    });
});
function GetRegistrationSaveData() {
    var saveData = GetFormInputValues(RegistrationInputs);

    return saveData;
}
function ValidateAndSaveUserData() {
    var validation = $("form[name='registration']").validate(


    );
    return $("form[name='registration']").valid();
}



function RegisterUser() {
    if (ValidateAndSaveUserData()) {
        var saveData = GetRegistrationSaveData();
        ShowLoading();
        PageMethod.RegisterUser(saveData, function (response) {
            console.log(response);
            if (response) {
                if (response.message) {
                    ShowMessageBox(response.message);
                }
                if (response.success) {
                    GotToLogin();
                }
            }

            HideLoading();
        });
    }
}


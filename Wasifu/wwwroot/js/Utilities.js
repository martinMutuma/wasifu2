

var MessageModal = null;
$(function () {

    $(function () {
        var modalOptions = { backdrop: "static", keyboard: true, focus: true };
        MessageModal = new bootstrap.Modal(document.getElementById('MessageBoxModal'), modalOptions);
    });

})
function GetFormInputValues(inputIds) {
    var formData = {};
    inputIds.forEach(function (inputId) {
        formData[inputId] = GetInputValue(inputId);
    });
    return formData;
}

function GetInputValue(Id) {
    var inputElm = GetElement(Id);

    var inputVal = null;
    if (inputElm) {
        inputVal = inputElm.val();
    }
    return inputVal;
}

function GetElement(Id) {
    var element = $("#" + Id);
    if (element.length > 0) {
        if (element.attr("type") == 'radio') {
            element = $("#" + Id + ":checked");
        }

        return element;
    }
    return null;
}

function ShowLoading() {
    var loader = getLoader();
    loader.show();
}

function HideLoading() {
    var loader = getLoader();
    loader.hide();
}

function getLoader() {
    var spinner = $('#Pageloader');

    return spinner;
}

function ShowMessageBox(Message, Title) {
    if (MessageModal) {
        MessageModal.show();
        if (Message) {
            $("#popupMessagebox").text(Message);
        }
        if (Title) {
            $("#popupMessageboxHeader").text(Title);
        }
    }
}

function HideMessageBox() {
    if (MessageModal) {
        MessageModal.hide();
        $("#popupMessagebox").text("");
        $("#popupMessageboxHeader").text("Info");
    }
}

function GotToLogin() {
    ShowLoading();
    ShowMessageBox("Redirectiong to Login");
    setTimeout(function () {
        window.location = "/Logout";
    }, 1000);
}
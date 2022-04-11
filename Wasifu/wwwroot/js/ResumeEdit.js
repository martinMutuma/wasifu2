var idSubClass = 1;
$(function () {


    tinymce.init({
        selector: 'textarea.form-control',
        menubar: false
    });

    $("#AddEmploymentHistory").click(function (evt) {
        evt.preventDefault();
        CloneEmployementHistory();
    })
});

function CloneEmployementHistory() {
    idSubClass += 1;
    var elmennt = $("#JobTitle1").clone();
    elmennt.attr("id", function (_, val) {
      
        return val + '_' + idSubClass;
    });
    elmennt.find("*").attr("id", function (_, val) {
        if (val) {
            return val + '_' + idSubClass;
        }
        return val;
    });
    elmennt.find("*").attr("data-bs-parent", function (_, val) {
        if (val) {
            return val + '_' + idSubClass;
        }
        return val;
    });
    elmennt.find("*").attr("aria-labelledby", function (_, val) {
        if (val) {
            return val + '_' + idSubClass;
        }
        return val;
    });
    elmennt.find("*").attr("data-bs-target", function (_, val) {
        if (val) {
            return val + '_' + idSubClass;
        }
        return val;
    });
    var Holder = $("#EmploymentHistoryBodyHolder");
    console.log(elmennt);
    Holder.append(elmennt);
}
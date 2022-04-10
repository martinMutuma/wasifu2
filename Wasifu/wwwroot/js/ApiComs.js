
function ApiPost(postUrl, Data, callBack) {
    return $.post(postUrl, Data, function (resp) {
        if (typeof callBack == "function") {
            callBack(resp);
        }
    });
}



var PageMethod = {
    RegisterUser: function (loginDto, callBack) {
        return ApiPost("/Register", { loginDto: loginDto }, callBack);
    },
};



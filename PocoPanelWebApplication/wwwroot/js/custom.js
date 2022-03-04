/**
 *
 * You can write your JS code here, DO NOT touch the default style file
 * because it will make it harder for you to update.
 *
 */

"use strict";

//-- Start Region Register --
$("#agree").click(function () {
    $("#btnRegister").attr("disabled", !this.checked);
});
//-- End Region Register --


//-- Start Region Copy Button --
$(function () {
    $(".btnCopyToClipBoard").click(function () {
        $(this).addClass("onclic", 250, validate(this));
    });

    function validate(item) {
        setTimeout(function () {
            $(item).removeClass("onclic");
            $(item).addClass("validate", 450, callback(item));
        }, 2250);
    }

    function callback(item) {
        setTimeout(function () {
            $(item).removeClass("validate");
        }, 1250);
    }
});

// Copy To Clipboard Main Code
function copyToClipboard(element) {
    $(element).select();
    document.execCommand("copy");
}
//-- End Region Copy Button --

//-- Region Loader --
function ShowLoader() {
    document.getElementById("Loader").style.display = "flex";
}

function HideLoader() {
    document.getElementById("Loader").style.display = "none";
}
//-- End Region Loader --
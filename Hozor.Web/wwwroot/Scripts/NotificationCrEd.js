var DivIsFile = document.getElementById('DivIsFile');
var DivIsText = document.getElementById('DivIsText');

var isFile = document.getElementById('IsFile');
var isText = document.getElementById('IsText');

DivIsFile.style.display = "none";
DivIsText.style.display = "none";

checkFile();
checkText()


isFile.onchange = checkFile;
function checkFile() {
    if (isFile.checked) {
        DivIsFile.style.display = "";
    }
    else {
        DivIsFile.style.display = "none";
    }
}

isText.onchange = checkText;
function checkText() {
    if (isText.checked) {
        DivIsText.style.display = "";
    }
    else {
        DivIsText.style.display = "none";
    }
}
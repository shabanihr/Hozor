if (document.forms["filterForm"]["showFilter"].value) {
    document.getElementById('show-search').style.display = "";
}
else {
    document.getElementById('show-search').style.display = "none";
}

function ShowSearch() {

    if (document.getElementById('show-search').style.display == "none") {
        document.getElementById('show-search').style.display = "";
    }
    else {
        document.getElementById('show-search').style.display = "none";
    }

}
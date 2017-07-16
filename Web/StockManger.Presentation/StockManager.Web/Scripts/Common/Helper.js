
function html2text(html) {
    var tag = document.createElement('div');
    tag.innerHTML = html;
    return tag.innerText;
}


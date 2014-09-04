function getValueAttributes(elem, valueAttributes) {
    if (elem.value == "" || elem.value.length > 10 || elem.value[0] != "g")
        return;
    else {
        valueAttributes.push(elem.value);
    }
}

function getNodeValues(elem, nodeValues) {
    if (elem.value == "" || elem.value.length > 10 || elem.value[0] != "g")
        return;
    else {
        nodeValues.push(elem.innerText);
    }
}

function getInfoForDb() {
    var elems = document.getElementsByTagName("option");
    var valueAttributes = [];
    var nodeValues = [];
    var result = [];
    for (var i = 0; i < elems.length; i++) {
        getValueAttributes(elems[i], valueAttributes);
        getNodeValues(elems[i], nodeValues);
    }
    result.push(nodeValues);
    result.push(valueAttributes);
    return result;
}

getInfoForDb();
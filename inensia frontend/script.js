async function CreateTable(){

    let xml = await fetch("https://test.ce2s.net/Study.xml")
    .then(response => response.text())
    // .then(str => str.parseFromString(str, "text/xml"))
    .then(xml => {
        //console.log(xml)
        let parser = new DOMParser();
        let xmlDom = parser.parseFromString(xml, 'application/xml')
        let a = xmlDom.evaluate('/Result/Item/name', xmlDom, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
       // console.log(a.textContent)
        return xmlDom;
    })
    .catch(ex => ex.message);

//get values from XML using xPath
let sysElement = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item[2]/Relationships/Item/keyed_name', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;
 
let sysElementItem ='Mirror1';
let edcUsed = 'Surface Offset 1';
let elemRequirement = '1CB7975079AA472A8E1B380FA808AE8F';
let conditionExpression = 'val > 0.25';

let reqTitle = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/req_title', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

let systemUsed = xml.evaluate('/Result/Item/name', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

let studyName = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/name', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;


let studyState = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/state', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

let task = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/keyed_name', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

let resultName = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships//Item/Relationships/Item/ar_resultname', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

let resultValue = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships//Item/Relationships/Item/ar_resultvalue', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

let resultUnit = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/ar_resultunit', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

let targetMet = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/ar_target_met', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

let resultConditionExpression = xml.evaluate('/Result/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/Relationships/Item/ar_conditionexp', xml, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;

//create an array with fetched data
const fetchedDataArray = [
    sysElement,
    sysElementItem,
    edcUsed,
    elemRequirement,
    conditionExpression,
    reqTitle,
    systemUsed,
    studyName,
    studyState,
    task,
    resultName,
    resultValue,
    resultUnit,
    targetMet,
    resultConditionExpression
];

//create an array with table columns 
    let columnsArray = [
        'SysElement',
        'Sys Element Item',
        'Edc used',
        'Elem Requirement',
        'Condition Expression',
        'Req Title',
        'System used',
        'Study name',
        'Study state',
        'Task',
        'Result name',
        'Result value',
        'Result unit',
        'Target Met',
        'Result Condition Expression',
    ];

    //create table
    let container = document.getElementById('container');
    let table = document.createElement('table');
    table.setAttribute('id', 'table');
    table.className = 'table';
    let thead = document.createElement('thead');
    let tbody = document.createElement('tbody');

    container.appendChild(table);
    table.appendChild(thead);
    table.appendChild(tbody);

    let tableHeadRow = document.createElement('tr');
    tableHeadRow.setAttribute('id','head-row');
    thead.appendChild(tableHeadRow);

    //create table body
    let tableBodyRow = document.createElement('tr');
    tableBodyRow.setAttribute("id", "body-row");
    tbody.appendChild(tableBodyRow);

  //add columns to table head and cells to table body
  for (let index = 0; index < columnsArray.length; index++) {
    let thElement = document.createElement('th');
    thElement.className = 'cell';
    thElement.textContent = columnsArray[index];
    tableHeadRow.appendChild(thElement);

    let tdElement = document.createElement('td');
    tdElement.className = 'cell';
    tdElement.textContent = fetchedDataArray[index];
    tableBodyRow.appendChild(tdElement);
}



}

CreateTable();
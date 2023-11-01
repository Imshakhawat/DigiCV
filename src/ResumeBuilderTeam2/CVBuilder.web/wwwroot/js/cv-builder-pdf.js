// A $( document ).ready() block.
$(document).ready(function () {
    
// javaScript PDf Converter

const pdf = document.getElementById('pdfdownload');
window.jsPDF = window.jspdf.jsPDF;

let elementHTML = document.querySelector(".mkp_container");
const addRemoveIcon = document.querySelectorAll('.social-media-add-remove');
const hidcvEditable = document.querySelector('#cvEditable');
const hidfooter = document.querySelector('.mkp__footer');


function AddRemoveButtonShow() {
    addRemoveIcon.forEach(function (v) {
        // console.log('hello')
        v.style.display = 'none';
    })
}



pdf.addEventListener('click', function (ev) {
    ev.preventDefault();
    elementHTML.style.width = '78vw';
    
    hidfooter.style.display = 'none';
    AddRemoveButtonShow();
    let doc = new jsPDF();
    // Source HTMLElement or a string containing HTML.
    doc.html(elementHTML, {
        callback: function (doc) {
            // Save the PDF
            doc.save('document-html.pdf');
        },
        margin: [10, 10, 10, 10],
        autoPaging: 'text',
        x: 0,
        y: 0,
        width: 120, //target width in the PDF document
        windowWidth: 700 //window width in CSS pixels
    });

    elementHTML.style.width = '86vw';
    hidcvEditable.style.display = 'block';
    hidfooter.style.display = 'block';

});



  

});






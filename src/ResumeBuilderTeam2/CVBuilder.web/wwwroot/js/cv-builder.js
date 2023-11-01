// A $( document ).ready() block.
$(document).ready(function () {
    let editable = document.querySelectorAll('.editable');
    function getsocialMedia() {
        let socailName = document.querySelectorAll('.socialName');
        let sociallink = document.querySelectorAll('.sociallink');
        let socialMeida = [];
        for (let socialIcon = 0; socialIcon < sociallink.length; socialIcon++) {
            //debugger
            let icon = socailName[socialIcon].innerText;
            let name = sociallink[socialIcon].innerText;
            socialMeida.push({ SocialMediaName: icon, LinkOrText: name });
        }
        return socialMeida;
    }

    function getProfessionalSummary() {
        let professionalHeading = document.querySelector('.professional-heading');
        let professionaltext = document.querySelector('.professionaltext');
        const summary = {
            Title: professionalHeading.innerText,
            ProfessionalSummaryText: professionaltext.innerText
        }
        return summary;
    }


    function getProfessionalSkill() {
        let skill = document.querySelector('.skills');
        let skillList = document.querySelectorAll('.skill-list li');
        const skillItem = [];
        for (let i = 0; i < skillList.length; i++) {
            let skillName = skillList[i].innerText;
            skillItem.push(skillName)
        }
        return skillItem;
    }

    function getWorkingExperience() {
        let postion = document.querySelectorAll('.position')
        let companys = document.querySelectorAll('.companyName');
        let workingYears = document.querySelectorAll('.yorking-year');
        let workingTools = document.querySelectorAll('.workingTools li');
    
        //let pattentsAll =  Array.form( document.querySelectorAll('.mkp__repeact__content'));
        //     debugger
        const WorkingExperince = [];
        let countForNestLopping = 0;

        //for (let kk = 0; kk < pattentsAll.length; kk++) {
        //    for (let kj = 0; kj < pattentsAll[kk].length; kj++) {
        //        console.log(pattentsAll[kk][kj]);
        //    }
        //}

        for (let i = 0; i < postion.length; i++) {
      
            let positionName = postion[i].innerText;
            let companyName = companys[i].innerText;
            let workingYear = workingYears[i].innerText;
            let Tools = [];

            let childElements = document.querySelectorAll('.position')[i].nextElementSibling.nextElementSibling.nextElementSibling;

            for (let ik = 0; ik < childElements.children.length; ik++) {
              //  console.log(childElements.children[ik], "check data")
                Tools.push({ item: childElements.children[ik].innerText });
            }

            //for (let j = 0; j < workingTools.length; j++) {
            ////for (let j = 0; j < pattentsAll[i].children[0].children[3]; j++) {
            //    //    debugger;
            //    //console.log("Test Data ", pattentsAll[i].children[0].children[3])
            //    let workingTool = workingTools[j].innerText;
            //    Tools.push({ item: workingTool });
            //}
            // countForNestLopping += positionName.length;
            WorkingExperince.push({
                JobTitle: positionName,
                Company: companyName,
                StartDate: workingYear,
                Description: Tools
            })
            //need review
        }
        return WorkingExperince;
    }


    function getPersonalAndIndustrialProject() {
        let projects = [];
        let project = document.querySelector('.project');
        let projectPersonal = document.querySelector('.projectPersonal');
        let projecDscription = document.querySelector('.projecDscription');
        let projectCompanys = document.querySelectorAll('.projectCompany');
        let projectCompanyDescriptions = document.querySelectorAll('.projectCompanyDescription');

        for (let i = 0; i < projectCompanys.length; i++) {
            let projectCompany = projectCompanys[i].innerText;
            let projectCompanyDescription = projectCompanyDescriptions[i].innerText;
            projects.push({
                ProjectType: project.innerText,
                projectPersonal: projectPersonal.innerText,
                //Description: projecDscription.innerText,
                Title: projectCompany,
                //projectCompanyDescription: projectCompanyDescription
                Description: projectCompanyDescription
            })
            //need review
        }
        return projects;
    }
    function getReference() {
        let reffenceDesig = document.querySelectorAll('.reffenceDesig');
        let reffenceName = document.querySelectorAll('.reffenceName');
        const refference = [];
        for (let i = 0; i < reffenceDesig.length; i++) {
            let designation = reffenceDesig[i].innerText;
            let name = reffenceName[i].innerText;
            refference.push({ Designation: designation, Name: name });
        }
        return refference;
    }

    function getEducation() {
        const education = [];
        let subjects = document.querySelectorAll('.subject');
        let passingYears = document.querySelectorAll('.passing-year');
        for (let i = 0; i < subjects.length; i++) {
            let subject = subjects[i].innerText;
            let passingYear = passingYears[i].innerText;
            education.push({ Institution: subject, GraduationYear: passingYear })
        }
        return education;
    }

    function getTraining() {
        let training = document.querySelectorAll('.professionTraining li');
        const trains = [];
        for (let i = 0; i < training.length; i++) {
            trains.push({ TrainingCourses: training[i].innerText })
        }
        return trains;
    }

    const hideAddRemoveButton = document.querySelectorAll('.social-media-add-remove');

    function SaveAndUpdateResumeData(actionController, el) {
        editable.forEach(function (el) {
            el.setAttribute('contenteditable', 'false');
            el.style.border = 'none';
            el.style.padding = '0px';
            //console.log("clicked edit button");
        })
        
        //console.log($(location).attr('href'));
        hideAddRemoveButton.forEach(function (val) {
            val.style.display = 'none';
        })

        let yourCvName = document.querySelector('.yourCvName');
        let name = document.querySelector('.cvName');
        let email = document.querySelector('.email');
        let mobile = document.querySelector('.mobile');
        let address = document.querySelector('.address');
        //let imageData = document.querySelector('#display_image_data');
        let imageData = document.querySelector('#image-uploadd').src;
        let img = imageData.split('/');
        let fileName = img[4];

        const socialMeida = getsocialMedia();
        // professional sumarray 
        const summary = getProfessionalSummary();
        const skillItem = getProfessionalSkill();
        // language framework and tools
        //  working expericene
        const WorkingExperince = getWorkingExperience();
        // Personal and industrial project
        const projects = getPersonalAndIndustrialProject();
        // profesional Traing
        const trains = getTraining();
        // education
        const education = getEducation();
        //  referece
        const refference = getReference();
        //const urlget = $(location).attr('href')
        const urlget = location.href;

        const Data = {
            ResumeName: yourCvName.innerText,
            name: name.innerText,
            email: email.innerText,
            Url: location.search,
            //ImageURL: imageData,
            ImageURL: fileName,
            mobile: mobile.innerText,
            SocialMediaList: socialMeida,
            Skills: skillItem,
            WorkExperiences: WorkingExperince,
            Projects: projects,
            Education: education,
            References: refference,
            ProfessionalSummary: summary,
            Trainning: trains
        }
        console.log(Data);
        return Data;

    }

$("#saveData").click(function (ev) {
    ev.preventDefault();
    let Data = SaveAndUpdateResumeData("Resume/CVBuilderAdd", ev);

    try {

        $.ajax({
            type: "POST",
            url: "Resume/CVBuilderAdd",

            data: Data,
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            success: function (msg) {
                //debugger;
                window.alert(msg)
                console.log(msg);
                $.toast({
                    heading: 'Success',
                    text: msg,
                    showHideTransition: 'slide',
                    icon: 'success'
                })

            },
            error: function (xhr, status, errorThrown) {
                debugger;
                console.log(xhr);
            }
        })
    } catch (error) {
        console.log(error);
    }
});

$("#saveDataUpdate").click(function (ev) {
    
    try {
        ev.preventDefault();

    let Datas = SaveAndUpdateResumeData("", ev);
       // debugger
   
        $.ajax({
            type: "POST",
            url: "/UpdateRemuseData",
            data: Datas,
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            success: function (msg) {

              //  alert(msg)
                window.alert(msg)
                console.log(msg);
                $.toast({
                    heading: 'Success',
                    text: msg,
                    showHideTransition: 'slide',
                    icon: 'success'
                })
                console.log(msg);
            }, 
            error: function (xhr, status, errorThrown) {
                //Here the status code can be retrieved like;
                debugger
                xhr.status;
                console.log(xhr);

                //The message added to Response object in Controller can be retrieved as following.
                xhr.responseText;
            }
            
        });

    } catch (ex) {
       
        console.log(ex);
    }
});



// image croping and download 

$("body").on("change", "#browse_image", function (e) {
    var files = e.target.files;
    var done = function (url) {
        $('#display_image_div').html('');
        $("#display_image_div").html(` <img name = "display_image_data"
                  id = "display_image_data"
                  src = "${url}"
                  alt = "Uploaded Picture"> `);
    };

    if (files && files.length > 0) {
        file = files[0];
        if (URL) {
            done(URL.createObjectURL(file));
        } else if (FileReader) {
            reader = new FileReader();
            reader.onload = function (e) {
                done(reader.result);
            };
            reader.readAsDataURL(file);
        }
    }

    var image = document.getElementById('display_image_data');
    var button = document.getElementById('crop_button');
    var result = document.getElementById('cropped_image_result');
    var croppable = false;
    var cropper = new Cropper(image, {
        aspectRatio: 1,
        viewMode: 1,
        ready: function () {
            croppable = true;
        },
    });
    button.onclick = function () {
        var croppedCanvas;
        var roundedCanvas;
        var roundedImage;
        if (!croppable) {
            return;
        }
        // Crop
        croppedCanvas = cropper.getCroppedCanvas();
        // Round
        roundedCanvas = getRoundedCanvas(croppedCanvas);
        // Show
        roundedImage = document.createElement('img');
        roundedImage.src = roundedCanvas.toDataURL()
        result.innerHTML = '';
        result.appendChild(roundedImage);
    };
});

function getRoundedCanvas(sourceCanvas) {
    var canvas = document.createElement('canvas');
    var context = canvas.getContext('2d');
    var width = sourceCanvas.width;
    var height = sourceCanvas.height;
    canvas.width = width;
    canvas.height = height;
    context.imageSmoothingEnabled = true;
    context.drawImage(sourceCanvas, 0, 0, width, height);
    context.globalCompositeOperation = 'destination-in';
    context.beginPath();
    context.arc(width / 2, height / 2, Math.min(width, height) / 2, 0, 2 * Math.PI, true);
    context.fill();
    return canvas;
}
$('#download_button').click(function (ev) {
    ev.preventDefault();
    download();

})

function download() {
    var linkSource = $('#cropped_image_result img').attr('src');
    var fileName = 'download.png';
    const downloadLink = document.createElement("a");
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
}

$('#upload_button').click(function (ev) {
    ev.preventDefault();
    upload();
})

function upload() {
    var base64data = $('#cropped_image_result img').attr('src');
    //alert(base64data);
    // debugger;

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "Resume/ImageUpload",
        data: {
            image: base64data
        },
        success: function (response) {
            console.log(response);
        //   debugger;
            ////  if (response.status ) {
            //console.log(response);
            $("#image-uploadd").attr("src", location.origin + "/images/" + response);
            // update message
            $.toast({
                heading: 'Success',
                text: 'Image has been uploaded Successfull',
                showHideTransition: 'slide',
                icon: 'success'
            });

            //   alert(response.msg);
            //  } else {
            // alert("Image not uploaded.");
            // }
        }
    });
}

// javaScript PDf Converter

    $('#upload_button2').click(function (ev) {
        ev.preventDefault();
        upload2();
    })
    function upload2() {
        var base64data = $('#cropped_image_result img').attr('src');
        //alert(base64data);
        // debugger;

        $.ajax({
            type: "POST",
            dataType: "json",
            url: "ImageUpload",
            data: {
                image: base64data
            },
            success: function (response) {
                console.log(response);
                //debugger;
                ////  if (response.status ) {
                //console.log(response);
                $("#image-uploadd").attr("src", location.origin + "/images/" + response);
                // update message
                $.toast({
                    heading: 'Success',
                    text: 'Image has been uploaded Successfull',
                    showHideTransition: 'slide',
                    icon: 'success'
                });

                //   alert(response.msg);
                //  } else {
                // alert("Image not uploaded.");
                // }
            }
        });
    }


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
    hidcvEditable.style.display = 'none';
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



function singleuserData() {

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "Resume/GetCVByUserIdWithTemplateId",
        success: function (response) {
            console.log(response);
            $.toast({
                heading: 'Success',
                text: 'PDF Download Success',
                showHideTransition: 'slide',
                icon: 'success'
            });

        }
    });
}

    //setTimeout(function () {
    //    singleuserData();
    //}, 5000);
  

});






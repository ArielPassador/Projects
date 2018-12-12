function ExecVcard(firstName, mobileNumber, foneNumber, userMail, postOffice, company, address){
    
    var cardTemplate = {
        v3: `BEGIN:VCARD
VERSION:3.0
N:Gump;Forrest;;Mr.;
FN:Forrest Gump
ORG:Bubba Gump Shrimp Co.
TITLE:Shrimp Man
TEL;TYPE=WORK,VOICE:(111) 555-1212
TEL;TYPE=HOME,VOICE:(404) 555-1212
ADR;TYPE=WORK,PREF:;;100 Waters Edge;Baytown;LA;30314;United States of America
ADR;TYPE=HOME:;;42 Plantation St.;Baytown;LA;30314;United States of America
EMAIL;WORK;INTERNET:forrestgump@example.com
END:VCARD`,
        vDefault: `BEGIN:VCARD
VERSION:2.1
N;CHARSET=utf-8:`+ firstName + `
FN;CHARSET=utf-8:`+ firstName + `
ORG;CHARSET=utf-8:`+ company + `
TEL;WORK;VOICE:`+ foneNumber + `
TEL;HOME;VOICE:`+ mobileNumber + `
ADR;WORK;PREF;CHARSET=utf-8:;; `+ address + `
EMAIL;WORK;INTERNET:`+ userMail + `
END:VCARD`
    };
    
    renderQR(cardTemplate["vDefault"]);
}


function renderQR (text) {
  $('#qrcode').html('')
  $('#qrcode').qrcode({
    width: 250,
    height: 250,
    text: text
  })
};



var firstName = document.getElementById("firstName");
var mobileNumber = document.getElementById("mobileNumber");
var foneNumber = document.getElementById("foneNumber");
var userMail = document.getElementById("userMail");
var postOffice = document.getElementById("postOffice");
var company = document.getElementById("company");
var address = document.getElementById("address");

var btn = document.getElementById("btnVcard");

btn.onclick = function(){
    ExecVcard(firstName.value, mobileNumber.value, foneNumber.value, userMail.value, postOffice.value, company.value, address.value);
}

//ExecVcard("ARIEL ROMERO PASSADOR", "(43) 984544620", "(43) 33367512", "lopesluiz_@hotmail.com", "ENGENHEIRO", "GELT", "Rua Dr. Vicente Machado; Londrina; PR; 160; Brasil")
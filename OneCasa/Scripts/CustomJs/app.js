let months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
$.ajax({
        url: "/Home/GetUpcomingBirthDays",
        method:"GET",
        dataType: "Json",
        success: function (response) {
            let html=``;
        if(response.length!=0){
            $.each(response, function (indexInArray, valueOfElement) { 
                let d=new Date(parseInt(  valueOfElement.DateOfBirth.replace('/Date(', '')));
                 html+=`<li> <img src="../../Content/Images/birthday.png" alt="png" width=20px height=20px>
                 ${valueOfElement.EmpName} BirthDay at ${d.getDate()} 
                 ${months[d.getMonth()].substring(0,3)}
                 ${new Date().getFullYear()}
                 </li><br/>`
            });
            $("#upcoming-Birthdays").html(html);
        }
}});

$.ajax({
    url: "/Home/GetUpcomingAnniversary",
    method:"GET",
    dataType: "Json",
    success: function (response) {
        let html=``;
        console.log(response);
        
        if(response.length!=0){
            $.each(response, function (indexInArray, valueOfElement) { 
                let d=new Date(parseInt(  valueOfElement.JoinDate.replace('/Date(', '')));
                 html+=`<li> <img src="../../Content/Images/anniversary.png" alt="png" width=20px height=20px>
                 ${valueOfElement.EmpName} Complete ${new Date().getFullYear() - d.getFullYear() } Year at ONEBCG  ${d.getDate()} ${months[d.getMonth()].substring(0,3)}
                 ${new Date().getFullYear()}
                 </li><br/>`
            });
            $("#upcoming-event #upcoming-anniversary").html(html);
        }
}});

$.ajax({
    url: "/Home/GetPastBirthDays",
    method:"GET",
    dataType: "Json",
    success: function (response) {
        let html=``;
        if(response.length!=0){
            $.each(response, function (indexInArray, valueOfElement) { 
                let d=new Date(parseInt(  valueOfElement.DateOfBirth.replace('/Date(', '')));
                 html+=`<li> <img src="../../Content/Images/birthday.png" alt="png" width=20px height=20px>
                 ${valueOfElement.EmpName} BirthDay at ${d.getDate()} 
                 ${months[d.getMonth()].substring(0,3)}
                 ${new Date().getFullYear()}
                 </li><br/>`
            });
            $("#past-birthdays").html(html);
        }
        
}});



$.ajax({
    url: "/Home/GetPastAnniversary",
    method:"GET",
    dataType: "Json",
    success: function (response) {
        let html=``;
        if(response.length!=0){
        
            $.each(response, function (indexInArray, valueOfElement) { 
                let d=new Date(parseInt(  valueOfElement.JoinDate.replace('/Date(', '')));
                html+=`<li><img src="../../Content/Images/anniversary.png" alt="png" width=20px height=20px>
                ${valueOfElement.EmpName} Complete ${new Date().getFullYear() - d.getFullYear() } Year at ONEBCG  ${d.getDate()} ${months[d.getMonth()].substring(0,3)}
                ${new Date().getFullYear()}
                </li><br/>`
            });
            $("#past-anniversary").html(html);
        }
}});





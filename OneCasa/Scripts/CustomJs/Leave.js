$(".LeaveMenu").click( function(){
    $("#viewLeaves").hide();
    $("#ApplyLeaves").hide();
    $("#PendingLeaves").hide();
    $("#LeavesStatus").hide();
    $("#PublicHolidays").hide();
    var id=$(this).val();
    $(`#${id}`).show();
    
    // console.log($(this).val());
});


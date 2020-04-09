$(".LeaveMenu").click( function(){
    $("#viewLeaves").hide();
    $("#ApplyLeaves").hide();
    $("#PendingLeaves").hide();
    $("#LeavesStatus").hide();
    $("#PublicHolidays").hide();
    var id=$(this).val();
    $(`#${id}`).fadeIn(500);
    
    // console.log($(this).val());
});


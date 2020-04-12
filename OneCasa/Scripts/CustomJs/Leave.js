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

$(".leave-cell").click(function (e) { 
    e.preventDefault();
    console.log($(this).children()[0].innerHTML);
    $("#aboutLeaveModal .modal-body").html($(this).children()[0].innerHTML);
    $("#aboutLeaveModal").modal();
});


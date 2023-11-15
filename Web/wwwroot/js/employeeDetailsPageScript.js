$(document).ready(function () {
    $(".renew-contract-btn").click(function () {

        var id = $(this).attr('data-bs-id');
        var employeeId = $(this).attr('data-bs-employeeId');
        $("#staticBackdropLabelRenew").text(id + " " + employeeId);
        var action = "/Admin/Manage/Employees/EmployeeDetails?id=" + id + "&employeeId=" + employeeId + "&handler=RenewContract";
        $("#renewForm").attr("action", action);
    });
    $(".terminate-contract-btn").click(function () {

        var id = $(this).attr('data-bs-id');
        var employeeId = $(this).attr('data-bs-employeeId');
        $("#staticBackdropLabelTerminate").text(id + " " + employeeId);
        var action = "/Admin/Manage/Employees/EmployeeDetails?id=" + id + "&employeeId=" + employeeId + "&handler=TerminateContract";
        $("#terminateForm").attr("action", action);
    });
    $(".delete-contract-btn").click(function () {

        var id = $(this).attr('data-bs-id');
        var employeeId = $(this).attr('data-bs-employeeId');
        $("#staticBackdropLabelDelete").text(id + " " + employeeId);
        var action = "/Admin/Manage/Employees/EmployeeDetails?id=" + id + "&employeeId=" + employeeId + "&handler=DeleteContract";
        $("#deleteForm").attr("action", action);
    });
});
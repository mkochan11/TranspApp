$(document).ready(function () {
    $(".renew-contract-btn").click(function () {

        var id = $(this).attr('data-bs-id');
        var employeeId = $(this).attr('data-bs-employeeId');
        var action = "/Admin/Manage/Employees/EmployeeDetails?id=" + id + "&employeeId=" + employeeId + "&handler=RenewContract";
        $("#renewForm").attr("action", action);
    });
    $(".terminate-contract-btn").click(function () {

        var id = $(this).attr('data-bs-id');
        var employeeId = $(this).attr('data-bs-employeeId');
        var action = "/Admin/Manage/Employees/EmployeeDetails?id=" + id + "&employeeId=" + employeeId + "&handler=TerminateContract";
        $("#terminateForm").attr("action", action);
    });

    $(".delete-contract-btn").click(function () {

        var id = $(this).attr('data-bs-id');
        var employeeId = $(this).attr('data-bs-employeeId');
        var action = "/Admin/Manage/Employees/EmployeeDetails?id=" + id + "&employeeId=" + employeeId + "&handler=DeleteContract";
        $("#deleteForm").attr("action", action);
    });

/*    $(".add-contract-submit-btn").click(function () {
        var employeeId = $(this).attr('data-bs-employeeId');
        var startDate = $("#startDateInputAdd").val();
        var endDate = $("#endDateInputAdd").val();
        var salary = $("#salaryInputAdd").val();
        var action = "/Admin/Manage/Employees/EmployeeDetails?employeeId=" + employeeId + "&startDate=" + startDate + "&endDate=" + endDate + "&salary=" + salary + "&handler=AddContract"
        $("#addForm").attr("action", action);
    });*/

    /*$(".edit-contract-submit-btn").click(function () {
        var id = $(this).attr('data-bs-id');
        var employeeId = $(this).attr('data-bs-employeeId');
        var startDate = $("#startDateInputEdit").val();
        var endDate = $("#endDateInputEdit").val();
        var salary = $("#salaryInputEdit").val();
        var action = "/Admin/Manage/Employees/EmployeeDetails?id=" + id + "&employeeId=" + employeeId + "&startDate=" + startDate + "&endDate=" + endDate + "&salary=" + salary + "&handler=EditContract"
        $("#editForm").attr("action", action);
    });*/

    $(".edit-contract-btn").click(function () {
        var startDate = $(this).attr('data-bs-startDate');
        d = startDate.slice(3, 5);
        m = startDate.slice(0, 2);
        y = startDate.slice(6, 10)
        $("#startDateInputEdit").val(y + "-" + d + "-" + m);

        var endDate = $(this).attr('data-bs-endDate');
        if (endDate != null) {
            d = endDate.slice(3, 5);
            m = endDate.slice(0, 2);
            y = endDate.slice(6, 10)
            $("#endDateInputEdit").val(y + "-" + d + "-" + m);
        }

        var salary = $(this).attr('data-bs-salary');
        $("#salaryInputEdit").attr('value', salary);
    });
});

function validateEditContractForm() {
    var startDate = $("#startDateInputEdit").val();
    var endDate = $("#endDateInputEdit").val();
    var salary = $("#salaryInputEdit").val();
    if (startDate == "" && salary == "") {
        alert("Start date must be chosen \n Salary must be filled");
        return false;
    } else if (startDate == "" && salary != "") {
        alert("Start date must be chosen");
        return false;
    } else if (startDate != "" && salary == "") {
        alert("Salary must be filled");
        return false;
    }

    var startDateNumber = $("#startDateInputEdit").prop('valueAsNumber');
    var endDateNumber = $("#endDateInputEdit").prop('valueAsNumber');
    if (startDateNumber > endDateNumber) {
        alert("Start date must be earlier than end date");
        return false;
    } else {

        var id = $(".edit-contract-btn").attr('data-bs-id');
        var employeeId = $(".edit-contract-btn").attr('data-bs-employeeId');
        var startDate = $("#startDateInputEdit").val();
        var endDate = $("#endDateInputEdit").val();
        var salary = $("#salaryInputEdit").val();
        var action = "/Admin/Manage/Employees/EmployeeDetails?id=" + id + "&employeeId=" + employeeId + "&startDate=" + startDate + "&endDate=" + endDate + "&salary=" + salary + "&handler=EditContract"
        $("#editForm").attr("action", action);
        return true;
    }
}

    function validateAddContractForm() {
        var startDate = $("#startDateInputAdd").val();
        var endDate = $("#endDateInputAdd").val();
        var salary = $("#salaryInputAdd").val();
        if (startDate == "" && salary == "") {
            alert("Start date must be chosen \n Salary must be filled");
            return false;
        } else if (startDate == "" && salary != "") {
            alert("Start date must be chosen");
            return false;
        } else if (startDate != "" && salary == "") {
            alert("Salary must be filled");
            return false;
        }

        var startDateNumber = $("#startDateInputAdd").prop('valueAsNumber');
        var endDateNumber = $("#endDateInputAdd").prop('valueAsNumber');
        if (startDateNumber > endDateNumber) {
            alert("Start date must be earlier than end date");
            return false;
        } else {
            var employeeId = $(".add-contract-btn").attr('data-bs-employeeId');
            var startDate = $("#startDateInputAdd").val();
            var endDate = $("#endDateInputAdd").val();
            var salary = $("#salaryInputAdd").val();
            var action = "/Admin/Manage/Employees/EmployeeDetails?employeeId=" + employeeId + "&startDate=" + startDate + "&endDate=" + endDate + "&salary=" + salary + "&handler=AddContract"
            $("#addForm").attr("action", action);
            return true;
        }
}
$(document).ready(function () {


    console.log("Hello");
    var user = {
        init: function () {
            console.log("Hello111");
            user.registerEvents();
        },
        registerEvents: function () {
            $('.btn-active-xxx').on('click', function (e) {
                console.log("Hello11");
                e.preventDefault();
                console.log("Hello222");
                var id = $(this).data('userID');
                $.ajax({
                    url: "Admin/User/ChangeStatus",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response.status);
                        if (response.status == false) {
                            $(this).text("Kích hoạt");
                        } else {
                            $(this).text("Khóa");
                        }
                    }
                })
            })//end-function
        }
    }
});


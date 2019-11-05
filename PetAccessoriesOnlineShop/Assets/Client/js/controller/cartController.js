var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function(){
        $('#btn-continue').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btn-deletel-all').off('click').on('click', function () {

            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart"
                    }
                }

            })
        });


        $('.icon-delete').off('click').on('click', function () {
            console.log("hello");
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart"
                    }
                }

            })
        });

        $('#btn-update').off('click').on('click', function () {
            console.log("Hiiiii123");
            var listProduct = $('.txt-quantity');  
            var cartList = [];      
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
           
            });
            console.log("Hiiii2i");

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href="/Cart"
                    }
                }

            })
        });


        $('#btn-checkout').off('click').on('click', function () {
            window.location.href = "/payment";
        });

        $('#payment').off('click').on('click', function () {
            //dang xu ly
        });
    }
}
cart.init();
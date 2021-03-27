jQuery(function () {
    $.datetimepicker.setDateFormatter('moment');
    //$.datetimepicker.setDateFormatter({
    //    parseDate: function (date, format) {
    //        var d = moment(date, format);
    //        return d.isValid() ? d.toDate() : false;
    //    },
    //    formatDate: function (date, format) {
    //        return moment(date).format(format);
    //    }
    //});
    //$(".datetimefield").datetimepicker(
    //    {
    //        format: 'DD-M-YYYY hh:mm A',
    //        minDate:new Date()
    //    });

    //var todaydt = new Date();
    //$(".txt_date_fr").datetimepicker($.extend({
    //    autoclose: true,
    //    dateFormat: 'DD-M-YYYY hh:mm A',
    //    minDate: todaydt,
    //    onSelect: function (date) {
    //        //Get selected date 
    //        var date2 = $('.txt_date_fr').getDate();
    //        //sets minDate to txt_date_to
    //        $('.txt_date_to').datetimepicker('option', 'minDate', date2);
    //    }
    //}));
    //$('.txt_date_to').datetimepicker($.extend({
    //    dateFormat: 'DD-M-YYYY hh:mm A'
    //}));

     //$('.txt_date_fr').on('dp.change', '.txt_date_fr', function (e) {
    //    $('.txt_date_to').datetimepicker().minDate(e.date);
    //});

    jQuery('#txt_date_fr').datetimepicker({
        autoclose: true,
        format: 'DD-M-YYYY hh:mm A',
        minDate: new Date()
        
    });
    jQuery('#txt_date_to').datetimepicker({
        autoclose: true,
        format: 'DD-M-YYYY hh:mm A',
        minDate: new Date()
        
    });
       
    $('.txt_date_fr').datetimepicker().on('dp.change', function ($input) {
        var selectedDate = $input.datetimepicker('getValue');
        $('.txt_date_to').datetimepicker('minDate', selectedDate);
    })

    $(".datetimefilter").datetimepicker(
        {
            format: 'DD-M-YYYY hh:mm A'
           
        });

    $('.datetimefilter1').datetimepicker({
        format: 'DD-M-YYYY hh:mm A',
        ignoreReadonly: true,
        useCurrent: false,
        onSelectDate: function (date) {
            //Get selected date
            var date2 = $('.datetimefilter1').datetimepicker.getDate();
            //sets minDate to txt_date_to
            $('.datetimefilter2').datetimepicker('option', 'minDate', date2);
        }

    });
    $('.datetimefilter2').datetimepicker({
        format: 'DD-M-YYYY hh:mm A',
        ignoreReadonly: true,
        useCurrent: false,


    });

    $('.datetimefilter1').datetimepicker().on('dp.change', function (e) {
        $('.datetimefilter2').datetimepicker('minDate', e.date);
    })


});
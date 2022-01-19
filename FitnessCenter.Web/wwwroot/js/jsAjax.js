function AddAjaxEvents() {
    $("button[ajax-event='yes']").click(function (event) {
        $(this).attr("ajax-event", "added");
        event.preventDefault();
        var url = $(this).attr("ajax-url");
        var divResult = $(this).attr("ajax-result");

        $.get(url, function (data, status) {
            $("#" + divResult).html(data);
        });
    });

    $("a[ajax-event='yes']").click(function (event) {
        $(this).attr("ajax-event", "added");
        event.preventDefault();
        var url1 = $(this).attr("ajax-url");
        var url2 = $(this).attr("href");
        var divResult = $(this).attr("ajax-result");
        var myUrl;

        if (url1 instanceof String)
            myUrl = url1;
        else
            myUrl = url2;

        $.get(myUrl, function (data, status) {
            $("#" + divResult).html(data);
        });
    });



      $("form[ajax-event='yes']").submit(function (event) {
        $(this).attr("ajax-poziv", "added");
        event.preventDefault();
        var url1 = $(this).attr("ajax-url");
        var url2 = $(this).attr("action");
        var divResult = $(this).attr("ajax-result");

        var myUrl;
        if (url1 instanceof String)
          myUrl = url1;
        else
          myUrl = url2;

        var form = $(this);

        $.ajax({
          type: "POST",
          url: myUrl,
          data: form.serialize(),
          success: function (data) {
            $("#" + divResult).html(data);
          }
        });
      });
    }
    $(document).ready(function () {
        // izvršava nakon što glavni html dokument bude generisan
        AddAjaxEvents();
    });

    $(document).ajaxComplete(function () {
        // izvršava nakon bilo kojeg ajax poziva
        AddAjaxEvents();
    });
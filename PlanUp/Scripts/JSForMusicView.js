

    function GeneratePropositionInput()
    {
        document.getElementById("genrePreferenceForm").style.display = "block";
    }
    function GenerateFormProposition()
    {
        document.getElementById("genreForm").style.display = "block";
    }
    function ShowDescription()
    {
        document.getElementById("description-body").showPopup(item.description);
    }

    $(function () {
        $(".Next").click(function (e) {

            var defaultValue = 'def';
            var myData = [{ Title: '@Model[0].Title', Description: defaultValue, Etag: '@Model[0].Etag' },
            { Title: '@Model[1].Title', Description: defaultValue, Etag: '@Model[1].Etag' },
            { Title: '@Model[2].Title', Description: defaultValue, Etag: '@Model[2].Etag' }];
            $.ajax({
                url: "@Url.Action("SaveRejectedToDatabase", "Music")",
                type: "POST",
                dataType: "json",
                contentType: 'application/json',
                data: JSON.stringify(myData),
                success: function () {
                },
                error: function (jqXHR, textStatus, errorThrown) {
                }
            });
        });
    })

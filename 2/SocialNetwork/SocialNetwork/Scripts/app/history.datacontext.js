window.dataContext = (function () {
    function getInfoUri() { return "/api/Info" };

    function getInfo(successHello, successHistory) {
        return ajaxRequest("get", getInfoUri())
            .done(function (d) {
                successHello(d.Hello)
                successHistory(d.History);
            })
            .fail(function (response) {
                console.log(response);
            });
    }

    function ajaxRequest(type, url, data, dataType) {
        var options = {
            dataType: dataType || "json",
            contentType: "application/json",
            cache: false,
            type: type,
            data: data ? ((typeof data.toJson === 'function') ? data.toJson().toString() : JSON.stringify(data)) : null
        };
        return $.ajax(url, options);
    }

    return {
        getInfo: getInfo
    }
})()
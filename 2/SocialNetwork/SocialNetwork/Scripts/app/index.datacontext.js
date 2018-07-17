window.dataContext = (function () {
    function postUri() { return "/api/Post" };
    function foodUri() { return "/api/Food" };

    function addPost(data, successHandler, error) {
        return ajaxRequest("post", postUri(), data)
            .done(function (d) {
                successHandler(d);
            })
            .fail(function (response) {
                console.log(response)

                error.push(response.responseJSON.Message);
            });
    }

    function addFood(data, successHandler, error) {
        return ajaxRequest("post", foodUri(), data)
            .done(function (d) {
                successHandler(d);
            })
            .fail(function (response) {
                error(response.responseJSON.Message);
            });
    }

    function getFood(successHandler) {
        return ajaxRequest("get", foodUri())
            .done(function (d) {
                successHandler(d);
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
        addPost: addPost,
        getFood: getFood,
        addFood: addFood
    }
})()
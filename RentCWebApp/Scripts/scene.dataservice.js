var dataService = new function () {
    var serviceBase = '/DataService/',

        getReservations = function (callback) {
            $.getJSON(serviceBase + 'GetReservations', function (data) {
                callback(data);
            });
        };
    return {
        getReservations: getReservations
    };


}();
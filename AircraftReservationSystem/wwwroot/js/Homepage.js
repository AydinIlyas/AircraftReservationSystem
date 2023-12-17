function IsOneWayOrNot() {
    var isOneWayRadioButton = $('input[name="IsOneWay"]:checked');
    var isOneWayValue = isOneWayRadioButton.val();
    $('#endDateContainer').toggle(isOneWayValue);
}
function SearchDepartureAirport() {
    var userInput = $('#departureAirport').val();
    console.log(userInput);
    if (userInput) {
        $.get('/api/airports/airports', { inputValue: userInput }, function (data) {
            $('#departureAirportOptions').empty();
            $.each(data, function (index, airport) {
                $('#departureAirportOptions').append('<option value="' + airport.name + '">' + airport.id + '</option>');
            });
        });
    }
}
function SearchArrivalAirport() {
    var userInput = $('#arrivalAirport').val();
    console.log(userInput);
    if (userInput) {
        $.get('/api/airports/airports', { inputValue: userInput }, function (data) {
            $('#arrivalAirportOptions').empty();
            $.each(data, function (index, airport) {
                $('#arrivalAirportOptions').append('<option value="' + airport.name + '">' + airport.id + '</option>');
            });
        });
    }
}
$(function () {
    IsOneWayOrNot();
});
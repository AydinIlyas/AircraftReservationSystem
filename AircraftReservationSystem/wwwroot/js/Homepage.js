function IsOneWayOrNot() {
    var isOneWayRadioButton = $('input[name="IsOneWay"]:checked');
    var isOneWayValue = isOneWayRadioButton.val();
    $('#endDateContainer').toggle(isOneWayValue === "false");
}

var airportData = [];

function fetchAirportData() {
    $.get('/api/airports/getAirports', function (data) {
        airportData = data;
    }).fail(function (xhr, textStatus, errorThrown) {
        console.error("Error fetching airport data: " + textStatus);
    });
}

fetchAirportData();
console.log(airportData);
var debounceTimer;
function SearchDepartureAirport() {
    var optionsDepartureAirport = '';
    var userInput = $('#departureAirport').val();
    console.log(userInput);

    if (debounceTimer) {
        clearTimeout(debounceTimer);
    }

    if (userInput) {
        debounceTimer = setTimeout(function () {
            airportData.forEach(function (airport) {
                if (airport.name.toLowerCase().includes(userInput.toLowerCase()))
                {
                    optionsDepartureAirport += '<option value="' + airport.name + '">' + airport.id + '</option>';
                }
            });
            if(optionsDepartureAirport)
            $('#departureAirportOptions').html(optionsDepartureAirport);
        }, 300);
    }
}

function SearchArrivalAirport() {
    var optionsArrivalAirport = '';
    var userInput = $('#arrivalAirport').val();
    console.log(userInput);

    if (debounceTimer) {
        clearTimeout(debounceTimer);
    }

    if (userInput) {
        debounceTimer = setTimeout(function () {
            airportData.forEach(function (airport) {
                if (airport.name.toLowerCase().includes(userInput.toLowerCase())) {
                    optionsArrivalAirport += '<option value="' + airport.name + '">' + airport.id + '</option>';
                }
            });
            if(optionsArrivalAirport)
            $('#arrivalAirportOptions').html(optionsArrivalAirport);
        }, 300);
    }
}

$('#arrivalAirport').change(function () {
    console.log("TEST")
    var selectedAirportName = $(this).val();
    var selectedAirportId = getAirportIdByName(selectedAirportName);
    $('#arrivalAirportId').val(selectedAirportId);
});

$('#departureAirport').change(function () {
    var selectedAirportName = $(this).val();
    var selectedAirportId = getAirportIdByName(selectedAirportName);
    $('#departureAirportId').val(selectedAirportId);
});

function getAirportIdByName(airportName) {
    var selectedAirport = airportData.find(function (airport) {
        return airport.name === airportName;
    });

    return selectedAirport ? selectedAirport.id : null;
}

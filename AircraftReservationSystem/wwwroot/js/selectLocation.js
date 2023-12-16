    function loadCountries() {
        $.get('/api/locations/countries', function (data) {
            $.each(data, function (index, country) {
                $('#Country').append('<option value="' + country.id + '">' + country.name + '</option>');
            });
        });
        }

    function loadCities() {
            var countryId = $('#Country').val();
    if (countryId) {
        $.get('/api/locations/cities', { countryId: countryId }, function (data) {
            // Populate the City dropdown with data
            $('#City').empty();
            $('#City').append('<option value=""> --City--</option>');
            $.each(data, function (index, city) {
                $('#City').append('<option value="' + city.id + '">' + city.name + '</option>');
            });
        });
            }
    else {
        loadDistricts();
    $('#City').empty();
    $('#City').append('<option value=""> --City--</option>');
            }
        }

    function loadDistricts() {
            var cityId = $('#City').val();
    if (cityId) {
        $.get('/api/locations/districts', { cityId: cityId }, function (data) {
            // Populate the District dropdown with data
            $('#District').empty();
            $('#District').append('<option value=""> --District--</option>');
            $.each(data, function (index, district) {
                $('#District').append('<option value="' + district.id + '">' + district.name + '</option>');
            });
        });
            }
    else{
        $('#District').empty();
    $('#District').append('<option value=""> --District--</option>');
            }
        }
    $(function () {
        loadCountries();
        });

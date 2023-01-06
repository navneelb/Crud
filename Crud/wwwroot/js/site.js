// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".custom-file-input").on("change", function () {

  var fileName = $(this).val().split("\\").pop();

   document.getElementById('PreviewPhoto').src = window.URL.createObjectURL(this.files[0]);

    document.getElementById('PhotoUrl').value = fileName;

 });

$(document).ready(function () {
    GetCountry();
    $('#State').attr('disabled', true);
    $('#City').attr('disabled', true);
    $('#Country').change(function () {
        $('#State').attr('disabled', false);
        $('#City').attr('disabled', true);
        $('#City').empty();
        $('#City').append('<Option>---Select City--<Option>');
        var id = $(this).val();
        $('#State').empty();
        $('#State').append('<Option>---Select State--</Option>');
        $.ajax({
            url: '/UserController1/State?CountryId=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#State').append('<Option value= ' + data.stateId + '>' + data.stateName + '</Option>');
                });
            }
        });
    })

    $('#State').change(function () {
        $('#City').attr('disabled', false);
        var id = $(this).val();
        $('#City').empty();
        $('#City').append('<Option>---Select City--<Option>');
        $.ajax({
            url: '/UserController1/City?StateId=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#City').append('<Option value= ' + data.cityId + '>' + data.cityName + '</Option>');
                });
            }
        });
    });

});
function GetCountry() {
    $.ajax({
        url: '/UserController1/Country',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Country').append('<Option value= ' + data.countryId + '>' + data.countryName + '</Option>');
            });
        }
    });
}
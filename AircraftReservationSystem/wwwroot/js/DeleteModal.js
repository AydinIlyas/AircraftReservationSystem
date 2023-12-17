$(document).ready(function () {
    $('.btn-danger').on('click', function () {
        var itemId = $(this).data('item-id');
        $('#confirmDeleteModal').modal('show');

        $('#confirmDeleteModal').find('#itemToDelete').val(itemId);
    });

    $('#confirmDeleteModal').find('.btn-secondary').on('click', function () {
        $('#confirmDeleteModal').modal('hide');
    });

    $('#confirmDeleteModal').find('.close').on('click', function () {
        $('#confirmDeleteModal').modal('hide');
    });
});

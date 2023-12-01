ProjectApp.controller('MemberController', ['$scope', '$http', '$sce', '$timeout', '$window', function ($scope, $http, $sce, $timeout, $window) {
    $scope.member = {
        firstName: '',
        lastName: '',
        identityNumber: null,
        phoneNumber: '',
        mailAddress: '',
        gender: '',
        isActive: false
    };
    $scope.showUpdateButon = false;

    $scope.sortType = 'order'; // Varsayılan sıralama türü
    $scope.sortReverse = false; // Varsayılan sıralama yöntemi

    $scope.GetAllMember = function () {
        $http.get("/Member/GetAll")
            .then(function (response) {
                $scope.memberList = response.data.data.$values;
                $scope.configureDataTable();
            })
            .catch(function (error) {
                console.error('Üye getirme hatası:', error);
            });
    };

    $scope.sortColumn = function (column) {
        $scope.sortType = column;
        $scope.sortReverse = !$scope.sortReverse;
    };

    $scope.update = function () {
        $http.post('/Member/DeleteAndUpdate', $scope.member)
            .then(function (response) {
                $scope.alertModal(response.data.isSuccess);
            })
            .catch(function (error) {
                $scope.alertModal(false);
                $scope.showUpdateButon = false;
                console.error('Üye güncelleme hatası:', error);
            });
    };

    $scope.delete = function (member) {
        Swal.fire({
            title: 'Emin misiniz?',
            text: 'Bu öğeyi silmek istediğinizden emin misiniz?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Sil',
            cancelButtonText: 'Hayır, İptal Et',
        }).then(function (result) {
            if (result.isConfirmed) {
                member.isDeleted = true;
                $http.post('/Member/DeleteAndUpdate', member)
                    .then(function (response) {
                        console.log('Üye başarıyla silindi.', response.data);
                    })
                    .catch(function (error) {
                        console.error('Üye silme hatası:', error);
                    });
                Swal.fire('Silindi!', 'Üye başarıyla silindi.', 'success');
                $window.location.reload();
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire('İptal Edildi', 'Silme işlemi iptal edildi.', 'info');
            }
        });
    };

    $scope.save = function () {
        if ($scope.memberForm.$invalid) {
            Swal.fire({
                title: "Uyarı!",
                text: "Lütfen tüm zorunlu alanları doldurun!",
                showCancelButton: false,
                showCloseButton: false,
                showConfirmButton: false,
                timerProgressBar: true,
                timer: 2000,
                onOpen: function () {
                    Swal.showLoading();
                }
            });
            return;
        }

        $http.post("/Member/Insert", $scope.member)
            .then(function (response) {
                $scope.alertModal(response.data.isSuccess);
                $scope.GetAllMember();
            })
            .catch(function (error) {
                console.error('Üye ekleme hatası:', error);
            });
    };

    $scope.alertModal = function (isSuccess, isUpdate) {
        var textInfo = isUpdate ? "Güncelleme işlemi başarıyla yapıldı." : "Üye Başarıyla Kaydedildi";
        Swal.fire({
            title: "Bilgi!",
            text: isSuccess ? textInfo : "İşlem Yapılamadı!",
            showCancelButton: false,
            showCloseButton: false,
            showConfirmButton: false,
            timerProgressBar: true,
            timer: 2000,
            onOpen: function () {
                Swal.showLoading();
            }
        }).then(function (result) {
            if (result.dismiss === "timer") {
                $('#kt_modal_create_app').modal('hide');
                $window.location.reload();
            }
        });
    };

    $scope.openUpdateModal = function (member) {
        $scope.member = member;
        $scope.showUpdateButon = true;
        $('#kt_modal_create_app').modal('show');
    };

    $scope.openCreateModal = function (member) {
        $scope.member = {
            firstName: '',
            lastName: '',
            identityNumber: null,
            phoneNumber: '',
            mailAddress: '',
            gender: '',
            isActive: false
        };
        $scope.showUpdateButon = false;
    };

    $scope.configureDataTable = function () {
        $timeout(function () {
            $('#memberTable').DataTable().destroy();
            $('#memberTable').DataTable({
                "order": [[2, 'asc']],
                "paging": true,
                "lengthChange": true,
                "searching": false,
                "info": true,
                "autoWidth": false,
                "columnDefs": [
                    { type: 'status-sort', targets: 3 }
                ]
            });
        });
    };

    $scope.pageLoad = function () {
        $scope.GetAllMember();
    };

    $scope.pageLoad();

    $.fn.dataTable.ext.order['status-sort'] = function (settings, col) {
        return this.api().column(col, { order: 'index' }).nodes().map(function (td, i) {
            var status = $(td).find('span').text().toLowerCase();
            return status === 'aktif üye' ? 1 : (status === 'pasif üye' ? 2 : 3);
        });
    };

}]).directive('onFinishRender', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit(attr.onFinishRender);
                });
            }
        }
    };
}).filter('filter', function () {
    return function (items, searchText) {
        if (!searchText) {
            return items;
        }

        searchText = searchText.toLowerCase();

        return items.filter(function (item) {
            return (
                (item.firstName && item.firstName.toLowerCase().includes(searchText)) ||
                (item.lastName && item.lastName.toLowerCase().includes(searchText)) ||
                (item.phoneNumber && item.phoneNumber.toLowerCase().includes(searchText)) ||
                (item.isActive != null && (item.isActive ? 'aktif' : 'pasif').includes(searchText.toLowerCase()))
            );
        });
    };
});





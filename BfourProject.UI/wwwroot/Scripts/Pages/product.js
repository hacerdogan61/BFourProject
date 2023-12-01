ProjectApp.controller('ProductController', ['$scope', '$http', '$sce', '$timeout','$window', function ($scope, $http, $sce, $timeout, $window) {

    $scope.product = { price: undefined, name: '', sessionDurationByMinute: undefined, isActive:true }
    $scope.GetAllProduct = function () {
        $http({
            method: "GET",
            url: "/Product/GetAll",
            headers: { "Content-Type": "Application/json;charset=utf-8" },
            data: {}

        }).then(function (response) {
            $scope.productList = response.data.data.$values;
            $scope.configureDataTable();
        });
    }

    $scope.update = function () {
        $http.post('/Product/DeleteAndUpdate', $scope.product)
            .then(function (response) {
                $scope.alertModal(response.data.isSuccess,true);
            })
            .catch(function (error) {
                $scope.alertModal(false,true);
                $scope.showUpdateButon = false;
                console.error('Hizmet güncelleme hatası:', error);
            });
    };
    $scope.openUpdateModal = function (product) {
        $scope.product = product;
        $scope.showUpdateButon = true;
        $('#kt_modal_create_app').modal('show');
    };

    $scope.openCreateModal = function (product) {
        $scope.product = {};
        $scope.showUpdateButon = false;
    };
    $scope.delete = function (product) {
        Swal.fire({
            title: 'Emin misiniz?',
            text: 'Bu hizmeti silmek istediğinizden emin misiniz?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Sil',
            cancelButtonText: 'Hayır, İptal Et',
        }).then(function (result) {
            if (result.isConfirmed) {
                product.isDeleted = true;
                $http.post('/Product/DeleteAndUpdate', product)
                    .then(function (response) {
                        console.log('Hizmet başarıyla silindi.', response.data);
                    })
                    .catch(function (error) {
                        console.error('Hizmet silme hatası:', error);
                    });
                Swal.fire('Silindi!', 'Hizmet başarıyla silindi.', 'success');
                $window.location.reload();
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire('İptal Edildi', 'Silme işlemi iptal edildi.', 'info');
            }
        });
    };

    $scope.save = function () {
        if ($scope.createAndUpdateModal.$invalid) {
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

        $http({
            method: "POST",
            url: "/Product/Insert",
            headers: { "Content-Type": "Application/json;charset=utf-8" },
            data: $scope.product

        }).then(function (response) {
            $scope.alertModal(response.data.isSuccess, false);
            $scope.GetAllProduct();
        });
    }

    $scope.alertModal = function (isSuccess, isUpdate) {
        var textInfo = isUpdate ? "Güncelleme işlemi başarıyla yapıldı." : "Hizmet Başarıyla Kaydedildi";
        Swal.fire({
            title: "Bilgi!",
            text: isSuccess ? textInfo : "İşlem Sırasında Hata Oluştu!",
            showCancelButton: false,
            showCloseButton: false,
            showConfirmButton: false,
            timerProgressBar: true,
            timer: 2000,
            onOpen: function () {
                Swal.showLoading()
            }
        }).then(function (result) {
            if (result.dismiss === "timer") {
                $('#kt_modal_create_app').modal('hide');
                $window.location.reload();
            }
        })
    }
    $scope.configureDataTable = function () {
        $timeout(function () {
            $('#productTable').DataTable().destroy();
            $('#productTable').DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": false,
                "info": true,
                "autoWidth": false
            });
        });
    };

    // Sayfa yüklendiğinde çalışacak fonksiyon
    $scope.pageLoad = function () {
        $scope.GetAllProduct();
    };
    $.fn.dataTable.ext.order['status-sort'] = function (settings, col) {
        return this.api().column(col, { order: 'index' }).nodes().map(function (td, i) {
            var status = $(td).find('span').text().toLowerCase();
            return status === 'aktif üye' ? 1 : (status === 'pasif üye' ? 2 : 3);
        });
    };
    // Sayfa yüklendiğinde çalışacak fonksiyonu çağır
    $scope.pageLoad();


}]).directive('onFinishRender', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {//ng repeat dönerken son kayıtmı diye bakıyorum
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
                (item.name && item.name.toLowerCase().includes(searchText)) ||
                (item.price.toString().includes(searchText)) ||  // price'ı stringe çevirip kontrol et
                (item.sessionDurationByMinute.toString().includes(searchText)) ||  // sessionDurationByMinute'ı stringe çevirip kontrol et
                (item.isActive != null && (item.isActive ? 'aktif' : 'pasif').includes(searchText))
            );
        });
    };
});




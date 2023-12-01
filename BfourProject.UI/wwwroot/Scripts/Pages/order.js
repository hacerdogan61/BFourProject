
ProjectApp.controller('OrderController', ['$scope', '$http', '$sce', '$timeout', '$window', function ($scope, $http, $sce, $timeout, $window) {

    $scope.product = { Name: '', SessionDurationByMinute: 0, Price: 0.0, IsActive: false };
    $scope.selectedPackage = 0;
    $scope.selectedProductList = []; // Örnek olarak, boş bir diziyle başlatın
    $scope.order = {
        totalUnitPrice: 0,
        totalDiscountPrice: 0,
        totalNetSalePrice: 0,
        memberId: 0,
        paymentTypeId: 0,
        posId: 0,
        discountRate: 0,
        orderDetails: {}
    };
    $scope.methodStartCount = 0;

    $scope.GetAllOrder = function () {

        $http.get("/Order/GetAll")
            .then(function (response) {
                $scope.orderList = response.data.data.$values;
                $scope.configureDataTable();
            })
            .catch(function (error) {
                console.error("Error fetching product discounts:", error);
            });
    }
    $scope.GetAllMember = function () {
        $http.get("/Member/GetAll")
            .then(function (response) {
                $scope.memberList = response.data.data.$values;
            })
            .catch(function (error) {
                console.error("Error fetching product discounts:", error);
            });
    }
    $scope.GetPaymentTypeList = function () {
        $http.get("/Order/GetPaymentTypeList")
            .then(function (response) {
                $scope.paymentTypeList = response.data.data.$values;
            })
            .catch(function (error) {
                console.error("Error fetching product discounts:", error);
            });
    }
    $scope.GetPOSList = function () {
        $http.get("/Order/GetPOSList")
            .then(function (response) {
                $scope.posList = response.data.data.$values;
            })
            .catch(function (error) {
                console.error("Error fetching product discounts:", error);
            });
    }
    $scope.GetAllProduct = function () {
        $http.get("/Product/GetAll")
            .then(function (response) {
                $scope.productList = response.data.data.$values;
            })
            .catch(function (error) {
                console.error("Error fetching product discounts:", error);
            });
    }
    $scope.getOrderDetails = function (order) {
        $scope.orderView = order;
    }
    $scope.GetData = function () {
        $scope.GetAllProduct();
        $scope.GetAllProductDiscount();
    }
    $scope.selectData = function (product) {
        // Seçilen paketi kontrol et
        if (product.selectedPackage !== "") {
            // Eğer ürün zaten listede varsa, güncelle
            var existingItem = $scope.selectedProductList.find(item => item.name === product.name);
            if (existingItem) {
                existingItem.packageCount = product.selectedPackage;
            } else {
                // Eğer ürün listede yoksa, yeni bir nesne olarak ekle
                $scope.selectedProductList.push({ OrderId: 0, productId: product.id, unitPrice: product.price, name: product.name, packageCount: parseInt(product.selectedPackage) });
            }
        } else {
            // Seçilen paket 0 ise, listeden kaldır (varsa)
            var index = $scope.selectedProductList.findIndex(item => item.name === product.name);
            if (index !== -1) {
                $scope.selectedProductList.splice(index, 1);
            }
        }
        $scope.order.totalUnitPrice = 0;
        $scope.methodStartCount = 0;
        // Diğer işlemleri burada gerçekleştir
    };
    $scope.GetAllProductDiscount = function () {
        $http.get("/Product/GetAllProductDiscount")
            .then(function (response) {
                $scope.productDiscountList = response.data.data.$values;

                // Benzersiz packageCount'ları grupla
                var uniquePackageCounts = Array.from(new Set($scope.productDiscountList.map(item => item.packageCount)));

                $scope.groupedItems = {};

                uniquePackageCounts.forEach(function (packageCount) {
                    $scope.groupedItems[packageCount] = [];
                });

                $scope.productDiscountList.forEach(function (item) {
                    $scope.groupedItems[item.packageCount].push(item.packageCount);
                });
                console.log($scope.groupedItems);
            })
            .catch(function (error) {
                console.error("Error fetching product discounts:", error);
            });
    };
    $scope.calculateTotalPackageCount = function () {
        var totalPackageCount = 0;
        // $scope.selectedProduct dizisini dolaşarak her bir öğenin packageCount özelliğini topla
        for (var i = 0; i < $scope.selectedProductList.length; i++) {
            totalPackageCount += 1;
        }
        return parseInt(totalPackageCount);
    };
    $scope.updateSelectedProductList = function () {
        if ($scope.methodStartCount == 0) {
            angular.forEach($scope.selectedProductList, function (product) {
                // Her bir ürünü güncelle
                var productDiscount = $scope.productDiscountList.find(x => x.packageCount == parseInt(product.packageCount) && x.totalProductCount == $scope.calculateTotalPackageCount());
                product.discountPrice = parseInt((parseInt(product.unitPrice) * (1 - parseInt(productDiscount.discountRate) / 100) * parseInt(product.packageCount)));
                $scope.order.totalUnitPrice += product.unitPrice * parseInt(product.packageCount);
                $scope.order.totalDiscountPrice += product.discountPrice;
            });

            $scope.GetAllMember();
            $scope.methodStartCount++;
        }
    }
    $scope.delete = function (order) {
        Swal.fire({
            title: 'Emin misiniz?',
            text: 'Bu öğeyi silmek istediğinizden emin misiniz?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Sil',
            cancelButtonText: 'Hayır, İptal Et',
        }).then(function (result) {
            if (result.isConfirmed) {
                order.isDeleted = true;
                $http.post('/Order/DeleteAndUpdate', order)
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
    $scope.submitOrder = function () {
        $scope.order.totalNetSalePrice = $scope.order.totalNetSalePrice == 0 ? $scope.order.totalDiscountPrice : $scope.order.totalNetSalePrice;

        angular.forEach($scope.selectedProductList, function (product) {
            product.netSalePrice = ($scope.order.totalNetSalePrice / $scope.order.totalDiscountPrice) * product.discountPrice;
            product.discountRate = (1 - product.netSalePrice / (product.unitPrice * product.packageCount)) * 100;
        });

        var orderData = {
            memberId: $scope.order.memberId,
            paymentTypeId: $scope.order.paymentTypeId,
            posName: $scope.order.posName,
            totalUnitPrice: $scope.order.totalUnitPrice,
            totalDiscountPrice: $scope.order.totalDiscountPrice,
            totalNetSalePrice: $scope.order.totalNetSalePrice,
            discountRate: ((1 - $scope.order.totalNetSalePrice / $scope.order.totalUnitPrice) * 100),
            orderDetails: $scope.selectedProductList
        };


        if (orderData.memberId == undefined || orderData.memberId == '' || orderData.paymentTypeId == undefined || orderData.paymentTypeId == '') {
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
        // HTTP POST isteği
        $http.post('/Order/Insert', orderData)
            .then(function (response) {
                $scope.alertModal(response.data.isSuccess);
            })
            .catch(function (error) {
                // Hata durumunda burası çalışır
                $scope.alertModal(false);
                console.error('Sipariş gönderme hatası:', error);
            });
    };

    $scope.showHidePosDiv = function () {
        $scope.show = $scope.order.paymentTypeId === "2";
    };
    $scope.alertModal = function (isSuccess) {
        Swal.fire({
            title: "Bilgi!",
            text: isSuccess ? "Satış Başarıyla Oluşturuldu" : "Kayıt İşleminde Hata Alındı!",
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
            $('#orderTable').DataTable().destroy();
            $('#orderTable').DataTable({
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
        $scope.GetAllOrder();
        $scope.GetPaymentTypeList();
        $scope.GetPOSList();
    };

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
                (item.member.firstName && item.member.firstName.toLowerCase().includes(searchText)) ||
                (item.member.lastName && item.member.lastName.toLowerCase().includes(searchText)) ||
                (item.totalUnitPrice.toString().toLowerCase().includes(searchText)) ||
                (item.totalSalePrice.toString().toLowerCase().includes(searchText)) ||
                (item.paymentType.text && item.paymentType.text.toLowerCase().includes(searchText)) ||
                (item.isActive != null && (item.isActive ? 'aktif' : 'pasif').includes(searchText.toLowerCase()))
            );
        });
    };
});
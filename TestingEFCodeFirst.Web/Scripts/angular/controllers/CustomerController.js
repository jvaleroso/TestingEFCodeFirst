var mongoAngular;
(function (mongoAngular) {
    (function (Controllers) {
        'use strict';

        var customerModel = mongoAngular.models.Customer;

        var CustomerController = (function () {
            function CustomerController(customerService) {
                this.customerService = customerService;
                this.showUpdateButton = false;

                $("#birthdate").datepicker({
                    dateFormat: 'dd-M-yy',
                    changeMonth: true,
                    changeYear: true
                });

                this.customer = new customerModel();
                this.customerList = [];
                this.getCustomers();
            }
            CustomerController.prototype.logError = function (error) {
                console.log(error.message);
            };

            CustomerController.prototype.resetCustomer = function () {
                this.customer = new customerModel();
                this.birthDate = null;
            };

            CustomerController.prototype.cancel = function () {
                this.customer = null;
                this.showUpdateButton = false;
                this.birthDate = null;
            };

            CustomerController.prototype.setBirthDate = function () {
                var birthday = this.birthDate.split('-');
                var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

                var month = months.indexOf(birthday[1]);
                var date = parseInt(birthday[0], 10);
                var year = parseInt(birthday[2], 10);

                this.customer.birthDate = new Date(Date.UTC(year, month, date));
            };

            CustomerController.prototype.addCustomer = function (customer) {
                var _this = this;
                this.customerService.saveCustomer(customer).then(function (c) {
                    _this.customerList.push(c);
                    _this.resetCustomer();
                }, this.logError);
            };

            CustomerController.prototype.updateCustomer = function (customer) {
                var _this = this;
                this.customerService.updateCustomer(customer).then(function () {
                    _this.showUpdateButton = false;
                    _this.resetCustomer();
                    _this.getCustomers();
                }, this.logError);
            };

            CustomerController.prototype.deleteCustomer = function (id) {
                var _this = this;
                this.customerService.getCustomerById(id).then(function (c) {
                    _this.customerService.removeCustomer(c).then(function () {
                        _this.getCustomers();
                    }, function (error) {
                        console.log(error.message);
                    });
                }, function (error) {
                    console.log(error.message);
                });
            };

            CustomerController.prototype.getCustomers = function () {
                var _this = this;
                this.isLoadingData = true;
                this.customerService.getCustomers().then(function (customers) {
                    _this.customerList = customers;
                    _this.isLoadingData = false;
                }, this.logError);
            };

            CustomerController.prototype.editCustomer = function (id) {
                var _this = this;
                this.showUpdateButton = true;
                this.customerService.getCustomerById(id).then(function (c) {
                    _this.customer = c;
                    var date = new Date(c.birthDate.toString());
                    $('#birthdate').datepicker("setDate", date);
                }, this.logError);
            };
            return CustomerController;
        })();
        Controllers.CustomerController = CustomerController;

        angular.module('mongoAngular').controller('CustomerController', [
            'CustomerService',
            CustomerController
        ]);
    })(mongoAngular.Controllers || (mongoAngular.Controllers = {}));
    var Controllers = mongoAngular.Controllers;
})(mongoAngular || (mongoAngular = {}));
//# sourceMappingURL=CustomerController.js.map

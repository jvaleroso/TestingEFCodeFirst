var mongoAngular;
(function (mongoAngular) {
    (function (controllers) {
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
                this.customer = null;
            };

            CustomerController.prototype.cancel = function () {
                this.customer = null;
                this.showUpdateButton = false;
                this.birthDate = null;
            };

            CustomerController.prototype.setBirthDate = function () {
                var birthday = this.birthDate.split('-');
                var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

                var mon = months.indexOf(birthday[1]);
                var day = parseInt(birthday[0]) + 1;
                var year = parseInt(birthday[2]);

                this.customer.birthDate = new Date(year, mon, day);
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
                    _this.birthDate = null;
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

                    //this.customer.birthDate = date;
                    $('#birthdate').datepicker("setDate", date);
                }, this.logError);
            };
            return CustomerController;
        })();
        controllers.CustomerController = CustomerController;

        angular.module('mongoAngular').controller('CustomerController', [
            'CustomerService',
            CustomerController
        ]);
    })(mongoAngular.controllers || (mongoAngular.controllers = {}));
    var controllers = mongoAngular.controllers;
})(mongoAngular || (mongoAngular = {}));
//# sourceMappingURL=CustomerController.js.map

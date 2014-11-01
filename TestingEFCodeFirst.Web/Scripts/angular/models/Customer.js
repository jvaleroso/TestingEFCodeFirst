var mongoAngular;
(function (mongoAngular) {
    (function (models) {
        var Customer = (function () {
            function Customer() {
                this.id = '';
                this.firtName = '';
                this.lastName = '';
                this.middleInitial = '';
                this.birthDate = new Date();
                this.address = '';
            }
            return Customer;
        })();
        models.Customer = Customer;
    })(mongoAngular.models || (mongoAngular.models = {}));
    var models = mongoAngular.models;
})(mongoAngular || (mongoAngular = {}));
//# sourceMappingURL=Customer.js.map

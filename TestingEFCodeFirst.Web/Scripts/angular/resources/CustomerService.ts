

module mongoAngular.Resource {

    import customerModel = mongoAngular.models.Customer;

    export class CustomerService {

        private customerService: restangular.IElement;

        constructor(private restangular: restangular.IElement) {
            this.customerService = restangular.all('customer');
        }

        public saveCustomer(customer: customerModel): restangular.IPromise<customerModel> {
            return this.customerService.post(customer);
        }

        public getCustomers(): restangular.ICollectionPromise<customerModel> {
            return this.customerService.getList();
        }

        public getCustomerById(id: string): restangular.IPromise<customerModel> {
            return this.restangular.one('customer', id).get();
        }

        public removeCustomer(customer) {
            return customer.remove();
        }

        public updateCustomer(customer) {
            return customer.put();
        }
    }

    angular.module('mongoAngular')
        .service('CustomerService', [
            'Restangular',
            CustomerService
        ]);
} 
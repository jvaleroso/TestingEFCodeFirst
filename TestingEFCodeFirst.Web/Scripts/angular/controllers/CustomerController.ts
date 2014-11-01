module mongoAngular.controllers {

    import customerModel = mongoAngular.models.Customer;
    import customerService = mongoAngular.Resource.CustomerService;

    export class CustomerController {
        private customerList: customerModel[];
        private customer: customerModel;
        private showUpdateButton: boolean;
        private isLoadingData: boolean;
        private birthDate: string;

        constructor(private customerService: customerService) {
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

        private logError(error: Error) {
            console.log(error.message);
        }

        private resetCustomer(): void {
            this.customer = null;
        }

        public cancel(): void {
            this.customer = null;
            this.showUpdateButton = false;
            this.birthDate = null;
        }

        public setBirthDate() {
            var birthday = this.birthDate.split('-');
            var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

            var mon = months.indexOf(birthday[1]);
            var day = parseInt(birthday[0]) + 1;
            var year = parseInt(birthday[2]);

            this.customer.birthDate = new Date(year, mon, day);
        }

        public addCustomer(customer: customerModel): void {
            this.customerService.saveCustomer(customer).then((c: customerModel): void => {
                this.customerList.push(c);
                this.resetCustomer();
            }, this.logError);
        }

        public updateCustomer(customer) {

            this.customerService.updateCustomer(customer).then(() => {
                this.showUpdateButton = false;
                this.resetCustomer();
                this.getCustomers();
                this.birthDate = null;
            }, this.logError);
        }

        public deleteCustomer(id: string): void {

            this.customerService.getCustomerById(id).then((c: customerModel): void=> {
                this.customerService.removeCustomer(c).then((): void=> {
                    this.getCustomers();
                }, (error: Error): void=> {
                        console.log(error.message);
                    });
            }, (error: Error): void=> {
                    console.log(error.message);
                });
        }

        public getCustomers(): void {
            this.isLoadingData = true;

            this.customerService.getCustomers().then((customers: customerModel[]): void=> {
                this.customerList = customers;
                this.isLoadingData = false;
            }, this.logError);
        }

        public editCustomer(id: string): void {
            this.showUpdateButton = true;
            this.customerService.getCustomerById(id).then((c: customerModel): void => {
                this.customer = c;
                var date = new Date(c.birthDate.toString());
                //this.customer.birthDate = date;
                $('#birthdate').datepicker("setDate", date);
            }, this.logError);
        }
    }

    angular.module('mongoAngular')
        .controller('CustomerController', [
            'CustomerService',
            CustomerController
        ]);
}  
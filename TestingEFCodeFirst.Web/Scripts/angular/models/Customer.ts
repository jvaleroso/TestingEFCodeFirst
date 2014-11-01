module mongoAngular.models {

    export class Customer {
        public id: string;
        public firtName: string;
        public lastName: string;
        public middleInitial: string;
        public birthDate: Date;
        public address: string;

        constructor() {
            this.id = '';
            this.firtName = '';
            this.lastName = '';
            this.middleInitial = '';
            this.birthDate = new Date();
            this.address = '';
        }
    }
}


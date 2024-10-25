export interface User {
    username: string;
    email: string;
    password: string;
    token: string;
    roles: string[];
    usercustomerapplications: UserCustomerApplication[];
}

export interface UserCustomerApplication {
    applicationId: number;
    customer: Customer; 
}

export interface Customer {
    name: string;
}

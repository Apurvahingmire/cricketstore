export interface User{
    id: number;
    firstname: string;
    username: string;
    lastName: string;
    email: string;
    passwordHash: string;
    gender: number;
    dob: Date;
    phoneNo: number;
    address: string;
    roleId: number;
}
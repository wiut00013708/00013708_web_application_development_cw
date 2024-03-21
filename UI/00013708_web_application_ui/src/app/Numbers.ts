export interface Numbers{
    id: number,
    contactId: number,
    contact:{
        id: number,
        firstName: string,
        lastName: string,
        emailAddress: string
    },
    number: string,
    type: string
    
}
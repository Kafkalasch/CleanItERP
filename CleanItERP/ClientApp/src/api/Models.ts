

export interface Branch {
    id: number,
    name: string,
    city: string
}

export interface Customer {
    id: number,
    memberShipId: number,
    firstName: string,
    lastName: string
}
export interface Employee {
    id: number,
    socialSecurityNumber: number,
    firstName: string,
    lastName: string
}

export interface Textile {
    id: number,
    identifier: number,
    textileType: TextileType,
    textileState: TextileState
}

export enum TextileType {
    Jeans = "Jeans Trousers",
    Jacket = "Jacket"
}

export enum TextileState {
    Dirty = "Dirty",
    BeingWashed = "Being Washed",
    Drying = "Drying",
    Finished = "Finished"
}

export interface Order {
    id: number,
    identifier: number,
    dateReceived: string,
    dateReturned: string | null,
    branch: Branch,
    customer: Customer,
    clerk: Employee,
    textiles: Textile[]
}

export enum OrderState {
    Dirty = "Dirty",
    InProgress = "In progress",
    Finished = "Finished"
}

export const getFullName = (person: Customer | Employee) => person.firstName + " " + person.lastName;

export const getOrderState = (order: Order) => {
    if(allTextilesAreOfState(order.textiles, TextileState.Finished))
        return OrderState.Finished;
    if(allTextilesAreOfState(order.textiles, TextileState.Dirty))
        return OrderState.Dirty;
    return OrderState.InProgress;
}

const allTextilesAreOfState = (textiles: Textile[], referenceState: TextileState) => {
    const states = textiles.map(t => t.textileState);
    let allAreEqualToReferenceState = true;
    for(let state of states){
        if(state !== referenceState)
        {
            allAreEqualToReferenceState = false;
            break;
        }
    }
    return allAreEqualToReferenceState;
}
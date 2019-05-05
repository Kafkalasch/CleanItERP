import * as React from "react";
import { Customer, Employee, getFullName, getOrderState, Order } from "src/api/Models";
import { formatDate, isUndefinedOrNull } from "src/utils/utilities";
import "./CellRenderers.scss";
import { OrderStateRenderer } from "./OrderStateRenderer";

interface CellProps<ValueType> {
    value: ValueType
}

export const CustomerCell = (cellProps: CellProps<Customer>) => (
    <div>
        {getFullName(cellProps.value)}
    </div>
)

export const EmployeeCell = (cellProps: CellProps<Employee>) => (
    <div>
        {getFullName(cellProps.value)}
    </div>
)

export const DateCell = (cellProps: CellProps<string>) => {
    const dateString = cellProps.value;
    if(isUndefinedOrNull(dateString))
        return null;
    
    const representation = formatDate(dateString);
    return(
        <div>
            {representation}
        </div>
    )
}

export const TextileCell = (cellProps: { isExpanded: boolean, original: Order}) => {
    const textiles = cellProps.original.textiles;
    if(textiles.length == 0)
        return <div>0</div>;
    else
        return(
            <div className="textiles-cell">
                <span>{textiles.length}</span>
                {cellProps.isExpanded
                    ? <span className="expanded-symbol">&#x2299;</span>
                    : <span className="expanded-symbol">&#x2295;</span>}
            </div>
        )
}

export const OrderStateCell = (cellProps: CellProps<Order>) => {
    const order = cellProps.value;
    const state = getOrderState(order);
    return <OrderStateRenderer state={state} />
}
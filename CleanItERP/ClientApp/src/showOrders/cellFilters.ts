import { Column, DefaultFilterFunction, Filter } from "react-table";
import { Order } from "src/api/Models";
import { isUndefinedOrNull } from "src/utils/utilities";

const emptyFieldSearch = "<none>";

export const genericFilter: DefaultFilterFunction = (filter: Filter, row: any, col: any[]): boolean => {
    const column = col as Column<Order>;
    const order = row._original as Order;

    const targetValue = filter.value;
    const rowValue = (<any>column.accessor)(order);
    const containsTargetValue = (<string>rowValue.toString()).includes(targetValue);
    return containsTargetValue;
}

export const createFilter = (strValueMapper: (row: Order) => string): DefaultFilterFunction => {

    const filter: DefaultFilterFunction = (filter: Filter, row: any): boolean => {
        const order = row._original as Order;
        
        const targetValue = filter.value;
        let rowValue = strValueMapper(order);
        
        if(isUndefinedOrNull(rowValue) || rowValue === ""){
            rowValue = emptyFieldSearch;
        }

        const containsTargetValue = (<string>rowValue.toString()).includes(targetValue);
        return containsTargetValue;
    }
    return filter;
}
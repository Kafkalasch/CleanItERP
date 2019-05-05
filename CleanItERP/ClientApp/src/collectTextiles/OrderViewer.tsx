import { Card, Elevation } from "@blueprintjs/core";
import * as React from "react";
import { getFullName, Order } from "src/api/Models";
import { TextileList } from "src/showOrders/TextileList";
import { formatDate, isUndefinedOrNull } from "src/utils/utilities";


interface Props {
    order: Order,
}

export class OrderViewer extends React.Component<Props>{

    public render(){
        const order = this.props.order;

        if(isUndefinedOrNull(order))
            return null;
        

        return(
            <Card
                interactive={false}
                elevation={Elevation.ONE}>
                <h5>{order.identifier}</h5>
                <ul>
                    <li>Customer: {getFullName(order.customer)}</li>
                    <li>Clerk: {getFullName(order.clerk)}</li>
                    <li>Received: {formatDate(order.dateReceived)}</li>
                </ul>
                <TextileList textiles={order.textiles} />
            </Card>
        )
    }

}


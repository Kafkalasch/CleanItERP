import { Button, Card, Elevation, H5, Intent } from "@blueprintjs/core";
import { IconNames } from "@blueprintjs/icons";
import * as React from "react";
import { collectOrder } from "src/api/dataCommunication";
import { getFullName, Order } from "src/api/Models";
import { TextileList } from "src/showOrders/TextileList";
import { formatDate, isUndefinedOrNull } from "src/utils/utilities";
import "./CollectOrderCard.scss";

interface Props {
    order: Order,
    onOrderCollected: () => void
}

export class CollectOrderCard extends React.Component<Props>{

    public render(){
        const order = this.props.order;

        if(isUndefinedOrNull(order))
            return null;
        

        return(
            <Card className="collect-order-card"
                interactive={false}
                elevation={Elevation.ONE}>
                <H5>{order.identifier}</H5>
                <ul>
                    <li>Customer: {getFullName(order.customer)}</li>
                    <li>Clerk: {getFullName(order.clerk)}</li>
                    <li>Received: {formatDate(order.dateReceived)}</li>
                </ul>
                <TextileList textiles={order.textiles} />
                <Button
                    icon={IconNames.CONFIRM}
                    intent={Intent.PRIMARY}
                    onClick={this.onCollect}>
                    Collect
                </Button>
            </Card>
        )

    }

    private onCollect = async () => {
        await collectOrder(this.props.order);
        this.props.onOrderCollected();
    }

}


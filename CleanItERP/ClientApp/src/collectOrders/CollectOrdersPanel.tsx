import * as React from "react";
import { Order } from "src/api/Models";
import { PanelProps } from "src/Navigation/PanelFactory";
import { CollectOrderCard } from "./CollectOrderCard";
import { FinishedOrderSelector } from "./FinishedOrderSelector";

interface State {
    selectedOrder: Order,
}

const createInitialState = () : State => ({
    selectedOrder: null
})

export class CollectOrdersPanel extends React.Component<PanelProps, State>{

    public state = createInitialState();

    public render(){
        return(
            <div>
                <FinishedOrderSelector 
                    branch={this.props.branch}
                    selectedOrder={this.state.selectedOrder}
                    onOrderSelect={this.onOrderSelect}
                    />
                <CollectOrderCard order={this.state.selectedOrder} />

            </div>
        )
    }

    private onOrderSelect = (newOrder: Order) => {
        this.setState({
            selectedOrder: newOrder
        })
    }
}


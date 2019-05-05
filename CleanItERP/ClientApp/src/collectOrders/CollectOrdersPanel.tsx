import * as React from "react";
import { Order } from "src/api/Models";
import { PanelProps } from "src/Navigation/PanelFactory";
import { CollectableOrderSelector } from "./CollectableOrderSelector";
import { CollectOrderCard } from "./CollectOrderCard";

interface State {
    selectedOrder: Order,
    refreshCollectableOrderListToggle: boolean
}

const createInitialState = () : State => ({
    selectedOrder: null,
    refreshCollectableOrderListToggle: true
})

export class CollectOrdersPanel extends React.Component<PanelProps, State>{

    public state = createInitialState();

    public render(){
        return(
            <div>
                <CollectableOrderSelector 
                    branch={this.props.branch}
                    selectedOrder={this.state.selectedOrder}
                    onOrderSelect={this.onOrderSelect}
                    refreshOrderListToggle={this.state.refreshCollectableOrderListToggle}
                    />
                <CollectOrderCard order={this.state.selectedOrder} onOrderCollected={this.onOrderCollected} />

            </div>
        )
    }

    private onOrderSelect = (newOrder: Order) => {
        this.setState({
            selectedOrder: newOrder
        })
    }

    private onOrderCollected = () => {
        this.setState(prevState => ({
            refreshCollectableOrderListToggle: !prevState.refreshCollectableOrderListToggle
        }));
    }
}


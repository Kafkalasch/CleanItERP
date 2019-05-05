import * as React from "react";
import { Order } from "src/api/Models";
import { PanelProps } from "src/Navigation/PanelFactory";
import { FinishedOrderSelector } from "./FinishedOrderSelector";
import { OrderViewer } from "./OrderViewer";

interface State {
    selectedOrder: Order,
}

const createInitialState = () : State => ({
    selectedOrder: null
})

export class CollectTextilesPanel extends React.Component<PanelProps, State>{

    public state = createInitialState();

    public render(){
        return(
            <div>
                <FinishedOrderSelector 
                    branch={this.props.branch}
                    selectedOrder={this.state.selectedOrder}
                    onOrderSelect={this.onOrderSelect}
                    />
                <OrderViewer order={this.state.selectedOrder} />

            </div>
        )
    }

    private onOrderSelect = (newOrder: Order) => {
        this.setState({
            selectedOrder: newOrder
        })
    }
}


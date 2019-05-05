import { HTMLSelect } from "@blueprintjs/core";
import * as React from "react";
import { retrieveFinishedOrders } from "src/api/dataCommunication";
import { Branch, getFullName, Order } from "src/api/Models";
import { isDefinedAndNotNull, isUndefinedOrNull } from "src/utils/utilities";

interface Props {
    branch: Branch,
    selectedOrder: Order,
    onOrderSelect: (newOrder: Order) => void
}

interface State {
    finishedOrders: Order[];
}

const createInitialState = () : State => ({
    finishedOrders: []
})

export class FinishedOrderSelector extends React.Component<Props, State>{

    public state = createInitialState();

    public async componentDidMount() {
        if (isDefinedAndNotNull(this.props.branch)) {
            await this.updateOrders();
        }
    }

    public async componentDidUpdate(prevProps: Props, prevState: State) {
        if (prevProps.branch !== this.props.branch
            && isDefinedAndNotNull(this.props.branch)) {
            await this.updateOrders();
        }
    }

    async updateOrders() {
        const orders = await retrieveFinishedOrders(this.props.branch);
        this.setState({
            finishedOrders: orders
        })
        if(orders.length > 0){
            this.props.onOrderSelect(orders[0]);
        }else{
            this.props.onOrderSelect(null);
        }
    }

    render(){
        let orders: string[];
        if(this.state.finishedOrders.length === 0)
        {
            orders = [ "no finished orders found"]
        }else{
            orders = this.state.finishedOrders.map(order => this.convertOrderToOptionString(order));
        }

        return(
            <div className="finished-order-selector">
                <span>Select order: </span>
                <HTMLSelect
                    options={orders}
                    value={this.getSelectedOptionString()}
                    onChange={this.onChange}
                />
            </div>
        )
    }
    
    private getSelectedOptionString = () => {
        if(isUndefinedOrNull(this.props.selectedOrder)){
            return "no order selected";
        }else{
            return this.convertOrderToOptionString(this.props.selectedOrder);
        }
    }

    private onChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        const optionString = event.target.value;
        const order = this.convertOptionStringToOrder(optionString);
        this.props.onOrderSelect(order);
    }

    private convertOrderToOptionString = (order : Order) => order.identifier + " -- " + getFullName(order.customer);

    private convertOptionStringToOrder = (str: string) => {
        const order = this.state.finishedOrders.find(order => str.startsWith(order.identifier.toString()));
        return isUndefinedOrNull(order) ? null : order;

    }
}
import { HTMLSelect } from "@blueprintjs/core";
import * as React from "react";
import { retrieveCollectableOrders } from "src/api/dataCommunication";
import { Branch, getFullName, Order } from "src/api/Models";
import { isDefinedAndNotNull, isUndefinedOrNull } from "src/utils/utilities";

interface Props {
    branch: Branch,
    selectedOrder: Order,
    onOrderSelect: (newOrder: Order) => void,
    refreshOrderListToggle: boolean
}

interface State {
    collectableOrders: Order[];
}

const createInitialState = () : State => ({
    collectableOrders: []
})

export class CollectableOrderSelector extends React.Component<Props, State>{

    public state = createInitialState();

    public async componentDidMount() {
        if (isDefinedAndNotNull(this.props.branch)) {
            await this.updateOrders();
        }
    }

    public async componentDidUpdate(prevProps: Props, prevState: State) {
        if (this.branchChangedAndIsDefined(prevProps)
            || this.refreshToggleTriggered(prevProps)) {
            await this.updateOrders();
        }
    }

    private branchChangedAndIsDefined = (prevProps: Props) => {
        return prevProps.branch !== this.props.branch
            && isDefinedAndNotNull(this.props.branch);
    }

    private refreshToggleTriggered = (prevProps: Props) => {
        return prevProps.refreshOrderListToggle !== this.props.refreshOrderListToggle;
    }

    async updateOrders() {
        const orders = await retrieveCollectableOrders(this.props.branch);
        this.setState({
            collectableOrders: orders
        })
        if(orders.length > 0){
            this.props.onOrderSelect(orders[0]);
        }else{
            this.props.onOrderSelect(null);
        }
    }

    render(){
        let orders: string[];
        if(this.state.collectableOrders.length === 0)
        {
            orders = [ "no collectable orders found"]
        }else{
            orders = this.state.collectableOrders.map(order => this.convertOrderToOptionString(order));
        }

        return(
            <div className="collectable-order-selector">
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
        const order = this.state.collectableOrders.find(order => str.startsWith(order.identifier.toString()));
        return isUndefinedOrNull(order) ? null : order;

    }
}
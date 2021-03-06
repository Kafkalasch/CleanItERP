import { Button } from "@blueprintjs/core";
import * as React from "react";
import ReactTable, { Column } from "react-table";
import { retrieveOrders } from "src/api/dataCommunication";
import { getFullName, getOrderState, Order } from "src/api/Models";
import { PanelProps } from "src/Navigation/PanelFactory";
import { formatDate, isDefinedAndNotNull, isUndefinedOrNull } from "src/utils/utilities";
import { createFilter, genericFilter } from "./cellFilters";
import { CustomerCell, DateCell, EmployeeCell, OrderStateCell, TextileCell } from "./CellRenderers";
import "./OrderTable.scss";
import { renderTextileListAsSubcomponent } from "./TextileList";


interface State {
    orders: Order[],
    filterable: boolean
}

const createInitialState = (): State => ({
    orders: [],
    filterable: false
})

const columns: Column<Order>[] = [
    {
        id: "id",
        Header: "Id",
        accessor: o => o.identifier,
        filterMethod: genericFilter
    },
    {
        id: "customer",
        Header: "Customer",
        accessor: o => o.customer,
        Cell: CustomerCell,
        filterMethod: createFilter( o => getFullName(o.customer))
    },
    {
        id: "clerk",
        Header: "Clerk",
        accessor: o => o.clerk,
        Cell: EmployeeCell,
        filterMethod: createFilter( o => getFullName(o.clerk))
    },
    {
        id: "dateReceived",
        Header: "Received",
        accessor: o => o.dateReceived,
        Cell: DateCell,
        filterMethod: createFilter( o => formatDate(o.dateReceived))
    },
    {
        id: "dateReturned",
        Header: "Returned",
        accessor: o => o.dateReturned,
        Cell: DateCell,
        filterMethod: createFilter( o => formatDate(o.dateReturned))
    },
    {
        id: "state",
        Header: "State",
        accessor: o => o,
        Cell: OrderStateCell,
        filterMethod: createFilter( o => getOrderState(o))
    },
    {
        id: "textiles",
        expander: true,
        Header: "Textiles",
        accessor: o => o.textiles,
        Expander: TextileCell,
        width: 70
    }
]

export class OrderTable extends React.Component<PanelProps, State>{

    public state = createInitialState();

    public async componentDidMount() {
        if (isDefinedAndNotNull(this.props.branch)) {
            await this.updateOrders();
        }
    }

    public async componentDidUpdate(prevProps: PanelProps, prevState: State) {
        if (prevProps.branch !== this.props.branch
            && isDefinedAndNotNull(this.props.branch)) {
            await this.updateOrders();
        }
    }

    private updateOrders = async () => {
        const orders = await retrieveOrders(this.props.branch);
        this.setState({
            orders: orders
        })
    }

    public render() {
        if (isUndefinedOrNull(this.props.branch))
            return <div>no branch selected</div>

        return (
            <div>
                <div className="control-buttons-bar">
                    <Button className="toggle-filter-button" onClick={this.onToggleFilterable}>
                        {this.state.filterable ? "hide filters" : "show filters"}
                    </Button>
                </div>
                <ReactTable
                    columns={columns}
                    data={this.state.orders}
                    showPagination={false}
                    minRows={1}
                    filterable={this.state.filterable}
                    SubComponent={renderTextileListAsSubcomponent}
                />
            </div>
        )
    }

    private onToggleFilterable = () => {
        this.setState(prevState => ({
            filterable: !prevState.filterable
        }));
    }



}

import * as React from "react";
import { Branch } from "./api/Models";
import "./App.scss";
import { Footer } from "./Navigation/Footer";
import { Header } from "./Navigation/Header";
import { OrderTable } from "./showOrders/OrderTable";

interface Props { }

interface State {
    selectedBranch: Branch
}

const createInitialState = () : State => ({
    selectedBranch: null
})

export class App extends React.Component<Props, State>{

    public state = createInitialState();

    public render(){
        return (
            <div className="app">
                <Header 
                    selectedBranch={this.state.selectedBranch}
                    onBranchSelect={this.onBranchSelect}/>
                <div className="main">
                    <OrderTable branch={this.state.selectedBranch} />
                </div>
                <Footer />
            </div>
        )
    }

    private onBranchSelect = (newBranch : Branch) => {
        this.setState({
            selectedBranch: newBranch
        })
    } 
}
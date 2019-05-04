import * as React from "react";
import { Branch } from "./api/Models";
import "./App.scss";
import { Footer } from "./Navigation/Footer";
import { Header } from "./Navigation/Header";
import { createPanel, Panel } from "./Navigation/PanelFactory";


interface Props { }

interface State {
    selectedBranch: Branch,
    selectedPanel: Panel
}

const createInitialState = () : State => ({
    selectedBranch: null,
    selectedPanel: Panel.ShowOrders
})

export class App extends React.Component<Props, State>{

    public state = createInitialState();

    public render(){
        return (
            <div className="app">
                <Header 
                    selectedBranch={this.state.selectedBranch}
                    onBranchSelect={this.onBranchSelect}
                    selectedPanel={this.state.selectedPanel}
                    onPanelClick={this.onPanelSelect}/>
                <div className="main">
                    {createPanel(this.state.selectedPanel, { branch: this.state.selectedBranch })}
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

    private onPanelSelect = (showPanel: Panel) => {
        this.setState({
            selectedPanel: showPanel
        })
    }
}
import * as React from "react";
import { Branch } from "./api/Models";
import "./App.scss";
import { Footer } from "./Navigation/Footer";
import { Header } from "./Navigation/Header";

interface Props {

}

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
                    {this.state.selectedBranch !== null ?
                        this.state.selectedBranch.name
                        : "null"}
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
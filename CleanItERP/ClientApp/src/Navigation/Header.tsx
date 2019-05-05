import { Alignment, Button, Intent, Navbar, NavbarDivider, NavbarGroup, NavbarHeading } from "@blueprintjs/core";
import * as React from "react";
import { Branch } from "src/api/Models";
import { BranchSelector } from "./BranchSelector";
import "./Header.scss";
import { Panel } from "./PanelFactory";
interface Props {
    selectedBranch: Branch,
    onBranchSelect: (newBranch: Branch) => void,
    selectedPanel: Panel,
    onPanelClick: (panel: Panel) => void
}

export class Header extends React.Component<Props>{

    public render(){

        return(
            <Navbar className="header">
                <NavbarGroup align={Alignment.LEFT}>
                    <NavbarHeading>Clean It!</NavbarHeading>
                    <NavbarDivider />
                    {this.createPanelClickButton(Panel.ShowOrders)}
                    {this.createPanelClickButton(Panel.CollectOrder)}
                </NavbarGroup>
                <NavbarGroup align={Alignment.RIGHT}>
                    <BranchSelector
                        selectedBranch={this.props.selectedBranch}
                        onBranchSelect={this.props.onBranchSelect} />
                </NavbarGroup>
            </Navbar>
        );
    }

    private createPanelClickButton = (panel: Panel) => (
        <Button 
            className="panel-button"
            intent={panel === this.props.selectedPanel ? Intent.PRIMARY : Intent.NONE}
            onClick={() => this.props.onPanelClick(panel)}>
            {panel}
        </Button>
    )

}
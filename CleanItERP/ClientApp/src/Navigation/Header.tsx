import { Alignment, Navbar, NavbarDivider, NavbarGroup, NavbarHeading } from "@blueprintjs/core";
import * as React from "react";
import { Branch } from "src/api/Models";
import BranchSelector from "./BranchSelector";

interface Props {
    selectedBranch: Branch,
    onBranchSelect: (newBranch: Branch) => void
}

export class Header extends React.Component<Props>{

    render(){

        return(
            <Navbar className="header">
                <NavbarGroup align={Alignment.LEFT}>
                    <NavbarHeading>Clean It!</NavbarHeading>
                    <NavbarDivider />
                    
                </NavbarGroup>
                <NavbarGroup align={Alignment.RIGHT}>
                    <BranchSelector
                        selectedBranch={this.props.selectedBranch}
                        onBranchSelect={this.props.onBranchSelect} />
                </NavbarGroup>
            </Navbar>
        );
    }
}
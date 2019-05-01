import { Alignment, Navbar, NavbarDivider, NavbarGroup, NavbarHeading } from "@blueprintjs/core";
import * as React from "react";

export class Header extends React.Component{


    render(){

        return(
            <Navbar className="header">
                <NavbarGroup align={Alignment.LEFT}>
                    <NavbarHeading>Clean It!</NavbarHeading>
                    <NavbarDivider />
                    hier steht was
                </NavbarGroup>
            </Navbar>
        );
    }
}
import { Alignment, Classes, Navbar, NavbarGroup } from "@blueprintjs/core";
import * as React from "react";
import "./Footer.scss";

export class Footer extends React.Component{


    render(){

        return(
            <Navbar className="footer">
                <NavbarGroup className="footer-group" align={Alignment.RIGHT}>
                    <div className={Classes.TEXT_MUTED}>created by Michael Höfler</div>
                </NavbarGroup>
            </Navbar>
        );
    }
}
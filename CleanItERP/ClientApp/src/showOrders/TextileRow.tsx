import { Icon } from "@blueprintjs/core";
import * as React from "react";
import { Textile } from "src/api/Models";
import "./TextileRow.scss";
import { TextileStateRenderer } from "./TextileStateRenderer";

interface Props{
    textile: Textile
}

export class TextileRow extends React.Component<Props>{

    public render(){
        const textile = this.props.textile;
        return(
            <div className="textile-row">
                <Icon icon="play"/>
                <div className="textile-identifier">{textile.identifier}</div>
                <div className="textile-type">{textile.textileType}</div>
                <TextileStateRenderer state={textile.textileState} />
            </div>
        )
    }
}
import * as React from "react";
import { RowInfo, SubComponentFunction } from "react-table";
import { Order, Textile } from "src/api/Models";
import { TextileRow } from "./TextileRow";

interface Props{
    textiles: Textile[]
}

export class TextileList extends React.Component<Props>{

    public render(){
        return(
            <div>
                {this.props.textiles.map( 
                    textile =>
                        <TextileRow textile={textile} key={textile.id} />
                    )}
            </div>
        )
    }

}


export const renderTextileListAsSubcomponent : SubComponentFunction = (rowInfo: RowInfo) => {
    const order: Order = rowInfo.original;
    return <TextileList textiles={order.textiles} />
}
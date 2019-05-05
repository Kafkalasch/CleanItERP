import { Colors, Icon, IconName } from "@blueprintjs/core";
import { IconNames } from "@blueprintjs/icons";
import { Color } from "csstype";
import * as React from "react";
import { OrderState } from "src/api/Models";
import "./OrderStateRenderer.scss";

interface Props {
    state: OrderState
}

export class OrderStateRenderer extends React.Component<Props>{
    
    public render(){
        let iconName: IconName;
        let color: Color;
        switch(this.props.state){
            case OrderState.Dirty:
                iconName = IconNames.HEATMAP;
                color = Colors.RED4;
                break;
            case OrderState.InProgress:
                iconName = IconNames.TINT;
                color = Colors.BLUE2;
                break;
            case OrderState.Finished:
                iconName = IconNames.CLEAN;
                color = Colors.GREEN2;
                break;
            case OrderState.Returned:
                iconName = IconNames.TICK_CIRCLE;
                color = Colors.GREEN5;
                break;
            default:
                console.error("did not recognize the order state: ", this.props.state);
        }

        return(
            <div className="order-state-renderer">
                <Icon className="order-state-icon" icon={iconName} color={color}/>
                <span>{this.props.state}</span>
            </div>
        )
    }
}


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
            case OrderState.Finished:
                iconName = IconNames.CLEAN;
                color = Colors.GREEN2;
                break;
            case OrderState.Dirty:
                iconName = IconNames.HEATMAP;
                color = Colors.RED4;
                break;
            case OrderState.InProgress:
                iconName = IconNames.TINT;
                color = Colors.BLUE2;
                break;
        }

        return(
            <div className="order-state-renderer">
                <Icon className="order-state-icon" icon={iconName} color={color}/>
                <span>{this.props.state}</span>
            </div>
        )
    }
}


import { Colors, Icon, IconName } from "@blueprintjs/core";
import { IconNames } from "@blueprintjs/icons";
import { Color } from "csstype";
import * as React from "react";
import { TextileState } from "src/api/Models";
import "./TextileStateRenderer.scss";

interface Props {
    state: TextileState
}

export class TextileStateRenderer extends React.Component<Props>{
    
    public render(){
        let iconName: IconName;
        let color: Color;
        switch(this.props.state){
            case TextileState.Finished:
                iconName = IconNames.CLEAN;
                color = Colors.GREEN2;
                break;
            case TextileState.Dirty:
                iconName = IconNames.HEATMAP;
                color = Colors.RED4;
                break;
            case TextileState.BeingWashed:
                iconName = IconNames.TINT;
                color = Colors.BLUE2;
                break;
            case TextileState.Drying:
                iconName = IconNames.FLASH;
                color = Colors.ORANGE3;
                break;
            default:
                console.error("did not recognize the textile state: ", this.props.state);
        }

        return(
            <div className="textile-state-renderer">
                <Icon className="textile-state-icon" icon={iconName} color={color}/>
                <span>{this.props.state}</span>
            </div>
        )
    }
}


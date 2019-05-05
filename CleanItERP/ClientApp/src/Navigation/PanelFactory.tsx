import * as React from "react";
import { Branch } from "src/api/Models";
import { CollectOrdersPanel } from "src/collectOrders/CollectOrdersPanel";
import { OrderTable } from "src/showOrders/OrderTable";

export enum Panel {
    ShowOrders = "Show Orders",
    CollectOrder = "Collect Order"
}

export interface PanelProps {
    branch: Branch
}

export const createPanel = (panel: Panel, props: PanelProps) => {
    switch(panel){
        case Panel.ShowOrders:
            return <OrderTable {...props} />;
        case Panel.CollectOrder:
            return <CollectOrdersPanel {...props} />;
        default:
            console.error("Did not find the panel: ", panel);
    }
}
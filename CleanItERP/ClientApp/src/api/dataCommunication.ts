import axios from "axios";
import { Branch, Order } from "./Models";
import { getCollectOrderUrl, getGetAllBranchesUrl, getGetCollectableOrdersOfBranchUrl, getGetOrdersOfBranchUrl } from "./routing";

export const retrieveBranches = async () : Promise<Branch[]> => {
    const url = getGetAllBranchesUrl();
    const response = await axios.get(url);
    return response.data;
}

export const retrieveOrders = async (branch: Branch) : Promise<Order[]> => {
    const url = getGetOrdersOfBranchUrl(branch);
    const response = await axios.get(url);
    return response.data;
}

export const retrieveCollectableOrders = async (branch: Branch) : Promise<Order[]> => {
    const url = getGetCollectableOrdersOfBranchUrl(branch);
    const response = await axios.get(url);
    return response.data;
}

export const collectOrder = async (order: Order) : Promise<void> => {
    const url = getCollectOrderUrl(order);
    await axios.patch(url);
}
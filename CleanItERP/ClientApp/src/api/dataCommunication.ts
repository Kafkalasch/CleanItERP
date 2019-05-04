import axios from "axios";
import { Branch, Order } from "./Models";
import { getGetAllBranchesUrl, getGetOrdersOfBranchUrl } from "./routing";

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
import urljoin = require("url-join");
import { Branch, Order } from "./Models";


const backendUrl = "http://localhost:5000";

export const getGetAllBranchesUrl = () => urljoin(backendUrl, "api/Branch/All");

export const getGetOrdersOfBranchUrl = (branch: Branch) => urljoin(backendUrl, "api/Order/ForBranch", branch.id.toString());

export const getGetCollectableOrdersOfBranchUrl = (branch: Branch) => urljoin(backendUrl, "api/Order/CollectableOrdersForBranch", branch.id.toString());

export const getCollectOrderUrl = (order: Order) => urljoin(backendUrl, "api/Order/CollectOrder", order.id.toString());
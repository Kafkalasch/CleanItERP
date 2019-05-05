import urljoin = require("url-join");
import { Branch } from "./Models";


const backendUrl = "http://localhost:5000";

export const getGetAllBranchesUrl = () => urljoin(backendUrl, "api/Branch/All");

export const getGetOrdersOfBranchUrl = (branch: Branch) => urljoin(backendUrl, "api/Order/ForBranch", branch.id.toString());

export const getGetFinishedOrdersOfBranchUrl = (branch: Branch) => urljoin(backendUrl, "api/Order/FinishedOrdersForBranch", branch.id.toString());

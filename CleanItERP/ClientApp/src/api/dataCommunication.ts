import axios from "axios";
import { Branch } from "./Models";
import { getAllBranchesUrl as getGetAllBranchesUrl } from "./routing";

export const retrieveBranches = async () : Promise<Branch[]> => {
    const url = getGetAllBranchesUrl();
    const response = await axios.get(url);
    return response.data;
}
import urljoin = require("url-join");


const backendUrl = "http://localhost:5000";

export const getAllBranchesUrl = () => urljoin(backendUrl, "api/Branch/All");
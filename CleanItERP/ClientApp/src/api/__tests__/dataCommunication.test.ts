import axios from "axios";
import { retrieveBranches } from "../dataCommunication";
import { Branch } from "../Models";

jest.mock("axios");


test("retrieves branches", async () => {
    const branches : Branch[] = [
        {
            id: 1,
            city: "City1",
            name: "Branch1"
        }
    ]
    const response = { data: branches };
    (<any> axios).get.mockResolvedValue(response);

    expect(retrieveBranches()).resolves.toBe(branches);
});
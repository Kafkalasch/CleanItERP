import { isUndefinedOrNull } from "../utilities";


describe("isUndefinedOrNull", () => {
    test("returns true if null", () => {
        expect(isUndefinedOrNull(null)).toBe(true);
    });

    test("return true if undefined", () => {
        expect(isUndefinedOrNull(undefined)).toBe(true);
    });

    test("return false if 0", () => {
        expect(isUndefinedOrNull(0)).toBe(false);
    });

    test("return false if []", () => {
        expect(isUndefinedOrNull([])).toBe(false);
    });

    test("return false if {}", () => {
        expect(isUndefinedOrNull({})).toBe(false);
    });
})
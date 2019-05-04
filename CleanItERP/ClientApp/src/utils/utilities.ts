

export const isUndefinedOrNull = (obj: any) => {
    return obj === undefined || obj === null;
}

export const isDefinedAndNotNull = (obj: any) => !isUndefinedOrNull(obj);
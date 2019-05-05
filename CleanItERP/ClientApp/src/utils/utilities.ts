import * as moment from "moment";


export const isUndefinedOrNull = (obj: any) => {
    return obj === undefined || obj === null;
}

export const isDefinedAndNotNull = (obj: any) => !isUndefinedOrNull(obj);

export const formatDate = (dateString: string) => {
    return moment(dateString).format("YYYY-MM-DD hh:mm");
}
import { api } from "../lib/axios"

export const getBooks = async ({ searchBy, value, pageSize, pageNumber }) => {
    try {
        const resp = await api.get(`/books/by/${searchBy}/${value}`, {
            params: {
                pageSize,
                pageNumber
            }
        });
        console.log(resp);
        return resp.data;
    } catch {
        throw new Error("Was not possible retrive the books now. Please try again later.")
    }
}
import { render, screen, fireEvent, within, waitFor, act } from "@testing-library/react"
import Home from "."
import { getBooks } from "../../requests/getBooks"

jest.mock("../../requests/getBooks", () => ({
    getBooks: jest.fn()
}))

describe('Home', () => {
    it('should get books with parameters', async () => {
        render(<Home />)

        const selectBtn = screen.getByRole('button', {
            name: /search by author/i
        })

        fireEvent.mouseDown(selectBtn)
        const listbox = within(screen.getByRole('listbox'));
        fireEvent.click(listbox.getByText(/isbn/i))

        const input = screen.getByRole('textbox', {
            name: /value/i
        })

        fireEvent.change(input, { target: { value: '1234' } })
        const button = screen.getByTestId('submit-button')
        fireEvent.click(button)

        expect(getBooks).toHaveBeenCalledWith({ "pageNumber": 0, "pageSize": 5, "searchBy": "isbn", "value": "1234" })
    })
    it('should render table when data.items has length greater than 0', async () => {
        getBooks.mockResolvedValue({
            total: 15,
            items: [
                {
                    id: 1,
                    title: 'title',
                    author: 'author',
                    category: 'category',
                    isbn: 'isbn',
                    totalCopies: 'totalCopies',
                    type: 'type'
                }
            ]
        })
        render(<Home />)
        const selectBtn = screen.getByRole('button', {
            name: /search by author/i
        })

        fireEvent.mouseDown(selectBtn)
        const listbox = within(screen.getByRole('listbox'));
        fireEvent.click(listbox.getByText(/isbn/i))

        const input = screen.getByRole('textbox', {
            name: /value/i
        })

        fireEvent.change(input, { target: { value: '1234' } })
        const button = screen.getByTestId('submit-button')
        fireEvent.click(button)

        await waitFor(() => {
            const tableTitle = screen.getByText('title')
            expect(tableTitle).toBeDefined()
        })
    })
})
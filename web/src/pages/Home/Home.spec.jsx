import { render, screen } from "@testing-library/react"
import UserEvent from "@testing-library/user-event"
import Home from "."

describe('Home', () => {
    it('should be able to select an option', () => {
        const userEvt = UserEvent.setup()
        render(<Home />)

        const selectBtn =  screen.getByRole('button', {
            name: /search by author/i
          })

        userEvt.click(selectBtn);

        screen.logTestingPlaygroundURL();

        //expect(true).toBe(t)
    })

})
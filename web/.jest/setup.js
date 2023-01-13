jest.mock("../src/lib/axios", () => {
    return {
        get: jest.fn()
    }
})
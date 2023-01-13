import { GlobalStyles } from "./styles/globalStyles"
import { BrowserRouter } from "react-router-dom"
import { AppRoutes } from "./routes"
import { ToastContainer } from "react-toastify";

import 'react-toastify/dist/ReactToastify.css';

function App() {

  return (
    <BrowserRouter>
      <AppRoutes/>
      <GlobalStyles/>
      <ToastContainer theme="colored" />
    </BrowserRouter>
  )
}

export default App

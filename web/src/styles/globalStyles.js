import { createGlobalStyle } from 'styled-components'

import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

export const GlobalStyles = createGlobalStyle`


    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    html, body, #root {
        height: 100%;
        font-family: 'Roboto', sans-serif;
    }

    button {
        cursor: pointer;
    }
`
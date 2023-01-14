import { Container, Select, FormControl, InputLabel, MenuItem, TextField, Button } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { useState } from "react";
import { getBooks } from "../../requests/getBooks";
import * as S from "./styles"
import { toast } from "react-toastify";

const selectDefaultValue = 'author';
const textDefaultValue = '';
const gridColumsn = [
    { field: "title", headerName: "Title", sortable: false, flex: 1, },
    { field: "author", headerName: "Author", sortable: false, flex: 1, },
    { field: "category", headerName: "Category", sortable: false, flex: 1, },
    { field: "isbn", headerName: "ISBN", sortable: false, flex: 1, },
    { field: "totalCopies", headerName: "Total Copies", sortable: false, flex: 1, },
    { field: "type", headerName: "Type", sortable: false, flex: 1, },
]

export default function Home() {
    const [selectValue, setSelectValue] = useState(selectDefaultValue)
    const [textValue, setTextValue] = useState(textDefaultValue)
    const [data, setData] = useState([])
    const [loading, setLoading] = useState(false)

    const handleChangeSelect = (value) => {
        setSelectValue(value.target.value ?? selectDefaultValue);
        setTextValue(textDefaultValue);
    }

    const handleChangeText = (value) => {
        let text = value.target.value ?? textDefaultValue;

        if (selectValue == 'isbn') {
            text = text.replace(/\D/g, '');
        }

        setTextValue(text);
    }

    const handleQueryBooks = async (pageNumber = 0) => {
        setLoading(true);

        try {
            const operationResult = await getBooks({
                searchBy: selectValue,
                value: textValue,
                pageSize: 5,
                pageNumber
            });

            setData({
                totalCount: operationResult.total,
                items: operationResult.items
            });
        } catch (err) {
            toast.error(err.message);
        } finally {
            setLoading(false);
        }
    }
    return (
        <Container>
            <S.HomeTitleContainer>
                <h1>Royal Library</h1>
            </S.HomeTitleContainer>
            <S.SearchContainer>
                <FormControl fullWidth>
                    <InputLabel id="select-label-search">Search By</InputLabel>
                    <Select
                        labelId="select-label-search"
                        id="select-search"
                        value={selectValue}
                        label="search-by"
                        onChange={handleChangeSelect}
                    >
                        <MenuItem value={'author'}>Author</MenuItem>
                        <MenuItem value={'isbn'}>ISBN</MenuItem>
                        <MenuItem value={'title'}>own/love/want</MenuItem>
                    </Select>
                </FormControl>
                <TextField label="Value" value={textValue} onChange={handleChangeText} />
                <Button disabled={!textValue} variant="contained" onClick={() => handleQueryBooks(0)} data-testid='submit-button'>Search</Button>
            </S.SearchContainer>
            {
                data.items?.length > 0 && (
                    <S.DataGridContainer>
                        <DataGrid
                            rows={data.items || []}
                            columns={gridColumsn}
                            rowsPerPageOptions={[5]}
                            pageSize={5}
                            onPageChange={handleQueryBooks}
                            rowCount={data.totalCount}
                            loading={loading}
                            paginationMode="server"
                            disableColumnFilter
                            disableSelectionOnClick
                            disableColumnMenu
                        />
                    </S.DataGridContainer>
                )
            }
        </Container>
    )
}
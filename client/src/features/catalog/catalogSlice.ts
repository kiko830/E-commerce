import { createSlice } from "@reduxjs/toolkit/react";
import type { ProductParams } from "../../app/models/productParams";

const initialState: ProductParams = {
    orderBy: 'name',
    searchTerm: '',
    brands: [],
    types: [],
    pageNumber: 1,
    pageSize: 8
};

export const catalogSlice = createSlice({
    name: 'catalog',
    initialState,
    reducers: {
        setPageNumber: (state, action) => {
            state.pageNumber = action.payload;
        },
        setPageSize: (state, action) => {
            state.pageSize = action.payload;
        },
        setOrderBy: (state, action) => {
            state.orderBy = action.payload;
            state.pageNumber = 1;
        },
        setTypes: (state, action) => {
            state.types = action.payload;
            state.pageNumber = 1;
        },
        setBrands: (state, action) => {
            state.brands = action.payload;
            state.pageNumber = 1;
        },
        setSearchTerm: (state, action) => {
            state.searchTerm = action.payload;
            state.pageNumber = 1;
        },

        // setProductParams: (state, action) => {
        //     return { ...state, ...action.payload };
        // },

        resetParams: () => initialState
    }
});

export const { setPageNumber, setPageSize, setOrderBy, setTypes, setBrands, setSearchTerm, resetParams } = catalogSlice.actions;

import { debounce, TextField } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../app/store/store";
import { setSearchTerm } from "./catalogSlice";
import { useEffect, useState } from "react";

export default function Search() {
 const {searchTerm} = useAppSelector(state => state.catalog);
 const dispatch = useAppDispatch();

 //debounce search
 const [term, setTerm] = useState(searchTerm);

 useEffect(() => {
   setTerm(searchTerm);
 }, [searchTerm]);

 const debouncedSearch = debounce(event => {
   dispatch(setSearchTerm(event.target.value));
 }, 500);

 //same functionality without debounce() in Material UI
//  useEffect(() => {
//    const timer = setTimeout(() => {
//      dispatch(setSearchTerm(term));
//    }, 500);

//    return () => clearTimeout(timer);
//  }, [term]);

  return (
    <TextField label="Search products" variant="outlined" fullWidth 
        type="search"
        value={term}
        onChange={e => {setTerm(e.target.value); debouncedSearch(e)}}
    />
  )
}

import { Grid, Typography } from "@mui/material"
import ProductList from "./ProductList"
import { useFetchFiltersQuery, useFetchProductsQuery } from "./catalogApi"
import Filters from "./Filters"
import { useAppDispatch, useAppSelector } from "../../app/store/store"
import AppPagination from "../../app/shared/components/AppPagination"
import { setPageNumber } from "./catalogSlice"


export default function Catalog() {
  const productParams = useAppSelector(state => state.catalog);
  const {data, isLoading} = useFetchProductsQuery(productParams)
    const { data:filtersData, isLoading: filtersLoading } = useFetchFiltersQuery();

  const dispatch = useAppDispatch();

  if(isLoading || !data || !filtersData || filtersLoading) return <div>Loading</div>
  

  return (
    <Grid container spacing={4}>
      <Grid size={3}>
        <Filters filtersData = {filtersData} />
      </Grid>

      <Grid size={9}>
        {data.items && data.items.length > 0 ? (
          <>
            <ProductList products={data.items}/>
            <AppPagination metadata={data.pagination} onPageChange={page => {
              dispatch(setPageNumber(page));
              window.scrollTo({top:0, behavior: 'smooth'});
            }} />
          </>
        ) : (
          <Typography >
            No results for this filter
          </Typography>
        )}
      </Grid>

    </Grid>
  )
}


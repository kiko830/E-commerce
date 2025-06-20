import  { useParams } from "react-router-dom"
import { Button, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { useFetchProductDetailsQuery } from "./catalogApi";

export default function ProductDetails() {
  const {id} = useParams();
  const quantity = 1;

  const {data: product, isLoading} = useFetchProductDetailsQuery(id? +id:0)


  if(!product || isLoading) return <div> Loading</div>

  const productDetails = [
    {lable:'Name', value: product.name},
    {lable:'Description', value: product.description},
    {lable:'Type', value: product.type},
    {lable:'Brand', value: product.brand},
    {lable:'Quantity in stock', value: product.quantityInStock}
  ]

  return (
    <Grid container spacing={6} maxWidth='lg' sx={{mx: 'auto'}}>
        <Grid size={6}>
          <img src={product.pictureUrl}  alt={product.name} style={{width: '100%'}} />
        </Grid>
        <Grid size={6}>
          <Typography variant="h3">{product.name}</Typography>
          <Divider sx={{mx:2}} />
          <Typography variant="h4" color="secondary">${(product.price / 100).toFixed(2)}</Typography>
          <TableContainer>
            <Table sx={{'& td': {fontSize:'1rem'}}}>
              <TableBody>
                {productDetails.map((detail,index) => (
                  <TableRow key = {index}>
                      <TableCell sx={{fontWeight:'bold'}}>{detail.lable}</TableCell>
                      <TableCell>{detail.value}</TableCell>
                </TableRow>
                ))}
                
              </TableBody>
            </Table>
          </TableContainer>
          <Grid container spacing={2} marginTop={3}>
            <Grid size={6}>
              <TextField variant="outlined" type="number" label="Quantity in basket" fullWidth defaultValue={quantity} />
            </Grid>
            <Grid size={6}>
              <Button color="primary" size="large" variant="contained" fullWidth sx={{height: '55px'}}>
                Add to Basket
              </Button>
            </Grid>
          </Grid>
        </Grid>
    </Grid>
  )
}
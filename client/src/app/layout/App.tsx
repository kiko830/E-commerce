import { useEffect, useState } from "react"
import type { Product } from "../models/product"
import Catalog from "../../features/catalog/Catalog"
import { Box, Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material"
import NavBar from "./navBar"


function App() {
  const [products, setProducts] = useState<Product[]>([])
  const [darkMode, setDarkMode] = useState(false);
  const palleteType = darkMode ? 'dark' : 'light';


  const theme = createTheme({
  palette: {
    mode: palleteType,
    background: {
      default: (palleteType === 'light')?   '#eaeaea':'#121212'
    }
  },
});

  useEffect(() => {
    fetch('https://localhost:5001/api/products')
      .then(res => res.json())
      .then(data => setProducts(data))
  }, [])

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <NavBar darkMode={darkMode} toggleDarkMode={() => setDarkMode(!darkMode)}/>
      <Box sx={{minHeight: '100vh', background: darkMode? 'radial-gradient(circle, #1e3aBa, #111B27)': 'radial-gradient(circle, #baecf9, #f0f9ff)', py:6}}>
        <Container maxWidth='xl' sx={{mt:8}}>
     
          <Catalog products={products}/>
        </Container>
      </Box>
      
    </ThemeProvider>
    

  )
}

export default App

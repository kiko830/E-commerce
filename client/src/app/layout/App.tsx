
import { Box, Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material"
import NavBar from "./NavBar";
import { Outlet, ScrollRestoration } from "react-router-dom";
import { useAppSelector } from "../store/store";


function App() {
  
  const {darkMode} = useAppSelector(state => state.ui);
  
  const palleteType = darkMode ? 'dark' : 'light';


  const theme = createTheme({
  palette: {
    mode: palleteType,
    background: {
      default: (palleteType === 'light')?   '#eaeaea':'#121212'
    }
  },
});



  return (
    <ThemeProvider theme={theme}>
      <ScrollRestoration />
      <CssBaseline />
      <NavBar />
      <Box sx={{minHeight: '100vh', background: darkMode? '#121212': '#F5F5F5', py:6}}>
        <Container maxWidth='xl' sx={{mt:8}}>
     
          <Outlet />
        </Container>
      </Box>
      
    </ThemeProvider>
    

  )
}

export default App

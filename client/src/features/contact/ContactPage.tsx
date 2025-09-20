import { EmailOutlined, GitHub, LinkedIn } from "@mui/icons-material";
import { Box, Tooltip, Typography } from "@mui/material";

export default function ContactPage() {
  const email = document.getElementById("email");
  const tooltip = document.getElementById("tooltip");

    email?.addEventListener("click", async () => {
      try {
        await navigator.clipboard.writeText(email.textContent ?? "");
        tooltip!.style.display = 'block';
        setTimeout(() => {
          tooltip!.style.opacity = '1';
        }, 10);
      } catch  {
        alert("Failed to copy email address. Please copy it manually.");
      }
    });
  return (
    <div style={{ maxWidth: '800px', margin: '0 auto', padding: '20px', display: 'flex', flexDirection: 'column', gap: '20px' , justifyContent:'center', alignItems:'center'}}>
      <Typography variant="h3" gutterBottom >
        Contact Me
      </Typography>
      <Typography variant="body1">
        If you have any questions, suggestions, or just want to say hello, feel free to reach out! 
      </Typography>
      <Box display="flex" gap={20} mt={2}>
        <Box display='flex' flexDirection={'column'} alignItems={'center'} justifyContent={'center'} position={'relative'}>
          <EmailOutlined sx={{ verticalAlign: 'middle' }} fontSize="large"/>
          <Typography variant="h6" mb={2}>
            Email
          </Typography>
          <Tooltip title="Click to copy email" arrow>
            <Typography variant="body1" component="span" id="email" sx={{cursor: 'pointer'}}>
              kiko.pp.chen@gmail.com
            </Typography>
          </Tooltip>
          <Typography component="span" id="tooltip" sx={{position:'absolute', top:'10px', right:'20px', backgroundColor:'#fff', font:'32px',
            borderRadius:'4px', padding:'2px 6px', fontSize:'12px', boxShadow: '0 2px 4px rgba(0,0,0,0.2)', display:'none', opacity:0, transition:'opacity 0.3s ease-in-out'
          }}>
            Copied!
          </Typography>
        </Box>
        <Box display='flex' flexDirection={'column'} alignItems={'center'} justifyContent={'center'}>
          <LinkedIn sx={{ verticalAlign: 'middle'}} fontSize="large"/>
          <Typography variant="h6" mb={2}>
            LinkedIn
          </Typography>
          <Typography variant="body1" component="span">
            <a href="https://www.linkedin.com/in/kikochen88" target="_blank" rel="noopener noreferrer" style={{ textDecoration: 'none', color: 'inherit' }}>
              www.linkedin.com/in/kikochen88
            </a>
          </Typography>
        </Box>
        <Box display='flex' flexDirection={'column'} alignItems={'center'} justifyContent={'center'}>
          <GitHub sx={{ verticalAlign: 'middle'}} fontSize="large"/>
          <Typography variant="h6" mb={2}>
            Github
          </Typography>
          <Typography variant="body1" component="span">
            <a href="https://github.com/kiko830" target="_blank" rel="noopener noreferrer" style={{ textDecoration: 'none', color: 'inherit' }}>
              www.github.com/kiko830
            </a>
          </Typography>
        </Box>
      </Box>
    </div>
  )
}
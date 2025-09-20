import { Button, Divider, ListItemIcon, ListItemText, Menu, MenuItem } from "@mui/material";
import { useState } from "react";
import type { User } from "../models/User";
import { History, Logout, Person } from "@mui/icons-material";
import { useLogoutMutation } from "../../features/account/accountApi";
import { Link } from "react-router-dom";
import { useAppSelector } from "../store/store";

type Props = {
    user: User
}
export default function UserMenu({ user }: Props) {
    const [logout] = useLogoutMutation();
   const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const {darkMode} = useAppSelector(state => state.ui);
  const open = Boolean(anchorEl);
  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <div>
      <Button
        onClick={handleClick}
       
        size="large"
        sx={{fontSize:'1.1rem', color: darkMode ? '#FFFFFF' : 'black'}}
      >
        {user.email}
      </Button>
      <Menu
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
      >
        <MenuItem >
            <ListItemIcon>
                <Person />
            </ListItemIcon>
            <ListItemText>My profile</ListItemText>
        </MenuItem>
        <MenuItem component={Link} to='/orders'>
            <ListItemIcon>
                <History />
            </ListItemIcon>
            <ListItemText>My orders</ListItemText>
        </MenuItem>
        <Divider />
        <MenuItem onClick={logout} >
            <ListItemIcon>
                <Logout />
            </ListItemIcon>
            <ListItemText>Logout</ListItemText>
        
        </MenuItem>
      </Menu>
    </div>
  );
}


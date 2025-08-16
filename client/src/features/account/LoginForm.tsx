import { LockOutlined } from "@mui/icons-material";
import { Box, Button, Container, Paper, TextField, Typography } from "@mui/material";
import { Link, useLocation, useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import type { LoginSchema } from "../../lib/schemas/loginSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { loginSchema } from "../../lib/schemas/loginSchema";
import { useLazyUserInfoQuery, useLoginMutation } from "./accountApi";

export default function LoginForm() {
    const [login, {isLoading}] = useLoginMutation();
    const location = useLocation();
    const [fetchUserInfo] = useLazyUserInfoQuery();
    const {register, handleSubmit, formState: { errors }} = useForm<LoginSchema>(
        {
         resolver: zodResolver(loginSchema),
         mode:'onTouched'     
        });

    const navigate = useNavigate();

    const onSubmit = async (data: LoginSchema) => {
       await login(data);
       await fetchUserInfo();
       navigate(location.state?.from || '/catalog');
    };
  return (
    <Container component={Paper} maxWidth='sm' sx={{borderRadius:3}}>
        <Box display={'flex'} flexDirection={'column'} alignItems={'center'} marginTop={8}>
            <LockOutlined sx={{mt:3,color:'secondary.main', fontSize:40 }} />
            <Typography variant="h5">
                Sign in
            </Typography>
            <Box component={'form'} width={'100%'} display={'flex'}
                 flexDirection={'column'} gap={3} marginY={3}
                 onSubmit={handleSubmit(onSubmit)}>
                <TextField label="Email" fullWidth autoFocus
                    {...register('email')}
                    error={!!errors.email} 
                    helperText={errors.email?.message}/>
                <TextField label="Password" type="password" fullWidth 
                    {...register('password')}
                     error={!!errors.password} 
                    helperText={errors.password?.message}/>
                <Button disabled={isLoading} variant="contained" type="submit">
                    Sign in
                </Button>
                <Typography sx={{textAlign:'center'}}>
                    Don't have an account? 
                    <Typography component={Link} to='/register' color="primary" sx={{marginLeft:2}}>
                        Sign up
                    </Typography>
                </Typography>
            </Box>
        </Box>
    </Container>
  )
}


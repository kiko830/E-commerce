import { useForm } from "react-hook-form";
import { useRegisterMutation } from "./accountApi";
import { registerSchema, type RegisterSchema } from "../../lib/schemas/registerSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { LockOutlined } from "@mui/icons-material";
import { Container, Paper, Box, Typography, TextField, Button } from "@mui/material";
import { Link } from "react-router-dom";

export default function RegisterForm() {
  const [registerUser] = useRegisterMutation();
  const {register, handleSubmit,setError, formState:{errors,isLoading, isValid}} = useForm<RegisterSchema>({
    mode: 'onTouched',
    resolver: zodResolver(registerSchema)
  })

  const onSubmit = async (data: RegisterSchema) => {
    try {
        await registerUser(data).unwrap();
    } catch (error) {
        const apiError = error as {message:string}
        if(apiError.message && typeof apiError.message === 'string') {
            const errorArray = apiError.message.split(',');
            errorArray.forEach(err => {
                if(err.includes('Email')) {
                    setError('email', {message: err});
                }else if(err.includes('Password')) {
                    setError('password', {message: err});
                }
            });
        }
    }
  }

  return (
    <Container component={Paper} maxWidth='sm' sx={{borderRadius:3}}>
        <Box display={'flex'} flexDirection={'column'} alignItems={'center'} marginTop={8}>
            <LockOutlined sx={{mt:3,color:'secondary.main', fontSize:40 }} />
            <Typography variant="h5">
                Register
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
                <Button disabled={isLoading || !isValid} variant="contained" type="submit">
                   Register
                </Button>
                <Typography sx={{textAlign:'center'}}>
                    Already have an account? 
                    <Typography component={Link} to='/login' color="primary" sx={{marginLeft:2}}>
                        Sign in here
                    </Typography>
                </Typography>
            </Box>
        </Box>
    </Container>
  )
}